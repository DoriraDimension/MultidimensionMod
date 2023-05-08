using MultidimensionMod.Buffs.Minions;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Summon.Sentries
{
	internal class NeroConstruct : ModProjectile
	{
		public int shootTimer = 0;
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.width = 64;
			Projectile.height = 64;
			Projectile.friendly = true;
			Projectile.aiStyle = -1;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.hide = false;
			Projectile.timeLeft = 7200;
			Projectile.localNPCHitCooldown = 10;
			Projectile.sentry = true;
			Projectile.minion = true;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			player.heldProj = player.whoAmI;

			float distanceFromTarget = 700f;
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;

			if (player.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, Projectile.Center);
				if (between < 1500f)
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
						bool closeThroughWall = between < 700f;

						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall))
						{
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}

			if (player.dead || !player.active)
			{
				Projectile.Kill();
			}

			if (foundTarget)
			{
				shootTimer++;
				Vector2 direction = targetCenter - Projectile.Center;
				direction.Normalize();
				if (shootTimer == 50)
				{
					shootTimer = 0;
					SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Item/LauncherShot"), Projectile.position);
					Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, direction * 12, ModContent.ProjectileType<NeroMissile>(), 75, 3, player.whoAmI);

				}
			}
		}

		public override bool? CanDamage()
		{
			return false;
		}

		public override bool? CanCutTiles()
		{
			return false;
		}
	}
}