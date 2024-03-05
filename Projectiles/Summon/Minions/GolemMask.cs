using MultidimensionMod.Buffs.Minions;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.DataStructures;

namespace MultidimensionMod.Projectiles.Summon.Minions
{
	internal class GolemMask : ModProjectile
	{
		public int ballTimer = 0;
		public int laserTimer = 0;
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Golem Mask");
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
			Projectile.localNPCHitCooldown = 10;
		}

		public bool Ugly = false;

		public override void OnSpawn(IEntitySource source)
		{
			if (Main.rand.NextBool(200))
			{
				Ugly = true;
			}
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			player.heldProj = player.whoAmI;
			Projectile.Center = player.Center + Vector2.UnitY * (player.gfxOffY - 70f);

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

						if (((closest && inRange) || !foundTarget) && lineOfSight)
						{
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}

			if (!foundTarget)
			{
				Projectile.spriteDirection = player.direction;
			}

			if (player.dead || !player.active)
			{
				player.ClearBuff(ModContent.BuffType<MaskBuff>());
			}
			if (player.HasBuff(ModContent.BuffType<MaskBuff>()))
			{
				Projectile.timeLeft = 2;
			}
            if (foundTarget)
			{
                ballTimer++;
				laserTimer++;
				Vector2 direction = targetCenter - Projectile.Center;
				direction.Normalize();
				Projectile.rotation = (targetCenter - Projectile.Center).ToRotation() + (Projectile.spriteDirection == 1 ? 0 : MathHelper.Pi);
				if (ballTimer == 150)
				{
					SoundEngine.PlaySound(SoundID.Item34, player.position);
					if (Projectile.owner == Main.myPlayer)
					{
						Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, direction * 6, ModContent.ProjectileType<GolemFireball>(), Projectile.damage, 3, player.whoAmI);
					}
					Projectile.netUpdate = true;

				}
				if (ballTimer == 250)
				{
					ballTimer = 0;
				}
				if (laserTimer == 250)
				{
					laserTimer = 0;
					SoundEngine.PlaySound(SoundID.Item33 with { Volume = 0.4f }, player.position);
					if (Projectile.owner == Main.myPlayer)
					{
						Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, direction * 10, ModContent.ProjectileType<GolemLaser>(), Projectile.damage, 3, player.whoAmI);
					}
					Projectile.netUpdate = true;
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

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D glow = ModContent.Request<Texture2D>(Projectile.ModProjectile.Texture + "_Glow").Value;
            Texture2D uglyTexture = ModContent.Request<Texture2D>(Projectile.ModProjectile.Texture + "2").Value;
            Texture2D uglyGlow = ModContent.Request<Texture2D>(Projectile.ModProjectile.Texture + "2_Glow").Value;
            Vector2 drawOrigin = new(texture.Width / 2, texture.Height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			if (Ugly)
			{
                Main.EntitySpriteDraw(uglyTexture, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(lightColor), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
                Main.EntitySpriteDraw(uglyGlow, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(Color.White), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            }
			else
			{
                Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(lightColor), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
                Main.EntitySpriteDraw(glow, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(Color.White), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            }
            return false;
        }
    }
}