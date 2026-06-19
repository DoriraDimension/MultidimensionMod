using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Placeables;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Items.Summons;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Weapons.Melee.Others;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Common.Systems;
using MultidimensionMod.Common.Globals;
using MultidimensionMod.Projectiles.Ranged;
//using MultidimensionMod.Items.Quest;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.Personalities;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.Audio;
using MultidimensionMod.Items.Materials.Mushrooms;
using MultidimensionMod.Common.Players;
using MultidimensionMod.Common.Globals.NPCs;
using MultidimensionMod.Items.Placeables.Plushies;

namespace MultidimensionMod.NPCs.TownNPCs
{
	[AutoloadHead]
	public class Admin : ModNPC
	{
		public const string ShopName = "Shop";


        /*public override void ModifyActiveShop(string shopName, Item[] items)
        {
        }*/
        public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 23;
			NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
			NPCID.Sets.AttackFrameCount[NPC.type] = 4;
			NPCID.Sets.DangerDetectRange[NPC.type] = 700;
			NPCID.Sets.AttackType[NPC.type] = 0;
			NPCID.Sets.AttackTime[NPC.type] = 90;
			NPCID.Sets.AttackAverageChance[NPC.type] = 30;
			NPCID.Sets.HatOffsetY[NPC.type] = 4;
			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Velocity = 1f
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
			NPC.Happiness
	            .SetBiomeAffection<ForestBiome>(AffectionLevel.Love)
	            .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Like)
				.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike)
				.SetBiomeAffection<HallowBiome>(AffectionLevel.Hate)
				//.SetNPCAffection(ModContent.NPCType<Cultissima>(), AffectionLevel.Love)
				.SetNPCAffection(NPCID.Mechanic, AffectionLevel.Like) 
	            .SetNPCAffection(NPCID.Wizard, AffectionLevel.Dislike) 
	            .SetNPCAffection(NPCID.Cyborg, AffectionLevel.Hate)
            ;
		}

		public override void SetDefaults()
		{
			NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 24;
			NPC.height = 50;
			NPC.aiStyle = NPCAIStyleID.Passive;
			NPC.damage = 27;
			NPC.defense = 17;
			NPC.lifeMax = 3007;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0f;
			AnimationType = NPCID.Mechanic;
		}

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Admin")
            });
        }

        public override bool CheckDead()
        {
            MDWorld.TposeTimer = 0;
            Main.NewText("John God's mind got trapped in the cosmos.", Color.Red.R, Color.Red.G, Color.Red.B);
            SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Glitch"));
            NPC.SetDefaults(ModContent.NPCType<AdminTpose>());
            NPC.life = 1;

            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.WorldData);

            return false;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
		{
            if (TownNPCRespawnSystem.metAdmin)
            {
                return true;
            }
            for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					foreach (Item item in player.inventory)
					{
						if (item.type == ModContent.ItemType<Dimensium>())
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public override List<string> SetNPCNameList()
		{
			return new List<string>() {
				"John God"
			};
		}

		public override string GetChat()
		{
			Player player = Main.LocalPlayer;
			WeightedRandom<string> chat = new WeightedRandom<string>();
            if (player.name == "John God")
            {
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.ImposterDialogue"));
                player.AddBuff(BuffID.Weak, 24000);
                player.AddBuff(BuffID.BrokenArmor, 24000);
                player.AddBuff(BuffID.Slow, 24000);
                player.name = "Kevin";
            }
			else
			{
                int Gobfuck = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
                int BoomBoomMan = NPC.FindFirstNPC(NPCID.Demolitionist);
                if (Gobfuck >= 0 && Main.rand.NextBool(4))
                {
                    chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.GoblinDialogue", Main.npc[Gobfuck].GivenName));
                }
                if (BoomBoomMan >= 0 && Main.rand.NextBool(4))
                {
                    chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.DemolitionistDialogue", Main.npc[BoomBoomMan].GivenName));
                }
                if (Main.rand.NextBool(8))
                {
                    chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.MushroomDialogue"));
                }
                if (Main.hardMode)
                {
                    chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.GenericHardmodeDialogue1"));
                }
                if (MDQuests.AdminQuests >= 1)
                {
                    chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.SerpentAscendDialogue"));
                }
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.GenericDialogue1"));
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.GenericDialogue2"));
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.GenericDialogue4"));
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.GenericDialogue5"));
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.GenericDialogue6"));
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.GenericDialogue7"));
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.GenericDialogue8"));
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.GenericDialogue9"));
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.GenericDialogue10"));
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.GenericDialogue11"));
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.GenericDialogue12"));
                if (NPC.downedBoss2)
                {
                    chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.GenericDialogue3"));
                }
            }
            return chat;
		}

		private static int ChatNumber = 0;
		public override void SetChatButtons(ref string button, ref string button2)
		{
			Player player = Main.LocalPlayer;
			button = Language.GetTextValue("LegacyInterface.28");
			button2 = "Cycle Options";
            switch (ChatNumber)
            {
				case 0:
					button = "Shop";
					break;
				case 1:
					button = "Help";
					break;
				case 2:
					button = "Quest";
					break;
			}
        }

		public bool obtainedRealityShroom = false;

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
		{
			Player player = Main.LocalPlayer;
			WeightedRandom<string> chat = new(Main.rand);
			var source = player.GetSource_OpenItem(Type);
			if (firstButton)
			{
				switch (ChatNumber)
                {
					case 0:
						shopName = "Shop";
						if (player.HasItem(ModContent.ItemType<Red>())
							&& player.HasItem(ModContent.ItemType<Yellow>())
							&& player.HasItem(ModContent.ItemType<Orange>())
							&& player.HasItem(ModContent.ItemType<Blue>())
							&& player.HasItem(ModContent.ItemType<Brown>())
							&& player.HasItem(ModContent.ItemType<Gray>())
							&& player.HasItem(ModContent.ItemType<Green>())
							&& player.HasItem(ModContent.ItemType<Pink>())
							&& player.HasItem(ModContent.ItemType<Purple>())
							&& player.HasItem(ModContent.ItemType<Rainbow>())
							&& player.ZoneGlowshroom
						    && NPC.downedGolemBoss
							&& !obtainedRealityShroom)
						{
                            Item.NewItem(NPC.GetSource_Loot(), NPC.position, NPC.Size, ModContent.ItemType<RealityBendingShroom>(), 1);
							obtainedRealityShroom = true;
                        }
                        break;
                    case 1:
						Main.npcChatText = HelpDialogue();
						break;
					case 2:
						if (MDQuests.AdminQuests == 0)
						{
							chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.FlashStart"));
							int dinner = player.FindItem(ItemID.Mouse);
							int scales = player.FindItem(ModContent.ItemType<FrostScale>());
                            int dimen = player.FindItem(ModContent.ItemType<Dimensium>());
                            if (dinner >= 2 && scales >= 10 && dimen >= 5)
							{
								player.inventory[dinner].stack -= 2;
                                player.inventory[scales].stack -= 10;
                                player.inventory[dimen].stack -= 5;
								player.inventory[dinner] = new Item();
                                player.inventory[scales] = new Item();
                                player.inventory[dimen] = new Item();
                                player.QuickSpawnItem(source, ModContent.ItemType<CracklingScale>(), 1);
								Main.npcChatText = FlashDialogue();
								MDQuests.AdminQuests++;
								NPC.SetEventFlagCleared(ref MDQuests.FlashQuest, -1);
								if (Main.netMode != NetmodeID.SinglePlayer)
								{
									NetMessage.SendData(MessageID.WorldData);
								}
							}
							else
							    Main.npcChatText = QuestDialogue();
						}
						break;

				}
			}
			else
			{
				ChatNumber++;
				if (ChatNumber > 2)
					ChatNumber = 0;
			}
		}

		public static string HelpDialogue()
        {
			WeightedRandom<string> chat = new(Main.rand);
			chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.ColdHellHelp"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.DimensiumHelp"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.KingsCapHelp"));
            if (Main.rand.NextBool(100))
            {
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.TouchGrassHelp"));
            }
            return chat;
		}

		public static string QuestDialogue()
        {
			WeightedRandom<string> chat = new(Main.rand);
			if (MDQuests.AdminQuests == 0)
            {
				chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.FlashQuestStart"));
			}
			return chat;
		}

		public static string FlashDialogue()
        {
			WeightedRandom<string> chat = new(Main.rand);
			chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.FlashQuestClear"));
			return chat;
		}

		public override void AddShops()
		{
			var downedSmiley = new Condition("Conditions.DownedSmiley", () => DownedSystem.downedSmiley);
			var npcShop = new NPCShop(Type, ShopName)
			.Add(new Item(ModContent.ItemType<DimensionalForgeItem>()) { shopCustomPrice = 12, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen })
			.Add(new Item(ModContent.ItemType<IronUndies>()) { shopCustomPrice = 8, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen })
			.Add(new Item(ModContent.ItemType<BaitLeaf>()) { shopCustomPrice = 12, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen })
			.Add(new Item(ModContent.ItemType<ArchtyrantsFace>()) { shopCustomPrice = 17, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen }, Condition.DownedSkeletron)
			.Add(new Item(ModContent.ItemType<UnknownEmoji>()) { shopCustomPrice = 3, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen }, downedSmiley)
            .Add(new Item(ModContent.ItemType<AidenPlushie>()) { shopCustomPrice = 8, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen }, Condition.DownedEowOrBoc)
            .Add(new Item(ModContent.ItemType<ZetPlushie>()) { shopCustomPrice = 10, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen }, Condition.DownedSkeletron)
            .Add(new Item(ModContent.ItemType<VeronicaPlushie>()) { shopCustomPrice = 11, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen }, downedSmiley)
            .Add(new Item(ModContent.ItemType<KuruPlushie>()) { shopCustomPrice = 14, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen }, Condition.Hardmode)
            .Add(new Item(ModContent.ItemType<PsyrobnikPlushie>()) { shopCustomPrice = 16, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen }, Condition.DownedMechBossAll)
            .Add(new Item(ModContent.ItemType<CheliaPlushie>()) { shopCustomPrice = 20, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen }, Condition.DownedEmpressOfLight)
            .Add(new Item(ModContent.ItemType<KarvolisPlushie>()) { shopCustomPrice = 25, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen }, Condition.DownedMoonLord)
            .Add(new Item(ModContent.ItemType<CultissimaPlushie>()) { shopCustomPrice = 30, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen }, Condition.DownedMoonLord)
			.Add(new Item(ModContent.ItemType<DataMiner>()) { shopCustomPrice = 50, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen }, Condition.DownedMoonLord);
			npcShop.Register();
		}

		public override bool CanGoToStatue(bool toKingStatue)
		{
			return false;
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			if (Main.hardMode)
				damage = 70;
			else if (NPC.downedMoonlord)
				damage = 140;
			else
				damage = 20;
			knockback = 6f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ModContent.ProjectileType<DimensionalLightning>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 7f;
		}
	}
}