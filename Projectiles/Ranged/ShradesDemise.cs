using MultidimensionMod.Buffs.Debuffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	public class ShradesDemise : ModProjectile
	{
		public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Shrades Demise");
		}

		public override void SetDefaults()
		{
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.alpha = 255;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 100;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 2;
		}

		public override void AI()
		{
			float dustScale = 1f;
			if (Projectile.ai[0] == 0f)
				dustScale = 0.25f;
			else if (Projectile.ai[0] == 1f)
				dustScale = 0.5f;
			else if (Projectile.ai[0] == 2f)
				dustScale = 0.75f;

			if (Main.rand.Next(2) == 0)
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.10f, Projectile.velocity.Y * 0.10f, 6);

				if (Main.rand.NextBool(3))
				{
					dust.noGravity = true;
					dust.scale *= 3f;
					dust.velocity.X *= 3f;
					dust.velocity.Y *= 3f;
				}

				dust.scale *= 1.5f;
				dust.velocity *= 1.2f;
				dust.scale *= dustScale;
			}
			Projectile.ai[0] += 1f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<BlazingSuffering>(), 180);
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(ModContent.BuffType<BlazingSuffering>(), 180);
		}

		public override void ModifyDamageHitbox(ref Rectangle hitbox)
		{
			int size = 50;
			hitbox.X -= size;
			hitbox.Y -= size;
			hitbox.Width += size * 2;
			hitbox.Height += size * 2;
		}
	}
}