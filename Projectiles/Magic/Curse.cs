using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
	internal class Curse : ModProjectile
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 72;
			Projectile.height = 72;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.localNPCHitCooldown = 30;
			Projectile.ownerHitCheck = true;
			Projectile.alpha = 175;
		}

		public override void AI()
		{
			Projectile.Center = Main.MouseWorld;
			Player player = Main.player[Projectile.owner];
			if (!player.channel || player.statMana <= 0)
            {
				Projectile.Kill();
            }
			if (Main.rand.NextBool(5))
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Shadowflame, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}
        public override bool? CanCutTiles()
        {
            return false;
        }

    }
}
