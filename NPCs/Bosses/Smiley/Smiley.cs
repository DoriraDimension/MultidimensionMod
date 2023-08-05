using MultidimensionMod.Items.Vanity;
using MultidimensionMod.Items.Bags;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Placeables.Trophies;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Weapons.Melee.Flails;
using MultidimensionMod.Items.Weapons.Ranged.Others;
using MultidimensionMod.Items.Weapons.Magic.Others;
using MultidimensionMod.Items.Weapons.Summon;
using MultidimensionMod.Common.Systems;
using MultidimensionMod.Items.Placeables.Relics;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using static Terraria.GameContent.Animations.IL_Actions.NPCs;
using MultidimensionMod.Base;
using MultidimensionMod.Dusts;
using Terraria.Audio;

//if you see base.velocity.Y += -7f that means theres a jump

namespace MultidimensionMod.NPCs.Bosses.Smiley
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
		public bool phase2 = false;
		Vector2 dashPos;
		bool animatedStart = false;
		int charges = 0;
		float shotType = -1;
		int nextTimeStamp = 60 * 5;
		int ProjectileTimeStamp;
		bool startLeft = Main.rand.NextBool();
		private bool phase1 = true;
		int dustSpawn = 0;
		int dustSpawn2 = 0;
        public static int phase2HeadSlot = -1;
        public bool blink = false;
		public int transition = 0;
		private int bossMode
		{
			get => (int)NPC.ai[0];
			set => NPC.ai[0] = value;
		}
		private int bossTime
		{
			get => (int)NPC.ai[1];
			set => NPC.ai[1] = value;
		}

        public override void Load()
        {
            // We want to give it a second boss head icon, so we register one
            string texture = BossHeadTexture + "2"; // Our texture is called "ClassName_Head_Boss_SecondStage"
            phase2HeadSlot = Mod.AddBossHeadTexture(texture, -1); // -1 because we already have one registered via the [AutoloadBossHead] attribute, it would overwrite it otherwise
        }

        public override void BossHeadSlot(ref int index)
        {
            int slot = phase2HeadSlot;
            if (phase2 && slot != -1)
            {
                // If the boss is in its second stage, display the other head icon instead
                index = slot;
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
			potionType = ItemID.HealingPotion;
			if (!Main.expertMode && Main.rand.NextBool(7))
			{
				Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<SmileyMask>());
			}
		}
		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
            for (int i = 0; i < 15; i++)
			{
				NPCloot.Add(ItemDropRule.Common(ItemID.Heart));
			}
			Main.NewText("Smiley has been defeated!", Color.Purple);
            NPCloot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 11, 11));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<DarkMatterClump>(), 1, 15, 20));
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<SmileySoulshard>()));
			NPCloot.Add(ItemDropRule.BossBag(ModContent.ItemType<SmileyBag>()));
            NPCloot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<SmileyRelic>()));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SmileyTrophy>(), 10));
			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<LonelyWarriorsVisor>(), 10));
			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<DarkCloak>()));
			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<CuteEmoji>(), 10));
			int choice = Main.rand.Next(4);
			if (choice == 0)
            {
				notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<LonelySword>()));
			}
			if (choice == 1)
			{
				notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<DarkMatterLauncher>()));
			}
			if (choice == 2)
			{
				notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SmileySmile>()));
			}
			if (choice == 3)
			{
				notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<DarkRebels>()));
			}
			if (!DownedSystem.downedSmiley)
			{
				DownedSystem.downedSmiley = true;
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
			//Main.NewText(NPC.DirectionTo(targetPosition + (player.velocity * 50)) * projSpeed);

			//this is a modified version of Watcher's ai targeting
			//sick that i get to reuse this

			Projectile.NewProjectile(NPC.GetSource_FromAI(), position, (NPC.DirectionTo(targetPosition + (player.velocity * 25)).RotatedBy(MathHelper.ToRadians(projAngle))) * projSpeed, type, damage, 0f, Main.myPlayer);
		}


		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 20;
            var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                CustomTexturePath = "ExampleMod/Content/NPCs/SmileyBestiary",
            };
        }

		public override void SetDefaults()
		{
			NPC.aiStyle = -1;
			NPC.lifeMax = 10000;
			NPC.damage = 20;
			NPC.defense = 0;
			NPC.knockBackResist = 0f;
			NPC.dontTakeDamage = true;
			NPC.alpha = 255;

			NPC.width = 88;
			NPC.height = 88;
			NPC.value = Item.buyPrice(0, 10, 0, 0);
			NPC.npcSlots = 5f;
			NPC.boss = true;
			NPC.lavaImmune = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath7;
			NPC.netUpdate = true;
            NPC.BossBar = /*phase2 ?*/ ModContent.GetInstance<SmileyBossBar2>() /*: ModContent.GetInstance<SmileyBossBar>()*/;
            if (!Main.dedServ)
			{
				Music = MusicID.Boss2;
			}
		}

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.0f;
            return null;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
		{
			NPC.lifeMax = (int)(NPC.lifeMax * 0.6f * bossAdjustment);
			NPC.damage = (int)(NPC.damage * 0.6f);
		}

		public int ImmaGetYa = 0;

		public override void AI()
		{
            if (Main.rand.NextBool(60))
            {
                blink = true;
            }
            bossTime++;
			Vector2 desVel = new Vector2(0f, -0.05f);
			Player player = Main.player[NPC.target];

			//Main.NewText(bossTime,default,true);
			if (player.active && player.dead != true)
			{
				if (!canDie)
				{
					if (!animatedStart)
					{
						bossMode = -1;
					}

					if (NPC.life != 1)
					{
						if (phase1)
						{
							if (NPC.life <= NPC.lifeMax / 2)
							{
								phase1 = false;
								NPC.dontTakeDamage = true;
								nextTimeStamp = bossTime + 120;
								bossMode = 9;
								NPC.netUpdate = true;
                            }
							if (bossMode == -1)
							{
								NPC.TargetClosest(true);
								if (charges == 0)
								{
									if (startLeft)
									{
										NPC.Center = player.Center + new Vector2(-180, 0);
									}
									else
									{
										NPC.Center = player.Center + new Vector2(180, 0);
									}
									charges = 1;
								}
								if (charges == 1)
								{
                                    NPC.alpha-= 5;
                                    ImmaGetYa++;
                                    if (ImmaGetYa >= 150)
									{
										nextTimeStamp = bossTime + 120;
										charges = 2;
										ImmaGetYa = 150;
									}
                                    NPC.netUpdate = true;
                                }

								if (bossTime >= nextTimeStamp && charges == 2)
								{
									charges = 0;
									bossMode = 0;
									animatedStart = true;
									NPC.dontTakeDamage = false;
								}

							}

							if (bossMode == 0)
							{

								NPC.TargetClosest(true);

								NPC.spriteDirection = -1 * NPC.direction;
								if (charges == 3)
								{
									bossMode = 2;
									shotType = Main.rand.Next(3);
									charges = 0;

								}
								if (bossTime % 22 == 0)
								{
									moveTo = player.Center + new Vector2(-30f, -150);
                                    NPC.netUpdate = true;
                                }
								if (bossTime % 66 == 0)
								{
									moveTo = player.Center + new Vector2(30f, -150);
                                    NPC.netUpdate = true;
                                }

                                //NPC.position = moveTo; //direct mvoe

                                float speed = 8f;
								Vector2 move = moveTo - NPC.Center;
								float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
								if (magnitude > speed)
								{
									move *= speed / magnitude;
								}
								float turnResistance = 30f; //the larger this is, the slower the NPC will turn
								move = (NPC.velocity * turnResistance + move) / (turnResistance + 1f);
								magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
								if (magnitude > speed)
								{
									move *= speed / magnitude;
								}
								NPC.velocity = move;
								if (bossTime >= nextTimeStamp)
								{
									dashPos = NPC.DirectionTo(Main.player[NPC.target].position) * 15f;
									for (int i = 0; i < 12; i++) Dust.NewDust(NPC.Center, NPC.width, NPC.height, ModContent.DustType<VoidDustG>(), Main.rand.Next(6) - 5, Main.rand.Next(6) - 5);
                                    for (int i = 0; i < 12; i++) Dust.NewDust(NPC.Center, NPC.width, NPC.height, ModContent.DustType<VoidDustM>(), Main.rand.Next(6) - 5, Main.rand.Next(6) - 5);
                                    NPC.velocity = dashPos;
									nextTimeStamp = bossTime + 45 + Main.rand.Next(10) - 10;
									charges++;

									bossMode = 1;
								}
							}

							if (bossMode == 1)
							{
								NPC.velocity *= 0.99f;
								if (bossTime >= nextTimeStamp)
								{
									nextTimeStamp = bossTime + 70 + Main.rand.Next(10) - 10;
									bossMode = 0;
								}
							}

							if (bossMode == 2)
							{
								if (bossTime >= ProjectileTimeStamp)
								{
                                    switch (shotType)
									{
										case 0:
											shootTrackedProjAtPlayer(ModContent.ProjectileType<Happy>(), 0, 15f, NPC.damage + 5, NPC.Center, player.Center, player);
											break;
										case 1:
											shootTrackedProjAtPlayer(ModContent.ProjectileType<Joy>(), 0, 10f, NPC.damage - 5, NPC.Center, player.Center, player);
											break;
										case 2:
											shootTrackedProjAtPlayer(ModContent.ProjectileType<Neutral>(), 0, 0f, NPC.damage, NPC.Center, player.Center, player);
											break;

										default:
											shootTrackedProjAtPlayer(ModContent.ProjectileType<Happy>(), 0, 15f, NPC.damage + 5, NPC.Center, player.Center, player);
											break;
									}
									ProjectileTimeStamp = bossTime + 30;
									charges++;
                                }
								if (charges == 4)
								{
									charges = 0;
									bossMode = 0;
								}
                                NPC.netUpdate = true;
                                NPC.TargetClosest(true);
								NPC.spriteDirection = -1 * NPC.direction;
								if (bossTime % 22 == 0)
								{
									moveTo = player.Center + new Vector2(-30f, -150);
								}
								if (bossTime % 66 == 0)
								{
									moveTo = player.Center + new Vector2(30f, -150);
								}
								//NPC.position = moveTo; //direct mvoe

								float speed = 8f;
								Vector2 move = moveTo - NPC.Center;
								float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
								if (magnitude > speed)
								{
									move *= speed / magnitude;
								}
								float turnResistance = 30f; //the larger this is, the slower the NPC will turn
								move = (NPC.velocity * turnResistance + move) / (turnResistance + 1f);
								magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
								if (magnitude > speed)
								{
									move *= speed / magnitude;
								}
								NPC.velocity = move;
							}
						}
						if (!phase1 && !phase2)
						{

							NPC.rotation *= 1.01f;
							NPC.velocity *= 0.85f;
							if (nextTimeStamp <= bossTime)
							{
								backupTimer++;
								if (bossMode == 9)
								{
									Vector2 center = NPC.Center;
									center.X -= 1;
									NPC.velocity *= 0;
                                    NPC.alpha = 255;
                                    NPC.frame.Y = 90 * 7;
									bossMode = -5;
                                    dustSpawn++;
                                    if (dustSpawn == 1)
                                    {
                                        for (int m = 0; m < 20; m++)
                                        {
                                            int dustID = Dust.NewDust(new Vector2(NPC.Center.X - 1, NPC.Center.Y - 1), 2, 2, ModContent.DustType<VoidDustG>(), 0f, 0f, 100, Color.White, 1.6f);
                                            Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)20 * 6.28f);
                                            Main.dust[dustID].noLight = false;
                                            Main.dust[dustID].noGravity = true;
                                        }
                                        for (int m = 0; m < 20; m++)
                                        {
                                            int dustID = Dust.NewDust(new Vector2(NPC.Center.X - 1, NPC.Center.Y - 1), 2, 2, ModContent.DustType<VoidDustM>(), 0f, 0f, 100, Color.White, 2f);
                                            Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(9f, 0f), m / (float)20 * 6.28f);
                                            Main.dust[dustID].noLight = false;
                                            Main.dust[dustID].noGravity = true;
                                        }
                                        if (dustSpawn >= 2)
                                        {
                                            dustSpawn = 2;
                                        }
                                    }
                                    SoundEngine.PlaySound(SoundID.NPCDeath6 with { Volume = .2f }, NPC.position);
                                }
								if (backupTimer >= 6 * 60)
								{
                                    phase2 = true;
                                    NPC.dontTakeDamage = false;
									bossMode = 0;
									backupTimer = 0;
								}
							}
						}
						if (phase2)
						{
							shotType += 0.1f;
							NPC.alpha = 0;
							dustSpawn2++;
							if (dustSpawn2 == 1)
							{
                                for (int m = 0; m < 20; m++)
                                {
                                    int dustID = Dust.NewDust(new Vector2(NPC.Center.X - 1, NPC.Center.Y - 1), 2, 2, ModContent.DustType<VoidDustG>(), 0f, 0f, 100, Color.White, 1.6f);
                                    Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)20 * 6.28f);
                                    Main.dust[dustID].noLight = false;
                                    Main.dust[dustID].noGravity = true;
                                }
                                for (int m = 0; m < 20; m++)
                                {
                                    int dustID = Dust.NewDust(new Vector2(NPC.Center.X - 1, NPC.Center.Y - 1), 2, 2, ModContent.DustType<VoidDustM>(), 0f, 0f, 100, Color.White, 2f);
                                    Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(9f, 0f), m / (float)20 * 6.28f);
                                    Main.dust[dustID].noLight = false;
                                    Main.dust[dustID].noGravity = true;
                                }
								if (dustSpawn2 >= 2)
								{
                                    dustSpawn2 = 2;
                                }
                            }
                            if (bossMode == 0)
							{

								NPC.TargetClosest(true);

								NPC.spriteDirection = -1 * NPC.direction;
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


								//NPC.position = moveTo; //direct mvoe

								float speed = 8f;
								Vector2 move = moveTo - NPC.Center;
								float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
								if (magnitude > speed)
								{
									move *= speed / magnitude;
								}
								float turnResistance = 30f; //the larger this is, the slower the NPC will turn
								move = (NPC.velocity * turnResistance + move) / (turnResistance + 1f);
								magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
								if (magnitude > speed)
								{
									move *= speed / magnitude;
								}
								NPC.velocity = move;
								if (bossTime >= nextTimeStamp)
								{
									dashPos = NPC.DirectionTo(Main.player[NPC.target].position) * 20;
									for (int i = 0; i < 12; i++) Dust.NewDust(NPC.Center, NPC.width, NPC.height, ModContent.DustType<VoidDustG>(), Main.rand.Next(6) - 5, Main.rand.Next(6) - 5);
                                    for (int i = 0; i < 12; i++) Dust.NewDust(NPC.Center, NPC.width, NPC.height, ModContent.DustType<VoidDustM>(), Main.rand.Next(6) - 5, Main.rand.Next(6) - 5);
                                    NPC.velocity = dashPos;
									nextTimeStamp = bossTime + 35 + Main.rand.Next(10) - 10;
									charges++;

									bossMode = 1;
								}

							}

							if (bossMode == 1)
							{
								NPC.velocity *= 0.999f;
								if (bossTime >= nextTimeStamp)
								{
									nextTimeStamp = bossTime + 50 + Main.rand.Next(10) - 10;
									bossMode = 0;
								}
							}

							if (bossMode == 2)
							{
								if (bossTime >= ProjectileTimeStamp)
								{
                                    switch (shotType)
									{

                                        default:
											shootTrackedProjAtPlayer(ModContent.ProjectileType<DarkEmotion>(), 0, 10f, NPC.damage + 5, NPC.Center, player.Center, player);
											break;
									}

                                    ProjectileTimeStamp = bossTime + 30;
									charges++;
								}
								if (charges == 6)
								{
									charges = 0;
									bossMode = 0;
								}

								NPC.TargetClosest(true);

								NPC.spriteDirection = -1 * NPC.direction;

								if (bossTime % 22 == 0)
								{
									moveTo = player.Center + new Vector2(-30f, -150);
								}
								if (bossTime % 66 == 0)
								{
									moveTo = player.Center + new Vector2(30f, -150);
								}

								//NPC.position = moveTo; //direct mvoe

								float speed = 8f;
								Vector2 move = moveTo - NPC.Center;
								float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
								if (magnitude > speed)
								{
									move *= speed / magnitude;
								}
								float turnResistance = 30f; //the larger this is, the slower the NPC will turn
								move = (NPC.velocity * turnResistance + move) / (turnResistance + 1f);
								magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
								if (magnitude > speed)
								{
									move *= speed / magnitude;
								}
								NPC.velocity = move;

							}
						}
					}
				}
				else
				{
					backupTimer++;
					if (bossMode == 56)
					{
						Vector2 center = NPC.Center;
						center.X -= 1;
						NPC.velocity *= 0;
						NPC.frame.Y = 90 * 20;
						bossMode = 57;
					}

					if (NPC.life == 1)
					{
						NPC.dontTakeDamage = true;
						bossMode = -1;
                        NPC.alpha++;
                    }
					if (NPC.alpha == 255)
					{
						NPC.active = false;
						NPC.life = 0;
						NPC.netUpdate = true;
                        NPC.NPCLoot();
                    }
				}
			}

			else
			{
				if (!player.active || player.dead)
				{
					NPC.TargetClosest(false);
					NPC.velocity = NPC.velocity + desVel;


					if (NPC.timeLeft > 360)
					{
						NPC.timeLeft = 360;
					}
				}
			}
		}

		public override bool CheckDead()
		{
			canDie = true;
			NPC.dontTakeDamage = true;
			NPC.life = 1;
			bossMode = 56;

			return false;

		}

		public override bool CanHitPlayer(Player target, ref int cooldownSlot)
		{

			return true;
		}

		public override void FindFrame(int frameHeight)
		{

			if (bossMode == 5 || bossMode == -5)
			{
				NPC.frame.Y = frameHeight * 7;
			}
			if (!phase2)
			{
				if (bossMode == 0 || bossMode == 1)
				{
                    if (blink)
					{
                        if (bossTime % 5 == 0)
                        {
                            NPC.frame.Y += frameHeight;
                            if (NPC.frame.Y == frameHeight * 6)
                            {
                                NPC.frame.Y = 0;
                                blink = false;
                            }
                        }
                    }
                }
				if (bossMode == -1)
				{
					NPC.frame.Y = frameHeight * 3;
				}
			}
			if (phase2)
			{
				if (bossTime % 10 == 0)
				{
					NPC.frame.Y += frameHeight;
					if (NPC.frame.Y == frameHeight * 18)
					{
						NPC.frame.Y = 13 * frameHeight;
					}
				}
			}
			if (NPC.life == 1)
			{
				NPC.frame.Y = 16 * frameHeight;
			}
		}
	}
}