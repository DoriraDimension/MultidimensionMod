using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
	internal class VulkanusRock : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Volcanic Rock");
		}

		public override void SetDefaults()
		{
			Projectile.width = 26;
			Projectile.height = 26;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.hide = false;
			Projectile.timeLeft = 300;
		}

		public override void AI()
		{
			Projectile.rotation += 0.4f * (float)Projectile.direction;
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] >= 15f)
			{
				Projectile.ai[0] = 15f;
				Projectile.velocity.Y = Projectile.velocity.Y + 0.5f;
			}
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}

			Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
			Projectile.rotation = Projectile.velocity.ToRotation();
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}

			if (Projectile.spriteDirection == -1)
			{
				Projectile.rotation += MathHelper.Pi;
			}
			{
				for (int i = 0; i < 5; i++)
				{
					int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.CrimsonTorch, 0f, 0f, 100, default(Color), 2f);
					Main.dust[dustIndex].velocity *= 1.8f;
					Main.dust[dustIndex].alpha = 50;
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

			int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 69, default(Color), 2f);
			Main.dust[dustIndex].velocity *= 1.4f;
		}

		public override bool? CanHitNPC(NPC target)
		{
			return Projectile.timeLeft < 280 ? null : false;
		}
	}
}
