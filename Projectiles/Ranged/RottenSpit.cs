using MultidimensionMod.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	internal class RottenSpit : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rotten Spit");
		}

		public override void SetDefaults()
		{
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item8, Projectile.position);

			for (int i = 0; i < 2; i++)
			{
				Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity, ModContent.Find<ModGore>("MultidimensionMod/RottenGore3").Type, 1);
			}
			for (int i = 0; i < 2; i++)
			{
				Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity, ModContent.Find<ModGore>("MultidimensionMod/RottenGore2").Type, 1);
			}
			for (int i = 0; i < 6; i++)
			{
				Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity, ModContent.Find<ModGore>("MultidimensionMod/RottenGore1").Type, 1);
			}
		}

		public override void AI()
		{
			if (Projectile.timeLeft > 180)
				Projectile.timeLeft = 180;
			Projectile.rotation += 0.2f * (float)Projectile.direction;
			Projectile.velocity *= 0.85f;

			if (Projectile.timeLeft % 20 == 19 && Projectile.owner == Main.myPlayer)
			{
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X + (float)Main.rand.Next(-100, 100), Projectile.Center.Y + 350f, 0f, -15f, ModContent.ProjectileType<LesserDevourer>(), (int)((double)((float)Projectile.damage) * 0.7), 0f, Projectile.owner);
			}
		}
	}
}
