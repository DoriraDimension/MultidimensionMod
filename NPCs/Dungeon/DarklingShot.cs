using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Dungeon
{
	internal class DarklingShot : ModProjectile
	{
		public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.hostile = true;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item8, Projectile.position);

			for (int i = 0; i < 50; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<VoidDustG>(), 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
                Main.dust[dustIndex].noGravity = true;
                int dustIndex2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<VoidDustM>(), 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex2].velocity *= 1.4f;
                Main.dust[dustIndex2].noGravity = true;
            }
		}

		public override void AI()
		{
			for (int i = 0; i < 4; i++)
			{
				int purple = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<VoidDustG>(), Projectile.velocity.X * 0.30f, Projectile.velocity.Y * 0.30f, 200, default(Color), 3f);
				Main.dust[purple].noGravity = true;
				Main.dust[purple].velocity.X *= 0.15f;
				Main.dust[purple].velocity.Y *= 0.35f;
			}
			for (int i = 0; i < 2; i++)
            {
				int blue = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<VoidDustM>(), Projectile.velocity.X * 0.30f, Projectile.velocity.Y * 0.30f, 200, default(Color), 3f);
				Main.dust[blue].noGravity = true;
				Main.dust[blue].velocity.X *= 0.15f;
				Main.dust[blue].velocity.Y *= 0.15f;
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
