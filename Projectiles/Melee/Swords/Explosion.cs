using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
	internal class Explosion : ModProjectile
	{
		public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 55;
			Projectile.height = 55;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = true;
			Projectile.penetrate = -1;
			Projectile.localNPCHitCooldown = -1;
			Projectile.timeLeft = 60;
		}

		public override void AI()
		{
			int num104 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, Projectile.velocity.X * 0.30f, Projectile.velocity.Y * 0.30f, 200, default(Color), 3f);
			Main.dust[num104].noGravity = true;
			Main.dust[num104].velocity.X *= 0.15f;
			Main.dust[num104].velocity.Y *= 0.15f;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(BuffID.OnFire, 180);
		}
	}
}