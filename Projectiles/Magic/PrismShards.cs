using MultidimensionMod.Dusts;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
	internal class PrismShards : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prism Shard");
			Main.projFrames[Projectile.type] = 3;
		}

		public override void SetDefaults()
		{
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
		}

		public override void AI()
		{
			//A purple Lunatic made the original code this one is based on. :>
			Player player = Main.player[Projectile.owner];
			Vector2 targetCenter = Projectile.position;
			Projectile.frame = Main.rand.Next(3);
			Projectile.rotation += 0.2f * (float)Projectile.direction;
			if (player.channel)
			{
				if (player.dead)
				{
					Projectile.Kill();
					return;
				}

				Projectile.localAI[0] += 1f;

				double deg = Projectile.ai[1];
				double rad = deg * (Math.PI / 180);
				double dist = 60;

				Projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - Projectile.width / 2;
				Projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - Projectile.height / 2;
				Projectile.rotation = (float)rad;

				Projectile.ai[1] += 7.5f;
				Projectile.tileCollide = false;
			}
			else if (Projectile.ai[0] == 0f)
            {
				float speed = 21f;
				Vector2 cursorVector = Main.MouseWorld - Projectile.Center;
				float cursorDistance = cursorVector.Length();

				cursorDistance = speed / cursorDistance;
				cursorVector *= cursorDistance;

				Projectile.velocity = cursorVector;
				Projectile.tileCollide = true;
				Projectile.timeLeft = 120;
				Projectile.ai[0] = 1f;
			}
		}

		public override void Kill(int timeLeft)
		{
			int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.BlueCrystalShard, 0f, 0f, 69, default(Color), 2f);
			Main.dust[dustIndex].velocity *= 0.5f;
			Main.dust[dustIndex].scale *= 0.5f;
			int dustIndex2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.PinkCrystalShard, 0f, 0f, 69, default(Color), 2f);
			Main.dust[dustIndex].velocity *= 0.5f;
			Main.dust[dustIndex].scale *= 0.5f;
		}
	}
}