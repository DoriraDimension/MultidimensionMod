using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
	internal class LifelightBlade : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lifelight Holy Blade");
		}

		public override void SetDefaults()
		{
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = true;
			Projectile.penetrate = 4;
			Projectile.timeLeft = 200;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 3; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Enchanted_Gold, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}
        public float rot;

        public override void AI()
        {
			Projectile.spriteDirection = Projectile.direction;
			Projectile.rotation += 0.4f * (float)Projectile.direction;
		}
	}
}