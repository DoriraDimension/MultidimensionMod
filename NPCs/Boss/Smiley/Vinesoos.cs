using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

//if you see base.velocity.Y += -7f that means theres a jump

namespace namespace MultidimensionMod.NPCs.Boss.Smiley

{
	[AutoloadBossHead]

	public class Vinesoos : ModNPC
	{
		Vector2 moveTo;
		Vector2 dashPos;
		bool animatedStart = false;
		int charges = 0;
		int shotType = -1;
		int nextTimeStamp = 60 * 5;
		int projectileTimeStamp;
		bool startLeft = Main.rand.NextBool();
		private bool phase1 = true;

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
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{

			npc.aiStyle = -1;
			npc.lifeMax = 10000;
			npc.damage = 20;
			npc.defense = 0;
			npc.knockBackResist = 0f;
			npc.dontTakeDamage = false;
			npc.alpha = 0;
			
			npc.width = 88;
			npc.height = 88;
			npc.value = Item.buyPrice(0, 10, 0, 0);
			npc.npcSlots = 5f;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath7;
			music = MusicID.Boss2;
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
				if (!animatedStart)
				{
					bossMode = -1;

				}

                if (phase1)
                {

					if (npc.life <= npc.lifeMax/2)
					{
						phase1 = false;
						npc.dontTakeDamage = true;
						nextTimeStamp = bossTime + 120;
						bossMode = 9;
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/SmileLaugh").WithVolume(1.2f).WithPitchVariance(-1.9f));


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
                if (!phase1)
                {
				
						npc.rotation *= 1.01f;
						npc.velocity *= 0.97f;
					if(nextTimeStamp <= bossTime)
                    {

						for(int i = 0; i < 4; i++)
                        {
							//Gore.NewGore(npc.Center, Utils.RandomVector2(new Terraria.Utilities.UnifiedRandom(), 1, 10), mod.GetGoreSlot("Gores/P1gore"));
						}
						NPC.NewNPC((int)npc.Center.X,(int)npc.Center.Y-1, ModContent.NPCType<Transition>());
						npc.active = false;

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
			return true;

		}
		public override bool PreNPCLoot()
		{
			return true;
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
			if(bossMode == -1)
            {
				npc.frame.Y = frameHeight * 3;
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