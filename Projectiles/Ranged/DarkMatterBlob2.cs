using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	internal class DarkMatterBlob2 : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Small Blob");
		}

		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 12;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.hide = false;
		}

		public override void AI()
		{
			projectile.velocity.Y = projectile.velocity.Y + 0.2f;
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}

			projectile.direction = projectile.spriteDirection = projectile.velocity.X > 0f ? 1 : -1;
			projectile.rotation = projectile.velocity.ToRotation();
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}

			if (projectile.spriteDirection == -1)
			{
				projectile.rotation += MathHelper.Pi;
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.NPCDeath1, projectile.position);
			int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<DarkDust>(), 0f, 0f, 100, default(Color), 2f);
			Main.dust[dustIndex].velocity *= 1.4f;
		}
	}
}
