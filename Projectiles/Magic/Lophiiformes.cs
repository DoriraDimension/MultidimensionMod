using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
	public class Lophiiformes : ModProjectile
	{
		public override string Texture => "MultidimensionMod/Projectiles/NoTexture";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lophiiformes");
		}

		public override void SetDefaults()
		{
			Projectile.width = 25;
			Projectile.height = 25;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
		}

		public override void Kill(int timeLeft)
		{

			for (int i = 0; i < 15; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 68, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].alpha = 100;
			}
		}

		public override void AI()
		{
			if (Projectile.timeLeft > 150)
				Projectile.timeLeft = 150;

			Player player = Main.player[Projectile.owner];
			float distanceFromTarget = 700f;
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;

			if (player.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, Projectile.Center);
				if (between < 2000f)
				{
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			if (!foundTarget)
			{
				for (int i = 0; i < Main.maxNPCs; i++)
				{
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy())
					{
						float between = Vector2.Distance(npc.Center, Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall))
						{
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
			Projectile.friendly = foundTarget;

			float speed = 20f;
			float inertia = 20f;

			if (foundTarget)
			{
				if (distanceFromTarget > 40f)
				{
					Vector2 direction = targetCenter - Projectile.Center;
					direction.Normalize();
					direction *= speed;
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
				}
			}

			Projectile.localAI[0] += 1f;
			if (Projectile.localAI[0] > 4f)
			{
				for (int num477 = 0; num477 < 8; num477++)
				{
					int num478 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 68, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num478].noGravity = true;
					Dust dust86 = Main.dust[num478];
					Dust dust2 = dust86;
					dust2.velocity *= 0f;
				}
			}
		}
	}
}