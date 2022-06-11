using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
	internal class TundraSickle : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tundrana Sickle");
		}

		public override void SetDefaults()
		{
			Projectile.width = 45;
			Projectile.height = 45;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.hide = false;
			Projectile.penetrate = 3;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 1; i++)
			{
				SoundEngine.PlaySound(SoundID.Item27, base.Projectile.position);
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.BlueCrystalShard, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}

		public override void AI()
		{
			Projectile.rotation += 0.4f * (float)Projectile.direction;

			if (Main.rand.NextBool(4))
			{
				int num104 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.BlueCrystalShard, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
				Main.dust[num104].noGravity = true;
				Main.dust[num104].velocity.X *= 0.3f;
				Main.dust[num104].velocity.Y *= 0.3f;
			}

			if (Projectile.timeLeft % 20 == 19 && Projectile.owner == Main.myPlayer)
			{
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0f, 15f, ModContent.ProjectileType<FrostSpike>(), (int)((double)((float)Projectile.damage) * 0.5), 0f, Projectile.owner);
			}
		}
	}
}