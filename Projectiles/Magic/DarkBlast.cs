using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
	internal class DarkBlast : ModProjectile
	{
		public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 70;
			Projectile.height = 70;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = -1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
		}

		public override void AI()
		{
			if (Projectile.timeLeft > 60)
				Projectile.timeLeft = 60;
            for (int i = 0; i < 4; i++)
            {
                int purple = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<VoidDustG>(), Projectile.velocity.X * 0.30f, Projectile.velocity.Y * 0.30f, 200, default(Color), 3f);
                Main.dust[purple].noGravity = true;
                Main.dust[purple].velocity.X *= 0.15f;
                Main.dust[purple].velocity.Y *= 0.35f;
                int blue = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<VoidDustM>(), Projectile.velocity.X * 0.30f, Projectile.velocity.Y * 0.30f, 200, default(Color), 3f);
                Main.dust[blue].noGravity = true;
                Main.dust[blue].velocity.X *= 0.15f;
                Main.dust[blue].velocity.Y *= 0.15f;
            }
        }
	}
}