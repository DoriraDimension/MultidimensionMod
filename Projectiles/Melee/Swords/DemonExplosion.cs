using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
	internal class DemonExplosion : ModProjectile
	{
		public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Demon Explosion");
		}

		public override void SetDefaults()
		{
			Projectile.width = 65;
			Projectile.height = 65;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = -1;
			Projectile.localNPCHitCooldown = -1;
		}

		public override void AI()
		{
			if (Projectile.timeLeft > 60)
				Projectile.timeLeft = 60;

			int num104 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 296, Projectile.velocity.X * 0.30f, Projectile.velocity.Y * 0.30f, 200, default(Color), 3f);
			Main.dust[num104].noGravity = true;
			Main.dust[num104].velocity.X *= 0.15f;
			Main.dust[num104].velocity.Y *= 0.15f;
		}
	}
}