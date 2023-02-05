using MultidimensionMod.Dusts;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	public class HarpoonProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stormfisher Harpoon");
		}

		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.timeLeft = 600;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 20;
			Projectile.penetrate = -1;
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			// Inflate some target hitboxes if they are beyond 8,8 size
			if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
			{
				targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
			}
			// Return if the hitboxes intersects, which means the javelin collides or not
			return projHitbox.Intersects(targetHitbox);
		}

		// 
		/*
		 * The following showcases recommended practice to work with the ai field
		 * You make a property that uses the ai as backing field
		 * This allows you to contextualize ai better in the code
		 */

		// Are we sticking to a target?
		public bool IsStickingToTarget
		{
			get => Projectile.ai[0] == 1f;
			set => Projectile.ai[0] = value ? 1f : 0f;
		}

		// Index of the current target
		public int TargetWhoAmI
		{
			get => (int)Projectile.ai[1];
			set => Projectile.ai[1] = value;
		}

		private const int MAX_STICKY_JAVELINS = 1; // This is the max. amount of javelins being able to attach
		private readonly Point[] _stickingJavelins = new Point[MAX_STICKY_JAVELINS]; // The point array holding for sticking javelins

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			IsStickingToTarget = true; // we are sticking to a target
			TargetWhoAmI = target.whoAmI; // Set the target whoAmI
			Projectile.velocity =
				(target.Center - Projectile.Center) *
				0.75f; // Change velocity based on delta center of targets (difference between entity centers)
			Projectile.netUpdate = true; // netUpdate this javelin

			Projectile.damage = 0; // Makes sure the sticking javelins do not deal damage anymore
			UpdateStickyJavelins(target);
		}

		/*
		 * The following code handles the javelin sticking to the enemy hit.
		 */
		private void UpdateStickyJavelins(NPC target)
		{
			int currentJavelinIndex = 0; // The javelin index

			for (int i = 0; i < Main.maxProjectiles; i++) // Loop all Projectiles
			{
				Projectile currentProjectile = Main.projectile[i];
				if (i != Projectile.whoAmI // Make sure the looped Projectile is not the current javelin
					&& currentProjectile.active // Make sure the Projectile is active
					&& currentProjectile.owner == Main.myPlayer // Make sure the Projectile's owner is the client's player
					&& currentProjectile.type == Projectile.type // Make sure the Projectile is of the same type as this javelin
					&& currentProjectile.ModProjectile is HarpoonProj javelinProjectile // Use a pattern match cast so we can access the Projectile like an ExampleJavelinProjectile
					&& javelinProjectile.IsStickingToTarget // the previous pattern match allows us to use our properties
					&& javelinProjectile.TargetWhoAmI == target.whoAmI)
				{

					_stickingJavelins[currentJavelinIndex++] = new Point(i, currentProjectile.timeLeft); // Add the current Projectile's index and timeleft to the point array
					if (currentJavelinIndex >= _stickingJavelins.Length)  // If the javelin's index is bigger than or equal to the point array's length, break
						break;
				}
			}
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			if (IsStickingToTarget) StickyAI();
			else NormalAI();
			if (player.channel)
            {
				Projectile.Kill();
            }
		}

		private void NormalAI()
		{
			TargetWhoAmI++;

			// Make sure to set the rotation accordingly to the velocity, and add some to work around the sprite's rotation
			// Please notice the MathHelper usage, offset the rotation by 90 degrees (to radians because rotation uses radians) because the sprite's rotation is not aligned!
			Projectile.rotation =
				Projectile.velocity.ToRotation() +
				MathHelper.ToRadians(90f);

			// Spawn some random dusts as the javelin travels
			if (Main.rand.NextBool(3))
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, ModContent.DustType<StormDust>(),
					Projectile.velocity.X * .2f, Projectile.velocity.Y * .2f, 200, Scale: 1.2f);
				dust.velocity += Projectile.velocity * 0.3f;
				dust.velocity *= 0.2f;
			}
			if (Main.rand.NextBool(4))
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, ModContent.DustType<StormDust>(),
					0, 0, 254, Scale: 0.3f);
				dust.velocity += Projectile.velocity * 0.5f;
				dust.velocity *= 0.5f;
			}
		}

		private void StickyAI()
		{
			// These 2 could probably be moved to the ModifyNPCHit hook, but in vanilla they are present in the AI
			Projectile.ignoreWater = true; // Make sure the Projectile ignores water
			Projectile.tileCollide = false; // Make sure the Projectile doesn't collide with tiles anymore
			const int aiFactor = 15; // Change this factor to change the 'lifetime' of this sticking javelin
			Projectile.localAI[0] += 1f;

			// Every 30 ticks, the javelin will perform a hit effect
			bool hitEffect = Projectile.localAI[0] % 30f == 0f;
			int projTargetIndex = (int)TargetWhoAmI;
			if (Projectile.localAI[0] >= 60 * aiFactor || projTargetIndex < 0 || projTargetIndex >= 200)
			{ // If the index is past its limits, kill it
				Projectile.Kill();
			}
			else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage)
			{ // If the target is active and can take damage
			  // Set the Projectile's position relative to the target's center
				Projectile.Center = Main.npc[projTargetIndex].Center - Projectile.velocity * 2f;
				Projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
				if (hitEffect)
				{ // Perform a hit effect here
					Main.npc[projTargetIndex].HitEffect(0, 1.0);
				}
			}
			else
			{ // Otherwise, kill the Projectile
				Projectile.Kill();
			}
		}
	}
}