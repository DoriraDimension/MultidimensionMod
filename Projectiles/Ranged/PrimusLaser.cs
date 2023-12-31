using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	internal class PrimusLaser : ModProjectile
	{
		public int LaserCounter;

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Primus Laser");
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.hide = false;
		}

		public override void AI()
		{
			Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            Projectile.spriteDirection = Projectile.direction;

            LaserCounter++;
			if (LaserCounter >= 50)
            {
				SoundEngine.PlaySound(SoundID.Item33 with { Volume = 0.4f }, Projectile.position);
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y + 0f, Projectile.velocity.X, Projectile.velocity.Y, ModContent.ProjectileType<DestroyerDualLaser>(), (int)((double)((float)Projectile.damage) * 0.5), 0f, Main.myPlayer);
				LaserCounter = 0;
			}

			if (++Projectile.frameCounter >= 5)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
				{
					Projectile.frame = 0;
				}
			}
		}

		public override void OnKill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.NPCDeath14, Projectile.position);
			int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 6, default(Color), 2f);
			Main.dust[dustIndex].velocity *= 1.4f;
		}
	}
}