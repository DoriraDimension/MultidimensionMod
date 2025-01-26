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
using MultidimensionMod.Items.Potions.Food;
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
using MultidimensionMod.Items.Weapons.Melee.Boomerangs;
using MultidimensionMod.Items.Weapons.Ranged.Bows;
using static Terraria.GameContent.Animations.IL_Actions.Sprites;
using Terraria.Graphics.CameraModifiers;
using MultidimensionMod.Biomes;

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
            Main.npcFrameCount[NPC.type] = 1;
            NPCID.Sets.TrailCacheLength[NPC.type] = 8;
            NPCID.Sets.TrailingMode[NPC.type] = 0;
            var value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Position = new Vector2(0, 40),
                PortraitPositionYOverride = 20
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 3500;   //boss life
            NPC.damage = 24;  //boss damage
            NPC.defense = 10;    //boss defense
            NPC.knockBackResist = 0f;
            NPC.value = Item.sellPrice(0, 1, 50, 0);
            NPC.aiStyle = -1;
            NPC.width = 74;
            NPC.height = 150;
            NPC.npcSlots = 10f;
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
            SpawnModBiomes = new int[1] { ModContent.GetInstance<MushStoryBiome>().Type };
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
            int petChance = 10;
            if (Main.masterMode)
            {
                petChance = 4;
            }
            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<GlowingMushmatter>(), 1, 5, 10));
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<GlowshroomSoul>()));
            NPCloot.Add(ItemDropRule.BossBag(ModContent.ItemType<FungusBag>()));
            NPCloot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<FungusRelic>()));
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<FungusTrophy>(), 10));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SusGlowsporeBag>(), petChance));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<GlowingMushiumBar>(), 5, 1, 2));
            notExpertRule.OnSuccess(ItemDropRule.OneFromOptions(1, ModContent.ItemType<UmosShower>(), ModContent.ItemType<RadianceTalisman>()));
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

        public override bool CheckDead()
        {
            if (AIState == ActionState.AwayWithThee)
                return true;
            else
            {
                NPC.life = 1;
                AIState = ActionState.AwayWithThee;
                if (Main.netMode == NetmodeID.Server && NPC.whoAmI < Main.maxNPCs)
                    NetMessage.SendData(MessageID.SyncNPC, number: NPC.whoAmI);
                return false;
            }
        }

        public void SmoothFrames()//Consider running this only during the intro
        {
            if(ActualArmFrame<ArmFrame){
                ActualArmFrame++;
            }
            if(ActualArmFrame>ArmFrame){
                ActualArmFrame--;
            }
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
        public float ShakeStrength = 0f;
        public float ShakeFrames = 0f;
        public float FrameTimer=0; //THERE MUST BE MORE COUNTERS

        public override void AI()
        {
            FrameTimer++;
            if (FrameTimer % 5 == 0)
                SmoothFrames();
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
            if (NPC.life >= NPC.lifeMax / 2)
            {
                Lighting.AddLight(NPC.Center, 0, 0, (255 - NPC.alpha) * 0.30f / 255f);
            }
            if (!Desperate && UmosMode)
            {
                Lighting.AddLight(NPC.Center, 0, (255 - NPC.alpha) * 0.13f / 160, (255 - NPC.alpha) * 0.30f / 255f);
            }
            if (NPC.life <= NPC.lifeMax / 2 && !UmosMode)
            {
                AIState = ActionState.UmosTransition;
            }
            if (NPC.life <= NPC.lifeMax / 10 && NPC.life != 1 && Main.expertMode)
            {
                AIState = ActionState.Radiance;
                NPC.netUpdate = true;
            }
            switch (AIState)
            {
                case ActionState.TPose:
                    if (!Main.dedServ)
                        Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Silence");
                    NPC.Center = player.Center + new Vector2(0, -200);
                    Waking++;
                    if (!DownedSystem.seenFeudalIntro)
                    {
                        if (ShakeStrength >= 3f)
                        {
                            ShakeStrength = 3f;
                        }
                        if (ShakeFrames >= 4f)
                        {
                            ShakeFrames = 4f;
                        }
                        if (Waking == 120)
                        {
                            int i = CombatText.NewText(NPC.getRect(), MDColors.FeudalBlue, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Spawn1"), false, false);
                            Main.combatText[i].lifeTime = 60;
                            HeadFrame = 0;
                            ArmFrame = 1;
                        }
                        if (Waking == 140)
                        {
                            HeadFrame = 1;
                        }
                        if (Waking == 180)
                        {
                            HeadFrame = 2;
                            int i = CombatText.NewText(NPC.getRect(), MDColors.FeudalBlue, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Spawn2"), false, false);
                            Main.combatText[i].lifeTime = 90;
                        }
                        if (Waking == 300)
                        {
                            HeadFrame = 3;
                            ArmFrame = 3;
                            int i = CombatText.NewText(NPC.getRect(), MDColors.FeudalBlue, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Spawn3"), false, false);
                            Main.combatText[i].lifeTime = 120;
                        }
                        if (Waking == 420)
                        {
                            HeadFrame = 4;
                            int i = CombatText.NewText(NPC.getRect(), MDColors.FeudalBlue, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Spawn4"), false, false);
                            Main.combatText[i].lifeTime = 60;
                        }
                        if (Waking == 540)
                        {
                            HeadFrame = 4;
                            ArmFrame = 1;
                            int i = CombatText.NewText(NPC.getRect(), MDColors.FeudalBlue, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Spawn5"), false, false);
                            Main.combatText[i].lifeTime = 120;
                        }
                        if (Waking == 600)
                        {
                            HeadFrame = 0;
                            ActualArmFrame = 8;
                            ArmFrame = 9;
                        }
                        if (Waking >= 600 && Waking <= 800)
                        {
                            if (!ModContent.GetInstance<MDConfig>().ScreenshakeDisable)
                            {
                                ShakeStrength += 0.0020f;
                                ShakeFrames += 0.020f;
                                PunchCameraModifier modifier = new PunchCameraModifier(NPC.Center, (Main.rand.NextFloat() * ((float)Math.PI * 2f)).ToRotationVector2(), ShakeFrames, ShakeStrength, 20, 500f, FullName);
                                Main.instance.CameraModifiers.Add(modifier);
                            }
                        }
                        if (Waking == 800)
                        {
                            HeadFrame = 5;
                            ActualArmFrame = 4;
                            ArmFrame = 5;
                            int i = CombatText.NewText(NPC.getRect(), MDColors.FeudalBlue, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Spawn6"), false, false);
                            Main.combatText[i].lifeTime = 120;
                            SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/RoyalRadianceScream"), NPC.position);
                        }
                        if (Waking == 920)
                        {
                            if (ModContent.GetInstance<MDConfig>().ALTitleCards)
                            {
                                if (!TitleCard)
                                {
                                    if (!Main.dedServ)
                                    {
                                        MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Feudal.Name"), 60, 90, 1.0f, 0, MDColors.FeudalBlue, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Feudal.Title"));
                                        TitleCard = true;
                                    }
                                }
                            }
                            AIState = ActionState.Hovering;
                            NPC.dontTakeDamage = false;
                            NPC.netUpdate = true;
                            Waking = 0;
                            if (!DownedSystem.seenFeudalIntro)
                            {
                                DownedSystem.seenFeudalIntro = true;
                                if (Main.netMode == NetmodeID.Server)
                                {
                                    NetMessage.SendData(MessageID.WorldData);
                                }
                            }
                            if (!Main.dedServ)
                                Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Fungus");
                        }
                    }
                    else
                    {
                        if (Waking == 60)
                        {
                            HeadFrame = 0;
                            ArmFrame = 1;
                        }
                        if (Waking == 90)
                        {
                            HeadFrame = 1;
                        }
                        if (Waking == 120)
                        {
                            HeadFrame = 2;
                        }
                        if (Waking == 180)
                        {
                            EmoteBubble.NewBubble(1, new WorldUIAnchor(NPC), 120);
                            HeadFrame = 7;
                            int i = CombatText.NewText(NPC.getRect(), Color.LimeGreen, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.DefeatSpawn"), false, false);
                            Main.combatText[i].lifeTime = 120;
                        }
                        if (Waking == 240)
                        {
                            if (ModContent.GetInstance<MDConfig>().ALTitleCards)
                            {
                                if (!TitleCardPhase2)
                                {
                                    if (!Main.dedServ)
                                    {
                                        MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Feudal.Name2"), 30, 60, 1.0f, 0, Color.Cyan, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Feudal.Title2"));
                                        TitleCardPhase2 = true;
                                    }
                                }
                            }
                            AIState = ActionState.Hovering;
                            NPC.dontTakeDamage = false;
                            NPC.netUpdate = true;
                            Waking = 0;
                            if (!Main.dedServ)
                                Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Fungus");
                        }
                    }
                    break;
                case ActionState.Hovering:
                    NPC.noTileCollide = true;
                    if (UmosMode)
                    {
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
                        if (AISwitch == 50)
                        {
                            ArmFrame = 3;
                            HeadFrame = 4;
                        }
                        if (AISwitch == 150)
                        {
                            ArmFrame = 5;
                            HeadFrame = 5;
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
                        NPC.noTileCollide = true;
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
                        if (AISwitch == 60)
                        {
                            HeadFrame = 7;
                            ArmFrame = 3;
                        }
                        if (AISwitch == 120)
                        {
                            HeadFrame = 2;
                            ArmFrame = 5;
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
                                {
                                    NPC.velocity = new Vector2(0, 0);
                                    ArmFrame = 3;
                                    HeadFrame = 8;
                                }
                                if (RingTime == 70)
                                {
                                    HeadFrame = 2;
                                    ActualArmFrame = 6;
                                    ArmFrame = 7;
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
                                    HeadFrame = 2;
                                    ArmFrame = 1;
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
                                {
                                    HeadFrame = 8;
                                    ArmFrame = 3;
                                    NPC.velocity = new Vector2(0, 0);
                                }
                                if (RingTime == 90)
                                {
                                    HeadFrame = 2;
                                    ActualArmFrame = 6;
                                    ArmFrame = 7;
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
                                    HeadFrame = 2;
                                    ActualArmFrame = 0;
                                    ArmFrame = 1;
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
                            if (DoubleFire == 90 && DoubleTimer <= 180)
                            {
                                ArmFrame = 5;
                                if (UmosMode)
                                    HeadFrame = 8;
                                else
                                    HeadFrame = 2;
                                Vector2 sped = new Vector2(0, -8);
                                if (Main.netMode != NetmodeID.MultiplayerClient)
                                {
                                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X + 80, NPC.Center.Y - 10, sped.X, sped.Y, ModContent.ProjectileType<StalkingShot>(), 55 / 3, 0);
                                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X - 80, NPC.Center.Y - 10, sped.X, sped.Y, ModContent.ProjectileType<StalkingShot>(), 55 / 3, 0);
                                }
                                SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Blurb"), NPC.position);
                                DoubleFire = 60;
                                NPC.netUpdate = true;
                            }
                            if (DoubleTimer == 180)
                            {
                                ActualArmFrame = 0;
                                ArmFrame = 1;
                            }
                            if (DoubleTimer == 300)
                            {
                                HeadFrame = 2;
                                AIState = ActionState.Hovering;
                                DoubleTimer = 0;
                                DoubleFire = 0;
                                NPC.netUpdate = true;
                            }
                            break;
                        case 2: //Sentries (Summons a glowing sentry that empowers the boss, only two can be alive at once and the boost stacks. During phase 2, summons a mushroom bomb instead that explodes on death.
                            if (UmosMode)
                            {
                                if (SentryTimer > 60)
                                {
                                    ArmFrame = 3;
                                    HeadFrame = 8;
                                }
                                SentryTimer++;
                                FungusHoverAI(new Vector2(player.Center.X, player.Center.Y - 200), 0.3f);
                                if (SentryTimer == 60)
                                {
                                    ArmFrame = 9;
                                    HeadFrame = 7;
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
                                    ArmFrame = 1;
                                    AIState = ActionState.Hovering;
                                    SentryTimer = 0;
                                    NPC.netUpdate = true;
                                }
                            }
                            else
                            {
                                if (NPC.CountNPCS(ModContent.NPCType<GlowSentry>()) < 2)
                                {
                                    if (SentryTimer > 60)
                                    {
                                        ArmFrame = 3;
                                        HeadFrame = 8;
                                    }
                                    SentryTimer++;
                                    FungusHoverAI(new Vector2(player.Center.X, player.Center.Y - 200), 0.3f);
                                    if (SentryTimer == 60)
                                    {
                                        ArmFrame = 9;
                                        HeadFrame = 7;
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
                                    if (SentryTimer == 80)
                                    {
                                        ArmFrame = 1;
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
                                FungusHoverAI(new Vector2(player.Center.X, player.Center.Y - 200), 0.3f);
                                DoubleTimer++;
                                DoubleFire++;
                                if (DoubleFire == 90)
                                {
                                    SoundEngine.PlaySound(SoundID.Item4, NPC.position);
                                    ArmFrame = 9;
                                    HeadFrame = 7;
                                    if (Main.netMode != NetmodeID.MultiplayerClient)
                                    {
                                        Projectile.NewProjectile(NPC.GetSource_FromAI(), player.Center.X - 500, player.Center.Y - 10, 0, 0, ModContent.ProjectileType<MushWave>(), 40 / 3, 0);
                                        Projectile.NewProjectile(NPC.GetSource_FromAI(), player.Center.X + 500, player.Center.Y - 10, 0, 0, ModContent.ProjectileType<MushWave>(), 40 / 3, 0);
                                    }
                                }
                                if (DoubleFire == 180)
                                {
                                    SoundEngine.PlaySound(SoundID.Item4, NPC.position);
                                    ArmFrame = 5;
                                    HeadFrame = 4;
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
                                    ArmFrame = 7;
                                    HeadFrame = 5;
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
                                    NPC.velocity.Y = 0;
                                    ArmFrame = 3;
                                    HeadFrame = 8;
                                }
                                if (ImFalling == 120)
                                {
                                    HeadFrame = 0;
                                    ArmFrame = 1;
                                    NPC.velocity.Y = 20;
                                    NPC.netUpdate = true;
                                }
                                if ((player.Center.Y - NPC.Center.Y) <= 30)
                                {
                                    NPC.noTileCollide = false;
                                    ActualArmFrame = 6;
                                    ArmFrame = 7;
                                    HeadFrame = 7;
                                }
                                if (BaseAI.HitTileOnSide(NPC, 3))
                                {
                                    //NPC.frame.Y = 150 * 4;
                                    IHaveLanded++;
                                    if (IHaveLanded == 1)
                                    {
                                        if (!ModContent.GetInstance<MDConfig>().ScreenshakeDisable)
                                        {
                                            PunchCameraModifier modifier = new PunchCameraModifier(NPC.Center, (Main.rand.NextFloat() * ((float)Math.PI * 2f)).ToRotationVector2(), 1f, 1f, 20, 500f, FullName);
                                            Main.instance.CameraModifiers.Add(modifier);
                                        }
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
                                    ArmFrame = 1;
                                    HeadFrame = 2;
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
                        int choice = Main.rand.Next(3);
                        if (choice == 0)
                        {
                            ActualArmFrame = 2;
                            ArmFrame = 3;
                        }
                        else if (choice == 1)
                        {
                            ActualArmFrame = 8;
                            ArmFrame = 9;
                        }
                        else if (choice == 2)
                        {
                            ActualArmFrame = 4;
                            ArmFrame = 5;
                        }
                        int choice2 = Main.rand.Next(5);
                        if (choice2 == 0)
                            HeadFrame = 1;
                        else if (choice2 == 1)
                            HeadFrame = 4;
                        else if (choice2 == 2)
                            HeadFrame = 5;
                        else if (choice2 == 3)
                            HeadFrame = 7;
                        else if (choice2 == 4)
                            HeadFrame = 8;
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
                    ActualArmFrame = 0;
                    ArmFrame = 1;
                    HeadFrame = 0;
                    NPC.velocity = new Vector2(0, 0);
                    NPC.alpha += 50;
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
                            HeadFrame = 5;
                            AISwitch = 0;
                            MakeItRain = 0;
                            FireShroom = 0;
                            RingTime = 0;
                            DoubleTimer = 0;
                            DoubleFire = 0;
                            SentryTimer = 0;
                            ImFalling = 0;
                            IHaveLanded = 0;
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
                        if (DragonballPowerUpSequence == 120)
                        {
                            int i = CombatText.NewText(NPC.getRect(), MDColors.FeudalBlue, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Transition1"), false, false);
                            Main.combatText[i].lifeTime = 120;
                            ActualArmFrame = 4;
                            ArmFrame = 5;
                            HeadFrame = 7;
                        }
                        if (DragonballPowerUpSequence == 300)
                        {
                            int i = CombatText.NewText(NPC.getRect(), Color.LimeGreen, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Transition2"), false, false);
                            Main.combatText[i].lifeTime = 120;
                            ActualArmFrame = 2;
                            ArmFrame = 3;
                            HeadFrame = 6;
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
                            ActualArmFrame = 0;
                            ArmFrame = 1;
                        }
                        if (DragonballPowerUpSequence == 840)
                        {
                            int i = CombatText.NewText(NPC.getRect(), Color.LimeGreen, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Transition5"), false, false);
                            Main.combatText[i].lifeTime = 120;
                            HeadFrame = 7;
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
                            HeadFrame = 3;
                        }
                        if (DragonballPowerUpSequence == 1200)
                        {
                            HeadFrame = 5;
                            UmosMode = true;
                            SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/RoyalRadianceScream"), NPC.position);
                        }
                        if (DragonballPowerUpSequence == 1201)
                        {
                            NPC.dontTakeDamage = false;
                            if (!Main.dedServ)
                                Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Fungus");
                            AISwitch = 0;
                            MakeItRain = 0;
                            FireShroom = 0;
                            RingTime = 0;
                            DoubleTimer = 0;
                            DoubleFire = 0;
                            SentryTimer = 0;
                            ImFalling = 0;
                            IHaveLanded = 0;
                            DragonballPowerUpSequence = 0;
                            AIState = ActionState.Hovering;
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
                    //Main.npcFrameCount[NPC.type] = 5;
                    NPC.velocity.X = 0;
                    NPC.velocity.Y = 0;
                    NPC.dontTakeDamage = true;
                    UmosDefeat = true;
                    Away++;
                    NPC.ai[1]++;
                    if (Away == 120)
                    {
                        Gore.NewGore(NPC.GetSource_FromThis(), NPC.position + new Vector2(0, -40), NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/FeudalGore1").Type, 1);
                        Gore.NewGore(NPC.GetSource_FromThis(), NPC.position + new Vector2(8, -40), NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/FeudalGore2").Type, 1);
                        Gore.NewGore(NPC.GetSource_FromThis(), NPC.position + new Vector2(-13, -40), NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/FeudalGore2").Type, 1);
                        Gore.NewGore(NPC.GetSource_FromThis(), NPC.position + new Vector2(17, 36), NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/FeudalGore3").Type, 1);
                        Gore.NewGore(NPC.GetSource_FromThis(), NPC.position + new Vector2(-10, 45), NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/FeudalGore3").Type, 1);
                    }
                    if (Away < 120)
                    {
                        ActualArmFrame = 2;
                        ArmFrame = 3;
                        HeadFrame = 0;
                    }
                    if (Away >= 120 && Away < 180)
                    {
                        if (HeadFrame < 9)
                            HeadFrame = 9;
                        if (++H >= 8)
                        {
                            H = 0;
                            HeadFrame++;
                            if (HeadFrame >= 11)
                                HeadFrame = 11;
                        }
                    }
                    if (DownedSystem.downedFungus)
                    {
                        if (Away == 180)
                        {
                            ActualArmFrame = 8;
                            ArmFrame = 9;
                        }
                        if (Away == 220)
                        {
                            int i2 = CombatText.NewText(NPC.getRect(), Color.LimeGreen, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Defeat3"), false, false);
                            Main.combatText[i2].lifeTime = 100;
                            ActualArmFrame = 8;
                            ArmFrame = 9;
                        }
                        if (Away >= 220)
                        {
                            ActualArmFrame = 4;
                            ArmFrame = 5;
                        }
                    }
                    else
                    {
                        if (Away == 180)
                        {
                            int i2 = CombatText.NewText(NPC.getRect(), Color.LimeGreen, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Defeat1"), false, false);
                            Main.combatText[i2].lifeTime = 30;
                            ActualArmFrame = 8;
                            ArmFrame = 9;
                        }
                        if (Away == 260)
                        {
                            int i2 = CombatText.NewText(NPC.getRect(), Color.LimeGreen, Language.GetTextValue("Mods.MultidimensionMod.NPCs.FeudalFungus.Defeat2"), false, false);
                            Main.combatText[i2].lifeTime = 60;
                            ActualArmFrame = 4;
                            ArmFrame = 5;
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
                        //Main.npcFrameCount[NPC.type] = 13;
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

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Glow").Value;
            Texture2D texture2 = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Radiant").Value;
            Texture2D texture3 = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_PureRadiant").Value;
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, NPC.Center + new Vector2(0f, -14f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            spriteBatch.Draw(texture, NPC.Center + new Vector2(0f, -14f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            if (Desperate && !UmosDefeat)
            {
                spriteBatch.Draw(texture3, NPC.Center + new Vector2(0f, -14f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            }
            else if (UmosMode && !Desperate && !UmosDefeat)
            {
                spriteBatch.Draw(texture2, NPC.Center + new Vector2(0f, -14f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            }

            return false;
        }
        private int ActualArmFrame;
        private int ArmFrame;
        private int HeadFrame;
        public int A = 0;
        public int H = 0;

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D armTexture = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "Arms").Value;
            Texture2D armTexture2 = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "Arms_Radiant").Value;
            Texture2D armTexture3 = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "Arms_PureRadiant").Value;
            int armHeight = armTexture.Height / 10;
            int ay = armHeight * ActualArmFrame;
            Rectangle rect = new(0, ay, armTexture.Width, armHeight);
            Vector2 drawOrigin = new(armTexture.Width / 2, armHeight / 2);

            Texture2D headTexture = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "Head").Value;
            Texture2D headTexture2 = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "Head_Glow").Value;
            Texture2D headTexture3 = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "Head_Radiant").Value;
            Texture2D headTexture4 = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "Head_PureRadiant").Value;
            int headHeight = headTexture.Height / 12;
            int hy = headHeight * HeadFrame;
            Rectangle rect2 = new(0, hy, headTexture.Width, headHeight);
            Vector2 drawOrigin2 = new(headTexture.Width / 2, headHeight / 2);
            //Arm sprites
            Main.EntitySpriteDraw(armTexture, NPC.Center + new Vector2(0f, -14f) - screenPos, new Rectangle?(rect), drawColor, NPC.rotation, drawOrigin, NPC.scale, SpriteEffects.None, 0);
            if (Desperate && !UmosDefeat)
            {
                spriteBatch.Draw(armTexture3, NPC.Center + new Vector2(0f, -14f) - screenPos, new Rectangle?(rect), Color.White, NPC.rotation, drawOrigin, NPC.scale, SpriteEffects.None, 0);
            }
            else if (UmosMode && !Desperate && !UmosDefeat)
            {
                spriteBatch.Draw(armTexture2, NPC.Center + new Vector2(0f, -14f) - screenPos, new Rectangle?(rect), Color.White, NPC.rotation, drawOrigin, NPC.scale, SpriteEffects.None, 0);
            }
            //Head sprites
            Main.EntitySpriteDraw(headTexture, NPC.Center + new Vector2(0f, -14f) - screenPos, new Rectangle?(rect2), drawColor, NPC.rotation, drawOrigin2, NPC.scale, SpriteEffects.None, 0);
            Main.EntitySpriteDraw(headTexture2, NPC.Center + new Vector2(0f, -14f) - screenPos, new Rectangle?(rect2), Color.White, NPC.rotation, drawOrigin2, NPC.scale, SpriteEffects.None, 0);
            if (Desperate && !UmosDefeat)
            {
                spriteBatch.Draw(headTexture4, NPC.Center + new Vector2(0f, -14f) - screenPos, new Rectangle?(rect2), Color.White, NPC.rotation, drawOrigin2, NPC.scale, SpriteEffects.None, 0);
            }
            else if (UmosMode && !Desperate && !UmosDefeat)
            {
                spriteBatch.Draw(headTexture3, NPC.Center + new Vector2(0f, -14f) - screenPos, new Rectangle?(rect2), Color.White, NPC.rotation, drawOrigin2, NPC.scale, SpriteEffects.None, 0);
            }
        }
    }   
}