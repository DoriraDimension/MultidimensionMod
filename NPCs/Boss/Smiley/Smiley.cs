using Microsoft.Xna.Framework;
using MultidimensionMod.Projectiles.Boss.Smiley;
using MultidimensionMod.Items.Vanity;
using MultidimensionMod.Items.Bags;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Placeables.Trophies;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items.Weapons.Ranged.Guns;
using MultidimensionMod.Items.Weapons.Magic.Other;
using MultidimensionMod.Items.Weapons.Summon;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

//if you see base.velocity.Y += -7f that means theres a jump

namespace MultidimensionMod.NPCs.Boss.Smiley

{
	[AutoloadBossHead]

	public class Smiley : ModNPC
	{
		public float Timer;
		int backupTimer = 0;
		bool canDie = false;
		int darkling;
		int expertDarkling;
		Vector2 moveTo;
		bool phase2 = false;
		Vector2 dashPos;
		bool animatedStart = false;
		int charges = 0;
		float shotType = -1;
		int nextTimeStamp = 60 * 5;
		int projectileTimeStamp;
		bool startLeft = Main.rand.NextBool();
		private bool phase1 = true;
		int fuckYou = 0;
		private int bossMode
		{
			get => (int)npc.ai[0];
			set => npc.ai[0] = value;
		}
		private int bossTime
		{
			get => (int)npc.ai[1];
			set => npc.ai[1] = value;
		}
		private void SmileyLoot()
		{
			for (int i = 0; i < 15; i++)
			{
				Item.NewItem(npc.getRect(), ItemID.Heart);
			}
			Main.NewText("Smiley has been defeated!", Color.Purple);
			Item.NewItem(npc.getRect(), ItemID.GoldCoin, 11);
			Item.NewItem(npc.getRect(), ModContent.ItemType<DarkMatterClump>(), Main.rand.Next(15, 21));
			Item.NewItem(npc.getRect(), ModContent.ItemType<SmileySoulshard>());
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				if (Main.rand.Next(7) == 0)
				{
					Item.NewItem(npc.getRect(), ModContent.ItemType<SmileyMask>());
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem(npc.getRect(), ModContent.ItemType<SmileyTrophy>());
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem(npc.getRect(), ModContent.ItemType<LonelyWarriorsVisor>());
					Item.NewItem(npc.getRect(), ModContent.ItemType<DarkCloak>());
				}
				if (Main.rand.Next(8) == 0)
				{
					Item.NewItem(npc.getRect(), ModContent.ItemType<CuteEmoji>());
				}
				int choice = Main.rand.Next(4);
				if (choice == 0)
                {
					Item.NewItem(npc.getRect(), ModContent.ItemType<LonelySword>());
				}
				if (choice == 1)
				{
					Item.NewItem(npc.getRect(), ModContent.ItemType<DarkMatterLauncher>());
				}
				if (choice == 2)
				{
					Item.NewItem(npc.getRect(), ModContent.ItemType<SmileySmile>());
				}
				if (choice == 3)
				{
					Item.NewItem(npc.getRect(), ModContent.ItemType<DarkRebels>());
				}
			}
			if (!MDWorld.downedSmiley)
			{
				Main.NewText("I see...", MDRarity.Dorira);
				Main.NewText("You defeated the exiled soldier of darkness...", MDRarity.Dorira);
				Main.NewText("You may be the one who he AND me were looking for.", MDRarity.Dorira);
				MDWorld.downedSmiley = true;
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
				}
			}
		}
		private void shootTrackedProjAtPlayer(int type, int projAngle, float projSpeed, int damage, Vector2 position, Vector2 targetPosition, Player player)
		{

			//found somewhere and could be useful, not applicable here

			/*Vector2 direction = targetPosition - position;
			Vector2 normal = direction;
			normal.Normalize();
			Vector2 pos1 = normal.RotatedBy(MathHelper.ToRadians(projAngle));
			Vector2 pos2 = normal.RotatedBy(MathHelper.ToRadians(-projAngle));*/
			//Main.NewText(npc.DirectionTo(targetPosition + (player.velocity * 50)) * projSpeed);

			//this is a modified version of Watcher's ai targeting
			//sick that i get to reuse this

			Projectile.NewProjectile(position, (npc.DirectionTo(targetPosition + (player.velocity * 25)).RotatedBy(MathHelper.ToRadians(projAngle))) * projSpeed, type, damage, 0f, Main.myPlayer);
		}


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Smiley");
			Main.npcFrameCount[npc.type] = 11;
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 10000;
			npc.damage = 20;
			npc.defense = 0;
			npc.knockBackResist = 0f;
			npc.dontTakeDamage = true;
			npc.alpha = 255;

			npc.width = 88;
			npc.height = 88;
			npc.value = Item.buyPrice(0, 10, 0, 0);
			npc.npcSlots = 5f;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			if (!Main.dedServ)
			{
				npc.HitSound = (mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/smileHit").WithVolume(0.7f).WithPitchVariance(2f));
			}
			npc.DeathSound = SoundID.NPCDeath7;
			npc.netUpdate = true;
			music = MusicID.Boss2;
			bossBag = ModContent.ItemType<SmileyBag>();
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override void AI()
		{
			bossTime++;



			Vector2 desVel = new Vector2(0f, -0.05f);

			Player player = Main.player[npc.target];

			//Main.NewText(bossTime,default,true);
			if (player.active && player.dead != true)
			{
				if (!canDie)
				{





					if (!animatedStart)
					{
						bossMode = -1;

					}

					if (npc.life != 1)
					{
						if (phase1)
						{

							if (npc.life <= npc.lifeMax / 2)
							{
								phase1 = false;
								npc.dontTakeDamage = true;
								nextTimeStamp = bossTime + 120;
								bossMode = 9;


							}
							if (bossMode == -1)
							{
								npc.TargetClosest(true);
								if (charges == 0)
								{
									if (startLeft)
									{
										npc.Center = player.Center + new Vector2(-100, 600);

									}
									else
									{
										npc.Center = player.Center + new Vector2(100, 600);

									}
									npc.alpha = 0;
									charges = 1;

								}
								if (charges == 1)
								{
									npc.Center += new Vector2(0, -4);

									if (npc.Center.Y <= player.Center.Y - 150)
									{
										//play laugh ani and freeze
										Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/SmileLaugh").WithVolume(1.2f).WithPitchVariance(-.9f));
										nextTimeStamp = bossTime + 120;
										charges = 2;
									}
								}

								if (bossTime >= nextTimeStamp && charges == 2)
								{
									charges = 0;
									bossMode = 0;
									animatedStart = true;
									npc.dontTakeDamage = false;
								}

							}



							if (bossMode == 0)
							{

								npc.TargetClosest(true);

								npc.spriteDirection = -1 * npc.direction;
								if (charges == 3)
								{
									bossMode = 2;
									shotType = Main.rand.Next(3);
									charges = 0;

								}
								if (bossTime % 22 == 0)
								{
									moveTo = player.Center + new Vector2(-30f, -150);
								}
								if (bossTime % 66 == 0)
								{
									moveTo = player.Center + new Vector2(30f, -150);
								}


								//npc.position = moveTo; //direct mvoe

								float speed = 8f;
								Vector2 move = moveTo - npc.Center;
								float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
								if (magnitude > speed)
								{
									move *= speed / magnitude;
								}
								float turnResistance = 30f; //the larger this is, the slower the npc will turn
								move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
								magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
								if (magnitude > speed)
								{
									move *= speed / magnitude;
								}
								npc.velocity = move;
								if (bossTime >= nextTimeStamp)
								{
									dashPos = npc.DirectionTo(Main.player[npc.target].position) * 15f;
									for (int i = 0; i < 12; i++) Dust.NewDust(npc.Center, npc.width, npc.height, DustID.AmberBolt, Main.rand.Next(6) - 5, Main.rand.Next(6) - 5);
									npc.velocity = dashPos;
									nextTimeStamp = bossTime + 45 + Main.rand.Next(10) - 10;
									charges++;

									bossMode = 1;
								}

							}

							if (bossMode == 1)
							{
								npc.velocity *= 0.99f;
								if (bossTime >= nextTimeStamp)
								{
									nextTimeStamp = bossTime + 70 + Main.rand.Next(10) - 10;
									bossMode = 0;
								}
							}

							if (bossMode == 2)
							{
								if (bossTime >= projectileTimeStamp)
								{
									switch (shotType)
									{
										case 0:
											shootTrackedProjAtPlayer(ModContent.ProjectileType<Baller>(), 0, 15f, npc.damage + 5, npc.Center, player.Center, player);
											break;
										case 1:
											shootTrackedProjAtPlayer(ModContent.ProjectileType<Baller2>(), 0, 10f, npc.damage - 5, npc.Center, player.Center, player);
											break;
										case 2:
											shootTrackedProjAtPlayer(ModContent.ProjectileType<Baller3>(), 0, 0f, npc.damage, npc.Center, player.Center, player);
											break;

										default:
											shootTrackedProjAtPlayer(ModContent.ProjectileType<Baller>(), 0, 15f, npc.damage + 5, npc.Center, player.Center, player);
											break;
									}

									projectileTimeStamp = bossTime + 30;
									charges++;
								}
								if (charges == 4)
								{
									charges = 0;
									bossMode = 0;
								}


								npc.TargetClosest(true);

								npc.spriteDirection = -1 * npc.direction;




								if (bossTime % 22 == 0)
								{
									moveTo = player.Center + new Vector2(-30f, -150);
								}
								if (bossTime % 66 == 0)
								{
									moveTo = player.Center + new Vector2(30f, -150);
								}


								//npc.position = moveTo; //direct mvoe

								float speed = 8f;
								Vector2 move = moveTo - npc.Center;
								float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
								if (magnitude > speed)
								{
									move *= speed / magnitude;
								}
								float turnResistance = 30f; //the larger this is, the slower the npc will turn
								move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
								magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
								if (magnitude > speed)
								{
									move *= speed / magnitude;
								}
								npc.velocity = move;

							}
						}
						if (!phase1 && !phase2)
						{

							npc.rotation *= 1.01f;
							npc.velocity *= 0.85f;
							if (nextTimeStamp <= bossTime)
							{
								backupTimer++;
								if (bossMode == 9)
								{
									Vector2 center = npc.Center;
									center.X -= 1;
									npc.velocity *= 0;
									npc.ai[3] = Projectile.NewProjectile(center, new Vector2(0, 0), ModContent.ProjectileType<Projectiles.Boss.Smiley.SmileyPhase2>(), 0, 0, 0);
									npc.frame.Y = 90 * 7;
									npc.alpha = 255;
									bossMode = -5;
								}
								if (Main.projectile[(int)npc.ai[3]].ai[1] == 1 || backupTimer >= 6 * 60)
								{
									phase2 = true;
									npc.dontTakeDamage = false;

									darkling = Projectile.NewProjectile(npc.Center - new Vector2(0, 60), new Vector2(0, 0), ModContent.ProjectileType<Darkling>(), npc.damage, 10f);
									if (Main.expertMode) expertDarkling = Projectile.NewProjectile(npc.Center + new Vector2(0, 60), new Vector2(0, 0), ModContent.ProjectileType<Darkling>(), npc.damage, 10f);


									bossMode = 0;
									backupTimer = 0;


								}
								/*for(int i = 0; i < 4; i++)
								{
									//Gore.NewGore(npc.Center, Utils.RandomVector2(new Terraria.Utilities.UnifiedRandom(), 1, 10), mod.GetGoreSlot("Gores/P1gore"));
								}*/


							}

						}
						if (phase2)
						{

							shotType += 0.1f;
							//proj, pointrot, timer, radi(neg)
							Main.projectile[darkling].Center = npc.Center - Vector2.One.RotatedBy(shotType) * -60;
							Main.projectile[darkling].timeLeft = 99;
							if (Main.expertMode)
							{
								Main.projectile[expertDarkling].Center = npc.Center + Vector2.One.RotatedBy(shotType) * -60;
								Main.projectile[expertDarkling].timeLeft = 99;


							}

							npc.alpha = 0;
							if (bossMode == 0)
							{

								npc.TargetClosest(true);

								npc.spriteDirection = -1 * npc.direction;
								if (charges == 3)
								{
									bossMode = 2;
									shotType = Main.rand.Next(3);
									charges = 0;

								}
								if (bossTime % 22 == 0)
								{
									moveTo = player.Center + new Vector2(-30f, -150);
								}
								if (bossTime % 66 == 0)
								{
									moveTo = player.Center + new Vector2(30f, -150);
								}


								//npc.position = moveTo; //direct mvoe

								float speed = 8f;
								Vector2 move = moveTo - npc.Center;
								float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
								if (magnitude > speed)
								{
									move *= speed / magnitude;
								}
								float turnResistance = 30f; //the larger this is, the slower the npc will turn
								move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
								magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
								if (magnitude > speed)
								{
									move *= speed / magnitude;
								}
								npc.velocity = move;
								if (bossTime >= nextTimeStamp)
								{
									dashPos = npc.DirectionTo(Main.player[npc.target].position) * 20;
									for (int i = 0; i < 12; i++) Dust.NewDust(npc.Center, npc.width, npc.height, DustID.AmberBolt, Main.rand.Next(6) - 5, Main.rand.Next(6) - 5);
									npc.velocity = dashPos;
									nextTimeStamp = bossTime + 35 + Main.rand.Next(10) - 10;
									charges++;

									bossMode = 1;
								}

							}

							if (bossMode == 1)
							{
								npc.velocity *= 0.999f;
								if (bossTime >= nextTimeStamp)
								{
									nextTimeStamp = bossTime + 50 + Main.rand.Next(10) - 10;
									bossMode = 0;
								}
							}

							if (bossMode == 2)
							{
								if (bossTime >= projectileTimeStamp)
								{
									switch (shotType)
									{

										default:
											shootTrackedProjAtPlayer(ModContent.ProjectileType<Baller4>(), 0, 10f, npc.damage + 5, npc.Center, player.Center, player);
											break;
									}

									projectileTimeStamp = bossTime + 30;
									charges++;
								}
								if (charges == 6)
								{
									charges = 0;
									bossMode = 0;
								}


								npc.TargetClosest(true);

								npc.spriteDirection = -1 * npc.direction;




								if (bossTime % 22 == 0)
								{
									moveTo = player.Center + new Vector2(-30f, -150);
								}
								if (bossTime % 66 == 0)
								{
									moveTo = player.Center + new Vector2(30f, -150);
								}


								//npc.position = moveTo; //direct mvoe

								float speed = 8f;
								Vector2 move = moveTo - npc.Center;
								float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
								if (magnitude > speed)
								{
									move *= speed / magnitude;
								}
								float turnResistance = 30f; //the larger this is, the slower the npc will turn
								move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
								magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
								if (magnitude > speed)
								{
									move *= speed / magnitude;
								}
								npc.velocity = move;

							}

							//Main.NewText("you're not ready for my SPIN MOVE");
						}
					}
				}
				else
				{
					backupTimer++;
					if (bossMode == 56)
					{
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/SmileLaugh").WithVolume(1.2f).WithPitchVariance(3f));

						Main.projectile[darkling].Kill();
						if (Main.expertMode) Main.projectile[expertDarkling].Kill();
						Vector2 center = npc.Center;
						center.X -= 1;
						npc.velocity *= 0;
						fuckYou = Projectile.NewProjectile(center, new Vector2(0, 0), ModContent.ProjectileType<Projectiles.Boss.Smiley.SmileyDeath>(), 0, 0, 0);
						npc.frame.Y = 90 * 7;
						npc.alpha = 255;
						bossMode = 57;
					}


					if ((Main.projectile[fuckYou].ai[1] == 1 && bossMode == 57) || backupTimer >= 6 * 60)
					{

						SmileyLoot();

						npc.active = false;
						npc.life = 0;

					}
				}
			}

			else
			{
				if (!player.active || player.dead)
				{
					npc.TargetClosest(false);
					npc.velocity = npc.velocity + desVel;


					if (npc.timeLeft > 360)
					{
						npc.timeLeft = 360;
					}

				}

			}

		}

		public override bool CheckDead()
		{
			canDie = true;
			npc.dontTakeDamage = true;
			npc.life = 1;
			bossMode = 56;

			return false;

		}
		public override bool PreNPCLoot()
		{
			return true;
		}
		public override void BossLoot(ref string name, ref int potionType)
		{
			base.BossLoot(ref name, ref potionType);
		}

		public override bool CanHitPlayer(Player target, ref int cooldownSlot)
		{

			return true;
		}

		public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
		{
			if (Main.expertMode || Main.rand.NextBool())
			{
				int debuff = GetDebuff();
				if (debuff >= 0)
				{
					player.AddBuff(debuff, GetDebuffTime(), true);
				}
			}
		}
		public override void FindFrame(int frameHeight)
		{

			if (bossMode == 5 || bossMode == -5)
			{
				npc.frame.Y = frameHeight * 7;
			}
			if (!phase2)
			{
				if (bossMode == 0 || bossMode == 1 || bossMode == 2)
				{
					if (bossTime % 5 == 0)
					{
						npc.frame.Y += frameHeight;
						if (npc.frame.Y == frameHeight * 6)
						{
							npc.frame.Y = 0;

						}

					}
				}
				if (bossMode == -1)
				{
					npc.frame.Y = frameHeight * 3;
				}
			}
			if (phase2)
			{
				if (bossTime % 10 == 0)
				{
					npc.frame.Y += frameHeight;
					if (npc.frame.Y == frameHeight * 11)
					{
						npc.frame.Y = frameHeight * 7;

					}

				}
			}



		}
		public int GetDebuff()
		{

			return BuffID.Ichor;

		}

		public int GetDebuffTime()
		{
			int time;
			time = 120;
			return time;
		}

	}
}