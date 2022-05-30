using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	internal class Thunderbubble : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thunderbubble");
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 18;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.alpha = 255;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)Projectile.alpha / 255f);
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item93, Projectile.position);

			for (int i = 0; i < 2; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<StormDust>(), 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}

		public override void AI()
		{
			Projectile.alpha -= 25;
			if (Projectile.alpha < 100)
			{
				Projectile.alpha = 100;
			}

			Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
			Projectile.rotation = Projectile.velocity.ToRotation();
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}

			if (++Projectile.frameCounter >= 5)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
				{
					Projectile.frame = 0;
				}
			}

			Projectile.velocity /= 0.98f;

			if (Projectile.ai[0] >= 60f)
			{
				Projectile.Kill();
			}

			if (Main.rand.Next(5) == 0)
			{
				int choice = Main.rand.Next(3);
				if (choice == 0)
				{
					choice = ModContent.DustType<StormDust>();
				}
				else if (choice == 1)
				{
					choice = ModContent.DustType<StormDust>();
				}
				else
				{
					choice = ModContent.DustType<StormDust>();
				}

				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, choice, Projectile.velocity.X * 1f, Projectile.velocity.Y * 1f, 150, default(Color), 0.7f);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			for (int i = 0; i < 5; i++)
			{
				int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ModContent.ProjectileType<BubbleBolt>(), (int)(Projectile.damage * .5f), 0, Projectile.owner);

			}
		}
	}
}
