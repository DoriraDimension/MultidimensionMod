using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace MultidimensionMod.Projectiles.Melee.Spears
{
	public class GrassSpearProj : ModProjectile
	{
		public int Leaf;
	    protected virtual float HoldoutRangeMin => 24f;
	    protected virtual float HoldoutRangeMax => 145f;
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Jungle Leaf Spear");
		}

		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.aiStyle = 19;
			Projectile.penetrate = -1;
			Projectile.scale = 1.3f;
			Projectile.alpha = 0;

			Projectile.hide = true;
			Projectile.ownerHitCheck = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
		}

		public override bool PreAI()
		{
			Player player = Main.player[Projectile.owner]; // Since we access the owner player instance so much, it's useful to create a helper local variable for this
			int duration = player.itemAnimationMax; // Define the duration the projectile will exist in frames

			player.heldProj = Projectile.whoAmI; // Update the player's held projectile id

			// Reset projectile time left if necessary
			if (Projectile.timeLeft > duration)
			{
				Projectile.timeLeft = duration;
			}

			Projectile.velocity = Vector2.Normalize(Projectile.velocity); // Velocity isn't used in this spear implementation, but we use the field to store the spear's attack direction.

			float halfDuration = duration * 0.5f;
			float progress;

			// Here 'progress' is set to a value that goes from 0.0 to 1.0 and back during the item use animation.
			if (Projectile.timeLeft < halfDuration)
			{
				progress = Projectile.timeLeft / halfDuration;
			}
			else
			{
				progress = (duration - Projectile.timeLeft) / halfDuration;
			}

			// Move the projectile from the HoldoutRangeMin to the HoldoutRangeMax and back, using SmoothStep for easing the movement
			Projectile.Center = player.MountedCenter + Vector2.SmoothStep(Projectile.velocity * HoldoutRangeMin, Projectile.velocity * HoldoutRangeMax, progress);

			if (Projectile.timeLeft < halfDuration)
            {
				Leaf++;
			}
			if (Leaf == 1)
            {
				Vector2 velocity = Projectile.velocity;
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(18));
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, perturbedSpeed * 2, ModContent.ProjectileType<JungleLeaf>(), (int)((double)((float)Projectile.damage) * 0.8f), 0f, Main.myPlayer);
			}
			if (Leaf > 2)
            {
				Leaf = 2;
            }
			// Apply proper rotation to the sprite.
			if (Projectile.spriteDirection == -1)
			{
				// If sprite is facing left, rotate 45 degrees
				Projectile.rotation += MathHelper.ToRadians(45f);
			}
			else
			{
				// If sprite is facing right, rotate 135 degrees
				Projectile.rotation += MathHelper.ToRadians(135f);
			}

			return false; // Don't execute vanilla AI.
		}
	}
}