using MultidimensionMod.Dusts;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	internal class BubbleBolt : ModProjectile
	{
		public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 6;
			Projectile.height = 6;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.timeLeft = 300;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)Projectile.alpha / 255f);
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 1; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}

		public override void AI()
		{
			int dusto = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Electric, Projectile.velocity.X * 0.30f, Projectile.velocity.Y * 0.30f, 68, default(Color), 1f);
			Main.dust[dusto].noGravity = true;

			if (Projectile.ai[0] >= 360f)
			{
				Projectile.Kill();
			}
			Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.Electrified, 300);
		}

		public override bool? CanHitNPC(NPC target)
		{
			return Projectile.timeLeft < 280 ? null : false;
		}
	}
}
