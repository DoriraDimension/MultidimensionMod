using MultidimensionMod.Projectiles.Ranged;
using System;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Summon.Minions
{
	public class FriendlyProbe : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("Friendly Probe");
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.netImportant = true;
			Projectile.friendly = true;
			Projectile.ignoreWater = true;
			Projectile.aiStyle = 66;
			Projectile.timeLeft = 900;
			Projectile.penetrate = -1;
			Projectile.tileCollide = true;
			Projectile.minion = true;
		}

		public override void AI()
		{
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 8)
			{
				Projectile.frameCounter = 0;
				Projectile.frame++;
			}
			if (Projectile.frame > 5)
			{
				Projectile.frame = 0;
			}
			Player player = Main.player[Projectile.owner];
			Projectile.frameCounter++;
			if (Projectile.frameCounter > 8)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame > 4)
			{
				Projectile.frame = 0;
			}
			float num3 = (float)Main.rand.Next(90, 111) * 0.01f;
			num3 *= Main.essScale;
			Lighting.AddLight(Projectile.Center, 1f * num3, 0f * num3, 0.15f * num3);
			Projectile.rotation = Projectile.velocity.X * 0.04f;
			float num4 = 700f;
			float num5 = 800f;
			float num6 = 1200f;
			float num7 = 150f;
			float num8 = 0.05f;
			for (int j = 0; j < 1000; j++)
			{
				bool flag = Main.projectile[j].type == ModContent.ProjectileType<FriendlyProbe>();
				if (j != Projectile.whoAmI && Main.projectile[j].active && Main.projectile[j].owner == Projectile.owner && flag && Math.Abs(Projectile.position.X - Main.projectile[j].position.X) + Math.Abs(Projectile.position.Y - Main.projectile[j].position.Y) < (float)Projectile.width)
				{
					if (Projectile.position.X < Main.projectile[j].position.X)
					{
						Projectile.velocity.X = Projectile.velocity.X - num8;
					}
					else
					{
						Projectile.velocity.X = Projectile.velocity.X + num8;
					}
					if (Projectile.position.Y < Main.projectile[j].position.Y)
					{
						Projectile.velocity.Y = Projectile.velocity.Y - num8;
					}
					else
					{
						Projectile.velocity.Y = Projectile.velocity.Y + num8;
					}
				}
			}
			bool flag2 = false;
			if (Projectile.ai[0] == 2f)
			{
				Projectile.ai[1] += 1f;
				Projectile.extraUpdates = 1;
				if (Projectile.ai[1] > 40f)
				{
					Projectile.ai[1] = 1f;
					Projectile.ai[0] = 0f;
					Projectile.extraUpdates = 0;
					Projectile.numUpdates = 0;
					Projectile.netUpdate = true;
				}
				else
				{
					flag2 = true;
				}
			}
			if (flag2)
			{
				return;
			}
			Vector2 vector = Projectile.position;
			bool flag3 = false;
			if (Projectile.ai[0] != 1f)
			{
				Projectile.tileCollide = false;
			}
			if (Projectile.tileCollide && WorldGen.SolidTile(Framing.GetTileSafely((int)Projectile.Center.X / 16, (int)Projectile.Center.Y / 16)))
			{
				Projectile.tileCollide = false;
			}
			if (player.HasMinionAttackTargetNPC)
			{
				NPC nPC = Main.npc[player.MinionAttackTargetNPC];
				if (nPC.CanBeChasedBy(Projectile))
				{
					float num9 = Vector2.Distance(nPC.Center, Projectile.Center);
					if (((Vector2.Distance(Projectile.Center, vector) > num9 && num9 < num4) || !flag3) && Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, nPC.position, nPC.width, nPC.height))
					{
						num4 = num9;
						vector = nPC.Center;
						flag3 = true;
					}
				}
			}
			else
			{
				for (int k = 0; k < 200; k++)
				{
					NPC nPC2 = Main.npc[k];
					if (nPC2.CanBeChasedBy(Projectile))
					{
						float num10 = Vector2.Distance(nPC2.Center, Projectile.Center);
						if (((Vector2.Distance(Projectile.Center, vector) > num10 && num10 < num4) || !flag3) && Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, nPC2.position, nPC2.width, nPC2.height))
						{
							num4 = num10;
							vector = nPC2.Center;
							flag3 = true;
						}
					}
				}
			}
			float num11 = num5;
			if (flag3)
			{
				num11 = num6;
			}
			if (flag3)
			{
				Projectile.spriteDirection = ((!((vector - Projectile.Center).X > 0f)) ? 1 : (-1));
			}
			else
			{
				Projectile.spriteDirection = ((!(Projectile.velocity.X > 0f)) ? 1 : (-1));
			}
			if (Vector2.Distance(player.Center, Projectile.Center) > num11)
			{
				Projectile.ai[0] = 1f;
				Projectile.tileCollide = false;
				Projectile.netUpdate = true;
			}
			if (flag3 && Projectile.ai[0] == 0f)
			{
				Vector2 value = vector - Projectile.Center;
				float num12 = value.Length();
				value.Normalize();
				if (num12 > 200f)
				{
					float num13 = 8f;
					value *= num13;
					Projectile.velocity = (Projectile.velocity * 40f + value) / 41f;
				}
				else
				{
					float num14 = 4f;
					value *= 0f - num14;
					Projectile.velocity = (Projectile.velocity * 40f + value) / 41f;
				}
			}
			else
			{
				bool flag4 = false;
				if (!flag4)
				{
					flag4 = Projectile.ai[0] == 1f;
				}
				float num15 = 5f;
				if (flag4)
				{
					num15 = 12f;
				}
				Vector2 center = Projectile.Center;
				Vector2 value2 = player.Center - center + new Vector2(0f, -30f);
				float num16 = value2.Length();
				if (num16 > 200f && num15 < 6.5f)
				{
					num15 = 6.5f;
				}
				if (num16 < num7 && flag4 && !Collision.SolidCollision(Projectile.position, Projectile.width, Projectile.height))
				{
					Projectile.ai[0] = 0f;
					Projectile.netUpdate = true;
				}
				if (num16 > 2000f)
				{
					Projectile.position.X = Main.player[Projectile.owner].Center.X - (float)(Projectile.width / 2);
					Projectile.position.Y = Main.player[Projectile.owner].Center.Y - (float)(Projectile.height / 2);
					Projectile.netUpdate = true;
				}
				if (num16 > 70f)
				{
					value2.Normalize();
					value2 *= num15;
					Projectile.velocity = (Projectile.velocity * 40f + value2) / 41f;
				}
				else if (Projectile.velocity.X == 0f && Projectile.velocity.Y == 0f)
				{
					Projectile.velocity.X = -0.2f;
					Projectile.velocity.Y = -0.1f;
				}
			}
			if (Projectile.ai[1] > 0f)
			{
				Projectile.ai[1] += Main.rand.Next(1, 4);
			}
			if (Projectile.ai[1] > 160f)
			{
				Projectile.ai[1] = 0f;
				Projectile.netUpdate = true;
			}
			if (Projectile.ai[0] != 0f)
			{
				return;
			}
			float num17 = 8f;
			int type = ModContent.ProjectileType<DestroyerDualLaser>();
			if (flag3 && Projectile.ai[1] == 0f)
			{
				Projectile.ai[1] += 1f;
				if (Main.myPlayer == Projectile.owner && Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, vector, 0, 0))
				{
					SoundEngine.PlaySound(SoundID.Item33 with { Volume = 0.4f }, player.position);
					Vector2 vector2 = vector - Projectile.Center;
					vector2.Normalize();
					vector2 *= num17;
					int laser = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vector2.X, vector2.Y, type, Projectile.damage + 40, 0f, Main.myPlayer);
					Main.projectile[laser].timeLeft = 300;
					Projectile.netUpdate = true;
				}
			}
		}
	}
}