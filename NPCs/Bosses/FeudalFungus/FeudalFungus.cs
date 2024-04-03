using MultidimensionMod.Base;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Items.Vanity;
using MultidimensionMod.Items.Bags;
using MultidimensionMod.Items.Weapons.Magic.Tomes;
using MultidimensionMod.Items.Weapons.Summon;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Placeables.Relics;
using MultidimensionMod.Items.Placeables.Trophies;
using MultidimensionMod.Common.Systems;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using System.Collections.Generic;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.Localization;
using Microsoft.CodeAnalysis;
using MultidimensionMod.NPCs.Bosses.Smiley;
using MultidimensionMod.Dusts;
using Terraria.GameContent.Events;
using Terraria.GameContent.UI;

namespace MultidimensionMod.NPCs.Bosses.FeudalFungus
{
    [AutoloadBossHead]
    public class FeudalFungus : ModNPC
    {
        public bool TitleCard = false;
        public bool TitleCardPhase2 = false;
        public int damage = 0;
        public bool mad = false;
        public bool UmosMode = false;
        public bool Desperate = false;
        public bool UmosDefeat = false;
        public override void SendExtraAI(BinaryWriter writer)
        {
            base.SendExtraAI(writer);
            if(Main.netMode == NetmodeID.Server || Main.dedServ)
            {
                writer.Write(internalAI[0]);
				writer.Write(internalAI[1]);
                writer.Write(internalAI[2]);
                writer.Write(internalAI[3]);
                writer.Write(internalAI[4]);
            }
		}

        public override void ModifyTypeName(ref string typeName)
        {
            if (UmosMode || DownedSystem.sawUmosTransition)
            {
                typeName = Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.SecondPhaseName");
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
                internalAI[4] = (float)reader.ReadDouble();
            }	
		}	

        public enum ActionState
        {
            TPose,
            Hovering,
            Attack,
            Radiance,
            Goodbye,
            UmosTransition,
            AwayWithThee
        }

        public ActionState AIState
        {
            get => (ActionState)NPC.ai[0];
            set => NPC.ai[0] = (int)value;
        }

        public List<int> AttackList = new() { 0, 1, 2, 3 }; //Summon ring, summon tracking spores, summon mushroom sentries, summon root walls
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
            //DisplayName.SetDefault("Feudal Fungus");
            Main.npcFrameCount[NPC.type] = 13;
            NPCID.Sets.TrailCacheLength[NPC.type] = 8;
            NPCID.Sets.TrailingMode[NPC.type] = 0;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 3000;   //boss life
            NPC.damage = 24;  //boss damage
            NPC.defense = 10;    //boss defense
            NPC.knockBackResist = 0f;
            NPC.value = Item.sellPrice(0, 1, 50, 0);
            NPC.aiStyle = -1;
            NPC.width = 74;
            NPC.height = 150;
            NPC.npcSlots = 1f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.netAlways = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.noTileCollide = true;
            if (!Main.dedServ)
                Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Fungus");
            NPC.alpha = 255;
            NPC.dontTakeDamage = true;
            NPC.AL().CantHurtDapper = true;
            NPC.BossBar = ModContent.GetInstance<FungusBossBar>();
            if (Main.getGoodWorld)
            {
                NPC.scale = 0.5f;
            }
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundMushroom,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.FeudalFungus")
            });
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.LesserHealingPotion;
            DownedSystem.downedFungus = true;
            if (!Main.expertMode && Main.rand.NextBool(7))
            {
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<FungusMask>());
            }
        }

        public override void ModifyNPCLoot(NPCLoot NPCloot)
        {
            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<GlowingMushmatter>(), 1, 5, 10));
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<GlowshroomSoul>()));
            NPCloot.Add(ItemDropRule.BossBag(ModContent.ItemType<FungusBag>()));
            NPCloot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<FungusRelic>()));
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<FungusTrophy>(), 10));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SusGlowsporeBag>(), 10));
            int choice = Main.rand.Next(2);
            if (choice == 0)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<UmosShower>()));
            }
            if (choice == 1)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<RadianceTalisman>()));
            }
            NPCloot.Add(notExpertRule);
        }

		public float[] internalAI = new float[5];

        public override void ModifyIncomingHit(ref NPC.HitModifiers modifiers)
        {
            if (mad)
            {
                modifiers.FinalDamage *= 1.25f;
            }
            return;
        }

        //Did you know that I really love using named timers? No? Well now you do!
        public int despawnTimer = 0;
        public int AISwitch = 0;
        public int MakeItRain = 0;
        public int FireShroom = 0;
        public int RingTime = 0;
        public int DoubleTimer = 0;
        public int DoubleFire = 0;
        public int SentryTimer = 0;
        public int ImFalling = 0;
        public int IHaveLanded = 0;
        public int Waking = 0; //Using NPC.alpha in an if statement didn't work, so another named timer I guess.
        public int ScreamTimer = 0;
        public int DesperateScreamTimer = 0;
        public int DragonballPowerUpSequence = 0;
        public int Away = 0;

        public override void AI()
        {
            if (NPC.CountNPCS(ModContent.NPCType<GlowSentry>()) == 2) //Increases defense by 15 if two Glowing Sentries are alive.
            {
                NPC.defense = 15;
                NPC.netUpdate = true;
            }
            else if (NPC.CountNPCS(ModContent.NPCType<GlowSentry>()) == 1) //Increases defense by 10 if a Glowing Sentry is alive.
            {
                NPC.defense = 10;
                NPC.netUpdate = true;
            }
            else if (NPC.CountNPCS(ModContent.NPCType<GlowBomb>()) == 2) //Increases defense by 15 if two Glowing Bomb are alive.
            {
                NPC.defense = 15;
                NPC.netUpdate = true;
            }
            else if (NPC.CountNPCS(ModContent.NPCType<GlowBomb>()) == 1) //Increases defense by 10 if a Glowing Bomb is alive.
            {
                NPC.defense = 10;
                NPC.netUpdate = true;
            }
            else
                NPC.defense = 10;
            if (!Main.player[NPC.target].ZoneGlowshroom) //Becomes very angry outside of the Glowing Mushroom biome
            {
                mad = true;
                NPC.netUpdate = true;
            }
            else
            {
                mad = false;
                NPC.netUpdate = true;
            }
            NPC.alpha -= 5;
            if (AIState == ActionState.TPose)
            {
                Waking++;
            }
            if (ModContent.GetInstance<MDConfig>().ALTitleCards)
            {
                if (!TitleCard && Waking == 240 && !DownedSystem.sawUmosTransition)
                {
                    if (!Main.dedServ)
                    {
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Feudal.Name"), 60, 90, 1.0f, 0, MDColors.FeudalBlue, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Feudal.Title"));
                        TitleCard = true;
                    }
                }
                if (UmosMode && !TitleCardPhase2 && !DownedSystem.sawUmosTransition || DownedSystem.sawUmosTransition && !TitleCardPhase2 && Waking == 240)
                {
                    if (!Main.dedServ)
                    {
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Feudal.Name2"), 30, 60, 1.0f, 0, Color.Cyan, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Feudal.Title2"));
                        TitleCardPhase2 = true;
                    }
                }
            }
            Player player = Main.player[NPC.target];

            NPC.TargetClosest();

            if (player.dead || !player.active || Vector2.Distance(player.Center, NPC.Center) > 5000)
            {
                NPC.TargetClosest();
                if (player.dead || !player.active)
                {
                    AIState = ActionState.Goodbye;
                    NPC.netUpdate = true;
                }
            }
            if (Waking == 120 && DownedSystem.sawUmosTransition)
            {
                int i = CombatText.NewText(NPC.getRect(), Color.LimeGreen, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.DefeatSpawn"), false, false);
                Main.combatText[i].lifeTime = 120;
            }
            if (Waking >= 60 && Waking < 120)
            {
                NPC.frame.Y = (150 * 8);
            }
            if (Waking >= 120 && Waking < 240)
            {
                EmoteBubble.NewBubble(1, new WorldUIAnchor(NPC), 120);
                NPC.frameCounter++;
                if (NPC.frameCounter >= 10)
                {
                    NPC.frameCounter = 0;
                    NPC.frame.Y += 150;
                    if (NPC.frame.Y > (150 * 10))
                    {
                        NPC.frameCounter = 0;
                        NPC.frame.Y = 150 * 10;
                    }
                }
            }
            if (Waking == 240) //Initiate AI
            {
                AIState = ActionState.Hovering;
                NPC.dontTakeDamage = false;
                NPC.netUpdate = true;
                Waking = 0;
            }
            if (NPC.life >= NPC.lifeMax / 4)
            {
                Lighting.AddLight(NPC.Center, 0, 0, (255 - NPC.alpha) * 0.30f / 255f);
            }
            if (!Desperate && UmosMode)
            {
                Lighting.AddLight(NPC.Center, 0, (255 - NPC.alpha) * 0.15f / 160, (255 - NPC.alpha) * 0.32f / 255f);
            }
            if (NPC.life <= NPC.lifeMax / 4 && !UmosMode)
            {
                AIState = ActionState.UmosTransition;
            }
            if (NPC.life <= NPC.lifeMax / 10 && Main.expertMode)
            {
                AIState = ActionState.Radiance;
                NPC.netUpdate = true;
            }
            if (NPC.life < (int)(NPC.lifeMax * 0.01f))
            {
                NPC.life = 1;
                AIState = ActionState.AwayWithThee;
            }
            switch (AIState)
            {
                case ActionState.TPose:
                    NPC.Center = player.Center + new Vector2(0, -200);
                    break;
                case ActionState.Hovering:
                    if (UmosMode)
                    {
                        NPC.frameCounter++;
                        if (NPC.frameCounter >= 8)
                        {
                            NPC.frameCounter = 0;
                            NPC.frame.Y += 150;
                            if (NPC.frame.Y > (150 * 6))
                            {
                                NPC.frameCounter = 0;
                                NPC.frame.Y = 150 * 0;
                            }
                        }
                        AISwitch++;
                        FungusHoverAI(new Vector2(player.Center.X, player.Center.Y - 200), 0.3f);
                        MakeItRain++;
                        if (MakeItRain == 50) //Shoot spread upwards
                        {
                            int amount = 10; //Amnount of projectiles
                            if (Main.expertMode)
                            {
                                amount = 12; //Fires 2 additional ones in expert mode
                            }
                            for (int i = 0; i < amount; i++)
                            {
                                Vector2 perturbedSpeed = new Vector2(NPC.velocity.X / 2, -20).RotatedByRandom(MathHelper.ToRadians(85));
                                if (Main.netMode != NetmodeID.MultiplayerClient)
                                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y - 10, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<RadianceShot>(), 50 / 3, 0);
                                SoundEngine.PlaySound(Sounds.CustomSounds.RadianceShot with { Volume = 0.70f }, NPC.position);

                            }
                            NPC.netUpdate = true;
                            MakeItRain = 0;
                        }
                        if (AISwitch == 300) //Switch to different attack & reset all timers
                        {
                            AISwitch = 0;
                            FireShroom = 0;
                            MakeItRain = 0;
                            Attacks();
                            AIState = ActionState.Attack;
                            NPC.netUpdate = true;

                        }
                    }
                    else
                    {
                        NPC.frameCounter++;
                        if (NPC.frameCounter >= 8)
                        {
                            NPC.frameCounter = 0;
                            NPC.frame.Y += 150;
                            if (NPC.frame.Y > (150 * 6))
                            {
                                NPC.frameCounter = 0;
                                NPC.frame.Y = 150 * 0;
                            }
                        }
                        AISwitch++;
                        FungusHoverAI(new Vector2(player.Center.X, player.Center.Y - 200), 0.3f);
                        MakeItRain++;
                        if (MakeItRain == 60) //Shoot spread upwards
                        {
                            int amount = 10; //Amnount of projectiles
                            if (Main.expertMode)
                            {
                                amount = 12; //Fires 2 additional ones in expert mode
                            }
                            for (int i = 0; i < amount; i++)
                            {
                                Vector2 perturbedSpeed = new Vector2(NPC.velocity.X / 2, -20).RotatedByRandom(MathHelper.ToRadians(85));
                                if (Main.netMode != NetmodeID.MultiplayerClient)
                                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y - 30, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<Mushshot2>(), 40 / 3, 0);
                                SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Blurb"), NPC.position);
                            }
                            NPC.netUpdate = true;
                            MakeItRain = 0;
                        }
                        if (AISwitch == 240) //Switch to different attack & reset all timers
                        {
                            AISwitch = 0;
                            FireShroom = 0;
                            MakeItRain = 0;
                            Attacks();
                            AIState = ActionState.Attack;
                            NPC.netUpdate = true;
                        }
                    }
                    break;
                case ActionState.Attack:
                    switch (ID)
                    {
                        case 0: //Illumina Ring (spawns a ring projectile on the NPC and makes it move towards the player
                            if (UmosMode)
                            {
                                RingTime++;
                                FungusGlowRingAI(player.Center);
                                if (RingTime < 70)
                                    NPC.velocity = new Vector2(0, 0);
                                if (RingTime >= 70 && RingTime < 300)
                                {
                                    NPC.frame.Y = 150 * 12;
                                }
                                if (RingTime == 70)
                                {
                                    if (Main.netMode != NetmodeID.MultiplayerClient)
                                    {
                                        int ring = Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y, 0f, 0f, ModContent.ProjectileType<RadiantIlluminaRing>(), 72 / 3, 0, Main.myPlayer, NPC.whoAmI);
                                        Main.projectile[ring].netUpdate = true;
                                    }
                                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/HallowedCry"), NPC.position);
                                    NPC.netUpdate = true;
                                }
                                if (RingTime == 250)
                                {
                                    AIState = ActionState.Hovering;
                                    RingTime = 0;
                                    NPC.netUpdate = true;
                                }
                            }
                            else
                            {
                                FungusGlowRingAI(player.Center);
                                RingTime++;
                                if (RingTime < 90)
                                    NPC.velocity = new Vector2(0, 0);
                                if (RingTime >= 90 && RingTime < 300)
                                {
                                    NPC.frame.Y = 150 * 11;
                                }
                                if (RingTime == 90)
                                {
                                    if (Main.netMode != NetmodeID.MultiplayerClient)
                                    {
                                        int ring = Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y, 0f, 0f, ModContent.ProjectileType<IlluminaRing>(), 52 / 3, 0, Main.myPlayer, NPC.whoAmI);
                                        Main.projectile[ring].netUpdate = true;
                                    }
                                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/HallowedCry"), NPC.position);
                                    NPC.netUpdate = true;
                                }
                                if (RingTime == 270)
                                {
                                    AIState = ActionState.Hovering;
                                    RingTime = 0;
                                    NPC.netUpdate = true;
                                }
                            }
                            break;
                        case 1: //Double fire (Starts firing projectiles from both of its arms)
                            FungusHoverAI(new Vector2(Main.rand.NextBool(4) ? player.Center.X - 150 : player.Center.X + 150, player.Center.Y - 200), 0.2f);
                            DoubleTimer++;
                            DoubleFire++;
                            NPC.frameCounter++;
                            if (NPC.frameCounter >= 8)
                            {
                                NPC.frameCounter = 0;
                                NPC.frame.Y += 150;
                                if (NPC.frame.Y > (150 * 6))
                                {
                                    NPC.frameCounter = 0;
                                    NPC.frame.Y = 150 * 0;
                                }
                            }
                            if (DoubleFire == 90 && DoubleTimer <= 180)
                            {
                                Vector2 sped = new Vector2(0, -8);
                                if (Main.netMode != NetmodeID.MultiplayerClient)
                                {
                                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X + 100, NPC.Center.Y - 10, sped.X, sped.Y, ModContent.ProjectileType<StalkingShot>(), 55 / 3, 0);
                                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X - 100, NPC.Center.Y - 10, sped.X, sped.Y, ModContent.ProjectileType<StalkingShot>(), 55 / 3, 0);
                                }
                                SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Blurb"), NPC.position);
                                DoubleFire = 60;
                                NPC.netUpdate = true;
                            }
                            if (DoubleTimer == 300)
                            {
                                AIState = ActionState.Hovering;
                                DoubleTimer = 0;
                                DoubleFire = 0;
                                NPC.netUpdate = true;
                            }
                            break;
                        case 2: //Sentries (Summons a glowing sentry that empowers the boss, only two can be alive at once and the boost stacks. During phase 2, summons a mushroom bomb instead that explodes on death.
                            NPC.frameCounter++;
                            if (NPC.frameCounter >= 8)
                            {
                                NPC.frameCounter = 0;
                                NPC.frame.Y += 150;
                                if (NPC.frame.Y > (150 * 6))
                                {
                                    NPC.frameCounter = 0;
                                    NPC.frame.Y = 150 * 0;
                                }
                            }
                            if (UmosMode)
                            {
                                SentryTimer++;
                                FungusHoverAI(new Vector2(player.Center.X, player.Center.Y - 200), 0.3f);
                                if (SentryTimer == 60)
                                {
                                    for (int m = 0; m < 20; m++)
                                    {
                                        int dustID = Dust.NewDust(new Vector2(NPC.Center.X - 1, NPC.Center.Y - 1), 2, 2, DustID.ManaRegeneration, 0f, 0f, 100, Color.White, 1.6f);
                                        Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)20 * 6.28f);
                                        Main.dust[dustID].noLight = false;
                                        Main.dust[dustID].noGravity = true;
                                    }
                                    SoundEngine.PlaySound(SoundID.Item15 with { Volume = 1.30f }, NPC.position);
                                    if (Main.netMode != NetmodeID.MultiplayerClient)
                                    {
                                        int bomb = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, BaseWorldGen.GetFirstTileFloor((int)NPC.Center.X / 16, (int)NPC.Center.Y / 16) * 16, ModContent.NPCType<GlowBomb>(), 0);
                                        Main.npc[bomb].netUpdate = true;
                                    }
                                    NPC.netUpdate = true;
                                }
                                if (SentryTimer == 120)
                                {
                                    AIState = ActionState.Hovering;
                                    SentryTimer = 0;
                                    NPC.netUpdate = true;
                                }
                            }
                            else
                            {
                                if (NPC.CountNPCS(ModContent.NPCType<GlowSentry>()) < 2)
                                {
                                    SentryTimer++;
                                    FungusHoverAI(new Vector2(player.Center.X, player.Center.Y - 200), 0.3f);
                                    if (SentryTimer == 60)
                                    {
                                        for (int m = 0; m < 20; m++)
                                        {
                                            int dustID = Dust.NewDust(new Vector2(NPC.Center.X - 1, NPC.Center.Y - 1), 2, 2, DustID.ManaRegeneration, 0f, 0f, 100, Color.White, 1.6f);
                                            Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)20 * 6.28f);
                                            Main.dust[dustID].noLight = false;
                                            Main.dust[dustID].noGravity = true;
                                        }
                                        SoundEngine.PlaySound(SoundID.Item15 with { Volume = 1.30f }, NPC.position);
                                        if (Main.netMode != NetmodeID.MultiplayerClient)
                                        {
                                            int Sentry = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, BaseWorldGen.GetFirstTileFloor((int)NPC.Center.X / 16, (int)NPC.Center.Y / 16) * 16, ModContent.NPCType<GlowSentry>(), 0);
                                            Main.npc[Sentry].netUpdate = true;
                                        }
                                        NPC.netUpdate = true;
                                    }
                                    if (SentryTimer == 120)
                                    {
                                        AIState = ActionState.Hovering;
                                        SentryTimer = 0;
                                        NPC.netUpdate = true;
                                    }
                                }
                                else
                                {
                                    AIState = ActionState.Hovering;
                                    NPC.netUpdate = true;
                                }
                            }
                            break;
                        case 3:
                            if (UmosMode)
                            {
                                NPC.frameCounter++;
                                if (NPC.frameCounter >= 8)
                                {
                                    NPC.frameCounter = 0;
                                    NPC.frame.Y += 150;
                                    if (NPC.frame.Y > (150 * 6))
                                    {
                                        NPC.frameCounter = 0;
                                        NPC.frame.Y = 150 * 0;
                                    }
                                }
                                FungusHoverAI(new Vector2(player.Center.X, player.Center.Y - 200), 0.3f);
                                DoubleTimer++;
                                DoubleFire++;
                                if (DoubleFire == 90)
                                {
                                    SoundEngine.PlaySound(SoundID.Item4, NPC.position);
                                    if (Main.netMode != NetmodeID.MultiplayerClient)
                                    {
                                        Projectile.NewProjectile(NPC.GetSource_FromAI(), player.Center.X - 500, player.Center.Y - 10, 0, 0, ModContent.ProjectileType<MushWave>(), 40 / 3, 0);
                                        Projectile.NewProjectile(NPC.GetSource_FromAI(), player.Center.X + 500, player.Center.Y - 10, 0, 0, ModContent.ProjectileType<MushWave>(), 40 / 3, 0);
                                    }
                                }
                                if (DoubleFire == 180)
                                {
                                    SoundEngine.PlaySound(SoundID.Item4, NPC.position);
                                    if (Main.netMode != NetmodeID.MultiplayerClient)
                                    {
                                        Projectile.NewProjectile(NPC.GetSource_FromAI(), player.Center.X, player.Center.Y - 500, 0, 0, ModContent.ProjectileType<MushWave>(), 40 / 3, 0);
                                        Projectile.NewProjectile(NPC.GetSource_FromAI(), player.Center.X, player.Center.Y + 500, 0, 0, ModContent.ProjectileType<MushWave>(), 40 / 3, 0);
                                    }
                                    NPC.netUpdate = true;
                                    DoubleFire = 0;

                                }
                                if (DoubleTimer == 270)
                                {
                                    AIState = ActionState.Hovering;
                                    DoubleTimer = 0;
                                    DoubleFire = 0;
                                    NPC.netUpdate = true;
                                }
                            }
                            else
                            {
                                ImFalling++;
                                NPC.velocity.X = 0;
                                if (ImFalling <= 120)
                                {
                                    NPC.frameCounter++;
                                    if (NPC.frameCounter >= 8)
                                    {
                                        NPC.frameCounter = 0;
                                        NPC.frame.Y += 150;
                                        if (NPC.frame.Y > (150 * 6))
                                        {
                                            NPC.frameCounter = 0;
                                            NPC.frame.Y = 150 * 0;
                                        }
                                    }
                                    NPC.velocity.Y = 0;

                                }
                                if (ImFalling >= 120)
                                {
                                    NPC.frame.Y = 150 * 10;
                                }
                                if (ImFalling == 120)
                                {
                                    NPC.velocity.Y = 20;
                                    NPC.netUpdate = true;
                                }
                                if ((player.Center.Y - NPC.Center.Y) <= 30)
                                {
                                    NPC.noTileCollide = false;
                                }
                                if (BaseAI.HitTileOnSide(NPC, 3))
                                {
                                    NPC.frame.Y = 150 * 4;
                                    IHaveLanded++;
                                    if (IHaveLanded == 1)
                                    {
                                        if (Main.netMode != NetmodeID.MultiplayerClient)
                                        {
                                            int wall = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X + 400, BaseWorldGen.GetFirstTileFloor((int)NPC.Center.X / 16, (int)NPC.Center.Y / 16) * 16, ModContent.NPCType<EvokedMushroot>(), 0);
                                            Main.npc[wall].netUpdate = true;
                                            int wall2 = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X - 400, BaseWorldGen.GetFirstTileFloor((int)NPC.Center.X / 16, (int)NPC.Center.Y / 16) * 16, ModContent.NPCType<EvokedMushroot>(), 0);
                                            Main.npc[wall2].netUpdate = true;
                                        }
                                        SoundEngine.PlaySound(SoundID.Item14, NPC.position);
                                        NPC.netUpdate = true;
                                    }
                                }
                                if (IHaveLanded == 60)
                                {
                                    NPC.noTileCollide = true;
                                    AIState = ActionState.Hovering;
                                    ImFalling = 0;
                                    IHaveLanded = 0;
                                    NPC.netUpdate = true;
                                }
                            }
                            break;
                    }
                    break;
                case ActionState.Radiance:
                    Desperate = true;
                    NPC.Center = player.Center + new Vector2(0, -200);
                    MakeItRain++;
                    Lighting.AddLight(NPC.Center, 0, (255 - NPC.alpha) * 0.32f / 255, (255 - NPC.alpha) * 0.10f / 130f);
                    DesperateScreamTimer++;
                    NPC.frameCounter++;
                    if (NPC.frameCounter >= 5)
                    {
                        NPC.frameCounter = 0;
                        NPC.frame.Y += 150;
                        if (NPC.frame.Y > (150 * 6))
                        {
                            NPC.frameCounter = 0;
                            NPC.frame.Y = 150 * 0;
                        }
                    }
                    if (DesperateScreamTimer == 1)
                    {
                        SoundEngine.PlaySound(Sounds.CustomSounds.RoyalRadianceScream with { Pitch = 0.30f }, NPC.position);
                    }
                    if (DesperateScreamTimer >= 2)
                    {
                        DesperateScreamTimer = 2;
                    }
                    if (MakeItRain == 50) //Shoot spread upwards
                    {
                        int amount = 14;
                        for (int i = 0; i < amount; i++)
                        {
                            Vector2 targetCenter = player.position;
                            float ProjSpeed = 12f;
                            Vector2 velocity = targetCenter - NPC.Center;
                            velocity.Normalize();
                            velocity *= ProjSpeed;
                            Vector2 perturbedSpeed = new Vector2(NPC.velocity.X / 2, -20).RotatedByRandom(MathHelper.ToRadians(85));
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y - 10, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<PureRadianceShot>(), 60 / 3, 0);
                            SoundEngine.PlaySound(Sounds.CustomSounds.RadianceShot with { Volume = 0.70f }, NPC.position);
                        }
                        NPC.netUpdate = true;
                        MakeItRain = 0;
                    }
                    break;
                case ActionState.Goodbye:
                    NPC.velocity = new Vector2(0, 0);
                    NPC.alpha += 50;
                    NPC.frameCounter++;
                    if (NPC.frameCounter >= 8)
                    {
                        NPC.frameCounter = 0;
                        NPC.frame.Y += 150;
                        if (NPC.frame.Y > (150 * 6))
                        {
                            NPC.frameCounter = 0;
                            NPC.frame.Y = 150 * 0;
                        }
                    }
                    if (NPC.alpha >= 255)
                    {
                        NPC.active = false;
                    }
                    break;
                case ActionState.UmosTransition:
                    NPC.velocity.X = 0;
                    NPC.velocity.Y = 0;
                    NPC.dontTakeDamage = true;
                    DragonballPowerUpSequence++;
                    if (DownedSystem.sawUmosTransition)
                    {

                        if (DragonballPowerUpSequence == 60)
                        {
                            AISwitch = 0;
                            DragonballPowerUpSequence = 0;
                            UmosMode = true;
                            AIState = ActionState.Hovering;
                            SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/RoyalRadianceScream"), NPC.position);
                            NPC.dontTakeDamage = false;
                        }
                    }
                    else
                    {
                        if (!Main.dedServ)
                            Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Silence");
                        if (DragonballPowerUpSequence < 300)
                        {
                            NPC.frameCounter++;
                            if (NPC.frameCounter >= 8)
                            {
                                NPC.frameCounter = 0;
                                NPC.frame.Y += 150;
                                if (NPC.frame.Y > (150 * 6))
                                {
                                    NPC.frameCounter = 0;
                                    NPC.frame.Y = 150 * 0;
                                }
                            }
                        }
                        else if (DragonballPowerUpSequence >= 300 && DragonballPowerUpSequence < 840)
                        {
                            NPC.frame.Y = 150 * 7;
                        }
                        else if (DragonballPowerUpSequence >= 840)
                        {
                            NPC.frameCounter++;
                            if (NPC.frameCounter >= 8)
                            {
                                NPC.frameCounter = 0;
                                NPC.frame.Y += 150;
                                if (NPC.frame.Y > (150 * 10))
                                {
                                    NPC.frameCounter = 0;
                                    NPC.frame.Y = 150 * 10;
                                }
                            }
                        }
                        if (DragonballPowerUpSequence == 120)
                        {
                            int i = CombatText.NewText(NPC.getRect(), MDColors.FeudalBlue, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Transition1"), false, false);
                            Main.combatText[i].lifeTime = 120;
                        }
                        if (DragonballPowerUpSequence == 300)
                        {
                            int i = CombatText.NewText(NPC.getRect(), Color.LimeGreen, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Transition2"), false, false);
                            Main.combatText[i].lifeTime = 120;
                        }
                        if (DragonballPowerUpSequence == 480)
                        {
                            int i = CombatText.NewText(NPC.getRect(), MDColors.FeudalBlue, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Transition3"), false, false);
                            Main.combatText[i].lifeTime = 120;
                        }
                        if (DragonballPowerUpSequence == 660)
                        {
                            int i = CombatText.NewText(NPC.getRect(), Color.LimeGreen, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Transition4"), false, false);
                            Main.combatText[i].lifeTime = 120;
                        }
                        if (DragonballPowerUpSequence == 840)
                        {
                            int i = CombatText.NewText(NPC.getRect(), Color.LimeGreen, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Transition5"), false, false);
                            Main.combatText[i].lifeTime = 120;
                        }
                        if (DragonballPowerUpSequence == 1020)
                        {
                            int i2 = CombatText.NewText(NPC.getRect(), Color.LimeGreen, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Transition6"), false, false);
                            Main.combatText[i2].lifeTime = 60;
                        }
                        if (DragonballPowerUpSequence == 1120)
                        {
                            int i = CombatText.NewText(NPC.getRect(), MDColors.FeudalBlue, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Transition7"), false, false);
                            Main.combatText[i].lifeTime = 60;
                        }
                        if (DragonballPowerUpSequence == 1200)
                        {
                            AISwitch = 0;
                            DragonballPowerUpSequence = 0;
                            UmosMode = true;
                            AIState = ActionState.Hovering;
                            SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/RoyalRadianceScream"), NPC.position);
                            NPC.dontTakeDamage = false;
                            if (!Main.dedServ)
                                Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Fungus");
                            if (!DownedSystem.sawUmosTransition)
                            {
                                DownedSystem.sawUmosTransition = true;
                                if (Main.netMode == NetmodeID.Server)
                                {
                                    NetMessage.SendData(MessageID.WorldData);
                                }
                            }
                        }
                    }
                    break;
                case ActionState.AwayWithThee:
                    Lighting.AddLight(NPC.Center, 0, (255 - NPC.alpha) * 0.03f / 255, 0);
                    Main.npcFrameCount[NPC.type] = 5;
                    NPC.velocity.X = 0;
                    NPC.velocity.Y = 0;
                    NPC.dontTakeDamage = true;
                    UmosDefeat = true;
                    Away++;
                    NPC.ai[1]++;
                    if (Away == 1)
                    {
                        Gore.NewGore(NPC.GetSource_FromThis(), NPC.position + new Vector2(0, -40), NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/FeudalGore1").Type, 1);
                        Gore.NewGore(NPC.GetSource_FromThis(), NPC.position + new Vector2(20, -10), NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/FeudalGore2").Type, 1);
                        Gore.NewGore(NPC.GetSource_FromThis(), NPC.position + new Vector2(-20, -10), NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/FeudalGore2").Type, 1);
                        Gore.NewGore(NPC.GetSource_FromThis(), NPC.position + new Vector2(20, 10), NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/FeudalGore3").Type, 1);
                        Gore.NewGore(NPC.GetSource_FromThis(), NPC.position + new Vector2(-20, 10), NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/FeudalGore3").Type, 1);
                    }
                    if (Away < 120)
                    {
                        NPC.frame.Y = 150 * 0;
                    }
                    if (Away >= 120)
                    {
                        NPC.frameCounter++;
                        if (NPC.frameCounter >= 12)
                        {
                            NPC.frameCounter = 0;
                            NPC.frame.Y += 150;
                            if (NPC.frame.Y > (150 * 4))
                            {
                                NPC.frameCounter = 0;
                                NPC.frame.Y = 150 * 4;
                            }
                        }
                    }
                    if (DownedSystem.downedFungus)
                    {
                        if (Away == 220)
                        {
                            int i2 = CombatText.NewText(NPC.getRect(), Color.LimeGreen, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Defeat3"), false, false);
                            Main.combatText[i2].lifeTime = 100;
                        }
                    }
                    else
                    {
                        if (Away == 180)
                        {
                            int i2 = CombatText.NewText(NPC.getRect(), Color.LimeGreen, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Defeat1"), false, false);
                            Main.combatText[i2].lifeTime = 30;
                        }
                        if (Away == 260)
                        {
                            int i2 = CombatText.NewText(NPC.getRect(), Color.LimeGreen, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Defeat2"), false, false);
                            Main.combatText[i2].lifeTime = 60;
                        }
                    }
                    if (NPC.ai[1] > 260f && NPC.ai[1] < 320f)
                    {
                        MoonlordDeathDrama.RequestLight(NPC.ai[1] / 30f, NPC.Center);
                    }
                    if (Away == 320)
                    {
                        NPC.active = false;
                        NPC.life = 0;
                        NPC.netUpdate = true;
                        NPC.NPCLoot();
                        Main.npcFrameCount[NPC.type] = 13;
                        if (!DownedSystem.downedFungus)
                        {
                            DownedSystem.downedFungus = true;
                            if (Main.netMode == NetmodeID.Server)
                            {
                                NetMessage.SendData(MessageID.WorldData);
                            }
                        }
                    }
                    break;
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (AIState == ActionState.AwayWithThee && Away == 1)
            {
            }
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.6f * balance);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        public void FungusHoverAI(Vector2 targetPos, float speedModifier)
        {
            Player target = Main.player[NPC.target];
            float speedUp = 0.12f;
            float maxVel = 10.0f;
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
                NPC.netUpdate = true;
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
                NPC.netUpdate = true;
            }
            if (NPC.Center.Y < targetPos.Y)
            {
                NPC.velocity.Y += speedModifier;
                if (NPC.velocity.Y < 0)
                    NPC.velocity.Y += speedModifier * 2;
                NPC.netUpdate = true;
            }
            else
            {
                NPC.velocity.Y -= speedModifier;
                if (NPC.velocity.Y > 0)
                NPC.velocity.Y -= speedModifier * 2;
            }
        }

        public void FungusGlowRingAI(Vector2 point)
        {
            float moveSpeed = 4f;
            if (moveSpeed == 0f || NPC.Center == point) return; //don't move if you have no move speed
            float velMultiplier = 1f;
            Vector2 dist = point - NPC.Center;
            float length = dist == Vector2.Zero ? 0f : dist.Length();
            if (length < moveSpeed)
            {
                velMultiplier = MathHelper.Lerp(0f, 1f, length / moveSpeed);
            }
            if (length < 200f)
            {
                moveSpeed *= 0.4f;
            }
            if (length < 100f)
            {
                moveSpeed *= 0.3f;
            }
            if (length < 50f)
            {
                moveSpeed *= 0.3f;
            }
            NPC.velocity = length == 0f ? Vector2.Zero : Vector2.Normalize(dist);
            NPC.velocity *= moveSpeed;
            NPC.velocity *= velMultiplier;
        }

        public int LesGo = 0;

        public void RadiantRingAI()
        {
            Player player = Main.LocalPlayer;
            Vector2 targetCenter = player.position;
            float npcSpeed = 14f;
            Vector2 velocity = targetCenter - NPC.Center;
            velocity.Normalize();
            velocity *= npcSpeed;
            NPC.velocity = velocity;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos,  Color drawColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Glow").Value;
            Texture2D texture2 = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Radiant").Value;
            Texture2D texture3 = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_PureRadiant").Value;
            Texture2D textureU = ModContent.Request<Texture2D>("MultidimensionMod/NPCs/Bosses/FeudalFungus/Umos").Value;
            Texture2D textureUG = ModContent.Request<Texture2D>("MultidimensionMod/NPCs/Bosses/FeudalFungus/Umos_Glow").Value;
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if (UmosDefeat)
            {
                spriteBatch.Draw(textureU, NPC.Center + new Vector2(0f, -14f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            }
            else
                spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, NPC.Center + new Vector2(0f, -14f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            if (Desperate && !UmosDefeat)
            {
                spriteBatch.Draw(texture3, NPC.Center + new Vector2(0f, -14f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            }
            else if (UmosMode && !Desperate && !UmosDefeat)
            {
                spriteBatch.Draw(texture2, NPC.Center + new Vector2(0f, -14f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            }
            else if (UmosDefeat)
            {
                spriteBatch.Draw(textureUG, NPC.Center + new Vector2(0f, -14f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            }
            else
                spriteBatch.Draw(texture, NPC.Center + new Vector2(0f, -14f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);

            return false;
        }
    }   
}


