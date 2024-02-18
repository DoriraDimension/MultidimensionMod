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
using MultidimensionMod.Items.Quest;
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
using MultidimensionMod.Items.Mushrooms;
using MultidimensionMod.Common.Players;

namespace MultidimensionMod.NPCs.TownNPCs
{
	[AutoloadHead]
	public class Dorira : ModNPC
	{
		public const string ShopName = "Shop";

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
	            .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
	            .SetBiomeAffection<OceanBiome>(AffectionLevel.Love)
				.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Dislike)
				.SetBiomeAffection<DesertBiome>(AffectionLevel.Hate) //I am vulnurable to heat lol
				//.SetNPCAffection(ModContent.NPCType<Cultissima>(), AffectionLevel.Love)
				.SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Like) 
	            .SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Dislike) 
	            .SetNPCAffection(NPCID.BestiaryGirl, AffectionLevel.Hate)
            ;
		}

		public override void SetDefaults()
		{
			NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 24;
			NPC.height = 50;
			NPC.aiStyle = 7;
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
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Dorira")
            });
        }

        public override bool CheckDead()
        {
            MDWorld.TposeTimer = 0;
            Main.NewText("Dorira's mind got trapped in the cosmos.", Color.Red.R, Color.Red.G, Color.Red.B);
            SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Glitch"));
            NPC.SetDefaults(ModContent.NPCType<DoriraTpose>());
            NPC.life = 1;

            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.WorldData);

            return false;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
		{
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
				"Dorira"
			};
		}

		public override string GetChat()
		{
			Player player = Main.LocalPlayer;
			WeightedRandom<string> chat = new WeightedRandom<string>();
			int Gobfuck = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
			int BoomBoomMan = NPC.FindFirstNPC(NPCID.Demolitionist);
			int WrenchWoman = NPC.FindFirstNPC(NPCID.Mechanic);
			if (Gobfuck >= 0 && Main.rand.NextBool(4))
			{
				chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.GoblinDialogue", Main.npc[Gobfuck].GivenName));
			}
			if (BoomBoomMan >= 0 && Main.rand.NextBool(4))
			{
				chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.DemolitionistDialogue", Main.npc[BoomBoomMan].GivenName));
			}
			if (WrenchWoman >= 0 && Main.rand.NextBool(4))
			{
				chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.MechanicDialogue", Main.npc[WrenchWoman].GivenName));
			}
            if (Main.rand.NextBool(8))
            {
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.MushroomDialogue"));
            }
            if (Main.hardMode)
            {
				chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.GenericHardmodeDialogue1"));
			}
			chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.GenericDialogue1"));
			chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.GenericDialogue2"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.GenericDialogue4"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.GenericDialogue5"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.GenericDialogue6"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.GenericDialogue7"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.GenericDialogue8"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.GenericDialogue9"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.GenericDialogue10"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.GenericDialogue11"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.GenericDialogue12"));
            if (NPC.downedBoss2)
            {
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.GenericDialogue3"));
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
							&& player.GetModPlayer<MDPlayer>().MonarchHeart
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
						if (MDQuests.DoriraQuests == 0)
						{
							chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.CassieStart"));
							int teamStar = player.FindItem(ModContent.ItemType<TeamStar>());
							if (teamStar >= 0)
							{
								player.inventory[teamStar].stack--;
								if (player.inventory[teamStar].stack <= 0)
								{
									player.inventory[teamStar] = new Item();
									player.QuickSpawnItem(source, ModContent.ItemType<Cassiopeia>(), 1);
									Main.npcChatText = CassieDialogue();
									MDQuests.DoriraQuests++;
									NPC.SetEventFlagCleared(ref MDQuests.CassieQuest, -1);
									if (Main.netMode != NetmodeID.SinglePlayer)
									{
										NetMessage.SendData(MessageID.WorldData);
									}
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
			chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.ColdHellHelp"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.DimensiumHelp"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.KingsCapHelp"));
            if (Main.rand.NextBool(100))
            {
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.TouchGrassHelp"));
            }
            return chat;
		}

		public static string QuestDialogue()
        {
			WeightedRandom<string> chat = new(Main.rand);
			if (MDQuests.DoriraQuests == 0)
            {
				chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.CassieQuestStart"));
			}
			return chat;
		}

		public static string CassieDialogue()
        {
			WeightedRandom<string> chat = new(Main.rand);
			chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.CassieQuestClear"));
			return chat;
		}

		public override void AddShops()
		{
			var downedSmiley = new Condition("Conditions.DownedSmiley", () => DownedSystem.downedSmiley);
			var npcShop = new NPCShop(Type, ShopName)
			.Add(new Item(ModContent.ItemType<DimensionalForgeItem>()) { shopCustomPrice = 10, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen })
			.Add(new Item(ModContent.ItemType<IronUndies>()) { shopCustomPrice = 5, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen })
			.Add(new Item(ModContent.ItemType<BaitLeaf>()) { shopCustomPrice = 7, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen })
			.Add(new Item(ModContent.ItemType<ArchtyrantsFace>()) { shopCustomPrice = 15, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen }, Condition.DownedSkeletron)
			.Add(new Item(ModContent.ItemType<UnknownEmoji>()) { shopCustomPrice = 3, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen }, downedSmiley)
			.Add(new Item(ModContent.ItemType<CheliaPlushie>()) { shopCustomPrice = 16, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen }, Condition.DownedPlantera)
			.Add(new Item(ModContent.ItemType<DataMiner>()) { shopCustomPrice = 40, shopSpecialCurrency = MultidimensionMod.DimensiumEuronen }, Condition.DownedMoonLord);
			npcShop.Register();
		}

		public override bool CanGoToStatue(bool toKingStatue)
		{
			return false;
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 70;
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