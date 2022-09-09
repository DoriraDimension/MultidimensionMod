using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
	internal class HiddenSunScythe : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hidden Sun Scythe");
		}

		public override void SetDefaults()
		{
			Projectile.width = 66;
			Projectile.height = 66;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			for (int e = 0; e < 5; e++)
			{
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-3, 3) * 2, Main.rand.NextFloat(-9, 10)) * 2, ModContent.ProjectileType<AbyssalSoul>(), (int)((double)((float)Projectile.damage) * 0.2f), 0f, Main.myPlayer);
			}
		}

		public override void AI()
		{
			if (Projectile.timeLeft > 180)
				Projectile.timeLeft = 180;			
			Projectile.spriteDirection = Projectile.direction;
			Projectile.rotation += 0.6f * (float)Projectile.direction;
            Projectile.velocity *= 0.98f;

			if (Projectile.timeLeft % 20 == 19 && Projectile.owner == Main.myPlayer)
			{
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(-9, 10)), ModContent.ProjectileType<AbyssalSoul>(), (int)((double)((float)Projectile.damage) * 0.2), 0f, Projectile.owner);
			}
		}
	}
}