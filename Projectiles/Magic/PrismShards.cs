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
        public bool unbound;
        public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
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
				if (!unbound)
				{
                    Projectile.direction = player.direction;
                    Projectile.velocity = player.velocity;
                }
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
			if (!player.channel)
			{
                unbound = true;
            }
		}

		public override void OnKill(int timeLeft)
		{
			int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.BlueCrystalShard, 0f, 0f, 69, default(Color), 2f);
			Main.dust[dustIndex].velocity *= 0.5f;
			Main.dust[dustIndex].scale *= 0.5f;
			int dustIndex2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.PinkCrystalShard, 0f, 0f, 69, default(Color), 2f);
			Main.dust[dustIndex2].velocity *= 0.5f;
			Main.dust[dustIndex2].scale *= 0.5f;
		}
	}
}