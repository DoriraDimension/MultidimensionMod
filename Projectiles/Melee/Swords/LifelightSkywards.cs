using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
	internal class LifelightSkywards : ModProjectile
	{

		public override void SetStaticDefaults()
		{

		}

		public override void SetDefaults()
		{
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = true;
			Projectile.timeLeft = 60;
			Projectile.penetrate = -1;
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.DD2_WitherBeastAuraPulse with { Volume = 2.0f }, Projectile.position);
			for (int i = 0; i < 3; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Enchanted_Gold, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			for (int i = 0; i < 10; i++)
			{
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X + (float)Main.rand.Next(-400, 400), Projectile.Center.Y, 0f, -15f, ModContent.ProjectileType<LifelightBlade>(), (int)((double)((float)Projectile.damage) * 1.5), 0f, Main.myPlayer);
			}
		}

		public override void AI()
		{
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
			Projectile.velocity.Y = -25;
		}
	}
}