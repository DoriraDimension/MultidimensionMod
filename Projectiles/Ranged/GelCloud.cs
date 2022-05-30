using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	public class GelCloud : ModProjectile
	{
		public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gel Cloud");
		}

		public override void SetDefaults()
		{
			Projectile.width = 65;
			Projectile.height = 65;
			Projectile.alpha = 255;
			Projectile.friendly = true;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 180;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 2;
		}

		public override void AI()
		{
			Player player = Main.LocalPlayer;
			Projectile.velocity *= 0.95f;
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] == 180f)
			{
				Projectile.Kill();
			}
			if (Projectile.ai[1] == 0f)
			{
				Projectile.ai[1] = 1f;
				for (int num64 = 0; num64 < 30; num64++)
				{
					Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 20, Projectile.velocity.X, Projectile.velocity.Y, 50);
				}
			}
		}
	}
}