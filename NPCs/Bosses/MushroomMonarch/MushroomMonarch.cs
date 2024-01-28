using MultidimensionMod.Base;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Bags;
using MultidimensionMod.Items.Placeables.Relics;
using MultidimensionMod.Items.Placeables.Trophies;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Common.Players;
using MultidimensionMod.Biomes;
using MultidimensionMod.Common.Systems;
using MultidimensionMod.Items.Weapons.Melee.Boomerangs;
using MultidimensionMod.Items.Weapons.Ranged.Bows;
using MultidimensionMod.Common.ItemDropRules.DropConditions;
using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;
using MultidimensionMod.Items.Mushrooms;
using Terraria.GameContent;
using static Humanizer.In;
using Terraria.DataStructures;
using Terraria.Localization;

namespace MultidimensionMod.NPCs.Bosses.MushroomMonarch
{
    [AutoloadBossHead]
    public class MushroomMonarch : ModNPC
    {
        public bool TitleCard = false;
        public override void SendExtraAI(BinaryWriter writer)
        {
            base.SendExtraAI(writer);
            if(Main.netMode == NetmodeID.Server || Main.dedServ)
            {
                writer.Write(internalAI[0]);
                writer.Write(internalAI[1]);
                writer.Write(internalAI[2]);
                writer.Write(internalAI[3]);
            }
        }

        public override void ReceiveExtraAI(BinaryReader reader)
		{
			base.ReceiveExtraAI(reader);
			if(Main.netMode == NetmodeID.MultiplayerClient)
			{
				internalAI[0] = (float)reader.ReadDouble();
				internalAI[1] = (float)reader.ReadDouble();
                internalAI[2] = (float)reader.ReadDouble();
                internalAI[3] = (float)reader.ReadDouble();
            }	
		}

        public enum ActionState
        {
            Walk,
            Attack,
            Fly,
            FuckYou
        }

        public ActionState AIState
        {
            get => (ActionState)NPC.ai[0];
            set => NPC.ai[0] = (int)value;
        }

        public List<int> AttackList = new() { 0, 1, 2 }; //Summon minions, charge like a truck without a driver, jump like a moron
        public List<int> CopyList = null;
        public int ID { get => (int)NPC.ai[3]; set => NPC.ai[3] = value; }

        void Attacks()
        {
            int attempts = 0;
            while (attempts == 0)
            {
                if (CopyList == null || CopyList.Count == 0)
                    CopyList = new List<int>(AttackList);
                ID = CopyList[Main.rand.Next(0, CopyList.Count)];
                CopyList.Remove(ID);
                NPC.netUpdate = true;

                attempts++;
            }
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mushroom Monarch");
            Main.npcFrameCount[NPC.type] = 13;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 2500;   //boss life
            NPC.damage = 24;  //boss damage
            NPC.defense = 10;    //boss defense
            NPC.knockBackResist = 0f;
            NPC.value = Item.sellPrice(0, 0, 50, 0);
            NPC.aiStyle = -1;
            NPC.width = 50;
            NPC.height = 100;
            NPC.npcSlots = 1f;
            NPC.boss = true;
            NPC.noGravity = false;
            NPC.noTileCollide = false;
            NPC.netAlways = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            if (!Main.dedServ)
                Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Monarch");
            SpawnModBiomes = new int[1] { ModContent.GetInstance<ShroomForest>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.MushroomMonarch")
            });
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MonarchGore1").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MonarchGore2").Type, 1);
            }
        }


        public float[] internalAI = new float[4];
        public int SummonTimer = 0;
        public int MarathonTimer = 0;
        public int JumpTimer = 0;
        public int FlyTimer = 0;
        public int ShittingMyself = 0;
        public int AISwitch = 0;
        public int AreYouSerious = 0;

        public override bool? CanFallThroughPlatforms()
        {
            Player player = Main.player[NPC.target];
            if ((player.Center.Y - NPC.Center.Y) > 150f)
                return true;
            return false;
        }
		
        public override void AI()
        {
            if (!TitleCard)
            {
                if (!Main.dedServ)
                {
                    MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Mushroom Monarch", 60, 90, 1.0f, 0, Color.Orange, "Royal Fungus");
                    TitleCard = true;
                }
            }
            NPC.TargetClosest();

            Player player = Main.player[NPC.target];
            if (!Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height) && internalAI[3] < 180)
            {
                AIState = ActionState.FuckYou;
            }
            if (player == null)
            {
                NPC.TargetClosest();
            }
            if (player.Center.X > NPC.Center.X) // so he faces the player, else he would trip over and die from breaking his nonexistent neck
            {
                NPC.spriteDirection = -1;
            }
            else
            {
                NPC.spriteDirection = 1;
            }

            if (player.dead || !player.active || Vector2.Distance(player.Center, NPC.Center) > 5000)
            {
                NPC.TargetClosest();

                if (player.dead || !player.active || Vector2.Distance(player.Center, NPC.Center) > 5000)
                {
                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, new Vector2(0f, 0f), ModContent.ProjectileType<MonarchRUNAWAYPlayerKill>(), 0, 0);
                    NPC.active = false;
                    return;
                }
            }
            ShittingMyself++;
            if (ShittingMyself == 300)
            {
                ShittingMyself = 0;
                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, new Vector2(0f, 0f), ModContent.ProjectileType<FakeMonarchMushroom>(), 0, 0);
            }

            int FrameSpeed = 10;
            switch (AIState)
            {
                case ActionState.Walk:
                    AISwitch++;
                    NPC.frameCounter++;
                    MushMonWalkAI();
                    if (AIState == ActionState.Walk)
                    {
                        FrameSpeed = 6;
                    }
                    if (!BaseAI.HitTileOnSide(NPC, 3))
                    {
                        NPC.frame.Y = 648;
                    }
                    else if (NPC.frameCounter >= FrameSpeed)
                    {
                        NPC.frameCounter = 0;
                        NPC.frame.Y += 108;
                        if (NPC.frame.Y > (108 * 4))
                        {
                            NPC.frameCounter = 0;
                            NPC.frame.Y = 0;
                        }
                    }
                    if (AISwitch > 180)
                    {
                        AISwitch = 0;
                        Attacks();
                        AIState = ActionState.Attack;
                    }
                    break;
                case ActionState.Attack:
                    switch (ID)
                    {
                        case 0: //summon minions
                            if (NPC.CountNPCS(ModContent.NPCType<RedMushling>()) < 4)
                            {
                                NPC.defense = 20;
                                NPC.velocity.X = 0;
                                NPC.velocity.Y = 0;
                                NPC.frame.Y = 540;
                                SummonTimer++;
                                if (SummonTimer == 50)
                                {
                                    int Minion = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X + 25, (int)NPC.Center.Y + 20, ModContent.NPCType<RedMushling>(), 0);
                                    int Minion2 = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X - 25, (int)NPC.Center.Y + 20, ModContent.NPCType<RedMushling>(), 0);
                                    Main.npc[Minion].netUpdate = true;
                                    Main.npc[Minion2].netUpdate = true;
                                }
                                if (SummonTimer >= 50)
                                {
                                    NPC.frame.Y = 648;
                                }
                                if (SummonTimer == 80)
                                {
                                    NPC.defense = 10;
                                    AIState = ActionState.Walk;
                                    SummonTimer = 0;
                                    NPC.netUpdate = true;
                                }
                            }
                            else
                            {
                                AIState = ActionState.Walk;
                                NPC.netUpdate = true;
                            }
                            break;
                        case 1: //speed up and charge
                            MarathonTimer++;
                            NPC.frameCounter++;
                            MushMonChargeAI();
                            FrameSpeed = 4;
                            if (!BaseAI.HitTileOnSide(NPC, 3))
                            {
                                NPC.frame.Y = 648;
                            }
                            else if (NPC.frameCounter >= FrameSpeed)
                            {
                                NPC.frameCounter = 0;
                                NPC.frame.Y += 108;
                                if (NPC.frame.Y > (108 * 4))
                                {
                                    NPC.frameCounter = 0;
                                    NPC.frame.Y = 0;
                                }
                            }
                            if (MarathonTimer == 180)
                            {
                                AIState = ActionState.Walk;
                                MarathonTimer = 0;
                                NPC.netUpdate = true;
                            }
                            break;
                        case 2: //Jump
                            JumpTimer++;
                            MushMonJumpAI();
                            if (NPC.velocity.Y == 0)
                            {
                                NPC.frame.Y = 540;
                            }
                            else
                            {
                                if (NPC.velocity.Y < 0)
                                {
                                    NPC.frame.Y = 648;
                                }
                                else
                                if (NPC.velocity.Y > 0)
                                {
                                    NPC.frame.Y = 756;
                                }
                            }
                            if (JumpTimer == 240)
                            {
                                AIState = ActionState.Walk;
                                JumpTimer = 0;
                                NPC.netUpdate = true;
                            }
                            break;
                    }
                    break;
                case ActionState.Fly:
                    NPC.noTileCollide = true;
                    NPC.noGravity = true;
                    MushMonFlyAI(player.Center);
                    NPC.frameCounter = 0;
                    NPC.frame.Y += 108;
                    if (NPC.frame.Y > (108 * 11) || NPC.frame.Y < (108 * 8))
                    {
                        NPC.frameCounter = 0;
                        NPC.frame.Y = 108 * 8;
                    }
                    if ((player.Center.Y - NPC.Center.Y) >= 30)
                    {
                        AIState = ActionState.Walk;
                        NPC.noTileCollide = false;
                        NPC.noGravity = false;
                    }
                    break;
                case ActionState.FuckYou:
                    AreYouSerious++;
                    NPC.frame.Y = 0;
                    NPC.velocity.X = 0;
                    NPC.netUpdate = true;
                    if (AreYouSerious >= 140) 
                    {
                        NPC.frame.Y = 540;
                    }
                    if (AreYouSerious == 240)
                    {
                        AreYouSerious = 0;
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, new Vector2(0f, 0f), ModContent.ProjectileType<MonarchRUNAWAYPlayerKill>(), 0, 0);
                        NPC.active = false;
                    }
                    else if (AreYouSerious == 240 && Main.getGoodWorld)
                    {
                        AreYouSerious = 0;
                        player.KillMe(PlayerDeathReason.ByCustomReason(player.name + Language.GetTextValue("Mods.MultidimensionMod.DeathMessages.AntiCheese")), 1000.0, 0);
                    }
                    else if (Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height) && internalAI[3] < 180)
                    {
                        AIState = ActionState.Attack;
                        AreYouSerious = 0;
                    }
                    break;
            }

            if ((player.Center.Y - NPC.Center.Y) < -150f)
            {
                AIState = ActionState.Fly;
            }
        }

        public void MushMonWalkAI()
        {
            Player target = Main.player[NPC.target];
            float speedUp = 0.04f;
            float maxVel = 4.0f;
            if (NPC.Center.X > target.Center.X)
            {
                NPC.velocity.X -= speedUp;
                if (NPC.velocity.X > 0f)
                {
                    NPC.velocity.X -= speedUp;
                }
                if (NPC.velocity.X < 0f - maxVel)
                {
                    NPC.velocity.X = 0f - maxVel;
                }
            }
            if (NPC.Center.X < target.Center.X)
            {
                NPC.velocity.X += speedUp;
                if (NPC.velocity.X < 0f)
                {
                    NPC.velocity.X += speedUp;
                }
                if (NPC.velocity.X > maxVel)
                {
                    NPC.velocity.X = maxVel;
                }
            }
            BaseAI.WalkupHalfBricks(NPC);
            if (Math.Abs(NPC.velocity.X) == NPC.ai[1])
                NPC.velocity.X = NPC.ai[1] * NPC.spriteDirection;
            if (BaseAI.HitTileOnSide(NPC, 3))
            {
                if (NPC.velocity.X < 0f && NPC.direction == -1 || NPC.velocity.X > 0f && NPC.direction == 1)
                {
                    Vector2 newVec = BaseAI.AttemptJump(NPC.position, NPC.velocity, NPC.width, NPC.height, NPC  .direction, NPC.directionY, 6, 10, 4, true);
                    if (NPC.velocity != newVec) { NPC.velocity = newVec; NPC.netUpdate = true; }
                }
            }
        }

        public void MushMonChargeAI() //pretty much just walk AI but fast
        {
            Player target = Main.player[NPC.target];
            float speedUp = 0.06f;
            float maxVel = 8.0f;
            if (NPC.Center.X > target.Center.X)
            {
                NPC.velocity.X -= speedUp;
                if (NPC.velocity.X > 0f)
                {
                    NPC.velocity.X -= speedUp;
                }
                if (NPC.velocity.X < 0f - maxVel)
                {
                    NPC.velocity.X = 0f - maxVel;
                }
            }
            if (NPC.Center.X < target.Center.X)
            {
                NPC.velocity.X += speedUp;
                if (NPC.velocity.X < 0f)
                {
                    NPC.velocity.X += speedUp;
                }
                if (NPC.velocity.X > maxVel)
                {
                    NPC.velocity.X = maxVel;
                }
            }
            BaseAI.WalkupHalfBricks(NPC);
            if (Math.Abs(NPC.velocity.X) == NPC.ai[1])
                NPC.velocity.X = NPC.ai[1] * NPC.spriteDirection;
            if (BaseAI.HitTileOnSide(NPC, 3))
            {
                if (NPC.velocity.X < 0f && NPC.direction == -1 || NPC.velocity.X > 0f && NPC.direction == 1)
                {
                    Vector2 newVec = BaseAI.AttemptJump(NPC.position, NPC.velocity, NPC.width, NPC.height, NPC.direction, NPC.directionY, 12, 14, 6, true);
                    if (NPC.velocity != newVec) { NPC.velocity = newVec; NPC.netUpdate = true; }
                }
            }
        }

        public int BuildUp = 0;

        public void MushMonJumpAI()
        {
            int x = 0;
            if (BaseAI.HitTileOnSide(NPC, 3))
            {
                BuildUp++;
                NPC.velocity.X = x;
            }
            Player target = Main.player[NPC.target];
            if (BuildUp == 10)
            {
                x = 8;
                BuildUp = 0;
                if (BaseAI.HitTileOnSide(NPC, 3))
                {
                    if (target.Center.X < NPC.Center.X)
                        x *= -1;
                    NPC.velocity.X += x;
                    NPC.velocity.Y = -Main.rand.NextFloat(10f, 13f);
                }
                if (NPC.velocity.Y == 0 && !BaseAI.HitTileOnSide(NPC, 3))
                {
                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, new Vector2(0f, 0f), ModContent.ProjectileType<FakeMonarchMushroom>(), 0, 0);
                }
            }
        }

        public void MushMonFlyAI(Vector2 point)
        {
            float moveSpeed = 8f;
            if (Vector2.Distance(NPC.Center, point) > 500)
            {
                moveSpeed = 16f;
            }
            float velMultiplier = 1f;
            Vector2 dist = point - NPC.Center;
            float length = dist == Vector2.Zero ? 0f : dist.Length();
            if (length < moveSpeed)
            {
                velMultiplier = MathHelper.Lerp(0f, 1f, length / moveSpeed);
            }
            if (length < 200f)
            {
                moveSpeed *= 1f;
            }
            if (length < 100f)
            {
                moveSpeed *= 1f;
            }
            if (length < 50f)
            {
                moveSpeed *= 1f;
            }
            NPC.velocity = length == 0f ? Vector2.Zero : Vector2.Normalize(dist);
            NPC.velocity *= moveSpeed;
            NPC.velocity *= velMultiplier;
        }
        
        public void MoveToPoint(Vector2 point)
        {
            float moveSpeed = 8f;
            if (Vector2.Distance(NPC.Center, point) > 500)
            {
                moveSpeed = 12f;
            }
            float velMultiplier = 1f;
            Vector2 dist = point - NPC.Center;
            float length = dist == Vector2.Zero ? 0f : dist.Length();
            if (length < moveSpeed)
            {
                velMultiplier = MathHelper.Lerp(0f, 1f, length / moveSpeed);
            }
            if (length < 200f)
            {
                moveSpeed *= 0.5f;
            }
            if (length < 100f)
            {
                moveSpeed *= 0.5f;
            }
            if (length < 50f)
            {
                moveSpeed *= 0.5f;
            }
            NPC.velocity = length == 0f ? Vector2.Zero : Vector2.Normalize(dist);
            NPC.velocity *= moveSpeed;
            NPC.velocity *= velMultiplier;
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.LesserHealingPotion;
            DownedSystem.downedMonarch = true;
            Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, new Vector2(0f, 0f), ModContent.ProjectileType<MonarchRUNAWAY>(), 0, 0);
            if (!Main.expertMode && Main.rand.NextBool(7))
            {
                //Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<MonarchMask>());
            }
        }

        public override void ModifyNPCLoot(NPCLoot NPCloot)
        {
            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Mushmatter>(), 1, 5, 10));
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<MushroomSoul>()));
            NPCloot.Add(ItemDropRule.BossBag(ModContent.ItemType<MonarchBag>()));
            NPCloot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<MonarchRelic>()));
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<MonarchTrophy>(), 10));
            //notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SusSporeBag>(), 10));
            int choice = Main.rand.Next(2);
            if (choice == 0)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Musharang>()));
            }
            if (choice == 1)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Mushbow>()));
            }
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.6f * balance);  //boss life scale in expertmode
            NPC.damage = (int)(NPC.damage * 0.6f);
        }
    }
}


