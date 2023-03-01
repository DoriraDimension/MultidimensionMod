using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
	internal class Icicle : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Icicle");
		}

		public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item27, base.Projectile.position);

			for (int i = 0; i < 4; i++)
			{
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(45f);
				int numProj = 2;
				float rotation = MathHelper.ToRadians(50f);
				Vector2 perturbedSpeed = base.Projectile.velocity.RotatedBy(MathHelper.Lerp(0f - rotation, rotation, (float)(i / (numProj - 1))));
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), base.Projectile.Center, perturbedSpeed, ModContent.ProjectileType<Smallcicle>(), (int)((float)Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner, 0f);
			}
		}

		public override void AI()
		{
			if (Projectile.timeLeft > 180)
				Projectile.timeLeft = 180;

			if (Projectile.ai[0] >= 360f)
			{
				Projectile.Kill();
			}
			Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
			Projectile.rotation = Projectile.velocity.ToRotation();
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}

			if (Projectile.spriteDirection == -1)
			{
				Projectile.rotation += MathHelper.Pi;
			}
		}
	}
}