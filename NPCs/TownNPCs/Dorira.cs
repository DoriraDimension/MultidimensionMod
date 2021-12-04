using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Placeables;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Items.Summons;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Weapons.Melee.Others;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items;
using MultidimensionMod.Projectiles.Ranged;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.TownNPCs
{
	[AutoloadHead]
	public class Dorira : ModNPC
	{
		public override bool Autoload(ref string name)
		{
			name = "Dorira";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dimensional God");
			Main.npcFrameCount[npc.type] = 23;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 24;
			npc.height = 50;
			npc.aiStyle = 7;
			npc.damage = 70;
			npc.defense = 777;
			npc.lifeMax = 10000000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0f;
			animationType = NPCID.Mechanic;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					foreach (Item item in player.inventory)
					{
						if (item.type == ModContent.ItemType<Dimensium>() && NPC.downedBoss1)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public override string TownNPCName()
		{
			return "Dorira";
		}

		public override string GetChat()
		{
			int Gobfuck = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
			if (Gobfuck >= 0 && Main.rand.NextBool(4))
			{
				return "I came to this dimension because I heard of dimensional anomalies and " + Main.npc[Gobfuck].GivenName + "'s money sucking service is DEFINETILY one";
			}
			int merchant = NPC.FindFirstNPC(NPCID.Merchant);
			if (merchant >= 0 && Main.rand.NextBool(4))
			{
				return "I bought one of " + Main.npc[merchant].GivenName + " 's dirt blocks, can you tell him that it doesnt work";
			}
			int BoomBoomMan = NPC.FindFirstNPC(NPCID.Demolitionist);
			if (BoomBoomMan >= 0 && Main.rand.NextBool(4))
			{
				return "When I go monster hunting, I will always buy " + Main.npc[BoomBoomMan].GivenName + "'s explosives from now on. Why I need bombs for hunting? *Insane stare*";
			}
			int PewPew = NPC.FindFirstNPC(NPCID.ArmsDealer);
			if (PewPew >= 0 && Main.rand.NextBool(4))
			{
				return "Just between us two, but I think " + Main.npc[PewPew].GivenName + " is selling illegal stuff. AMAZING";
			}
			if (Main.dayTime)
			{
				switch (Main.rand.Next(4))
				{
					case 0:
						return "Birds are singing, flowers are blooming, on days like these... I should stop with this phylosophy crap.";
					case 1:
						return "When you are going to the underworld dont run into a wall.";
					case 2:
						return "I wonder when the others will arrive.";
					case 3:
						return "serglhw3o85zhp35ognpügdmfghödfdlhgftzjmdzinhwüß046ihn";

				}
			}
			if (!Main.dayTime)
			{
				switch (Main.rand.Next(6))
				{
					case 0:
						return "Are you sleeping at night? I'm not, my motivation is fired up in the night.";
					case 1:
						return "Why are there zombies at night? Where do they come from? And why do they knock on my door? I DONT WANT TO BUY ANYTHING";
					case 2:
						return "*Glares creepily*";
					case 3:
						return "When you are going to the underworld dont run into a wall.";
					case 4:
						return "I wonder when the others will arrive.";
					case 5:
						return "serglhw3o85zhp35ognpügdmfghödfdlhgftzjmdzinhwüß046ihn";
				}
			}
			switch (Main.rand.Next(4))
			{
				case 0:
					return "When you are going to the underworld dont run into a wall.";
				case 1:
					return "Yes, I know, this is a game.";
				case 2:
					{
						return "I wonder when the others will arrive.";
					}
				default:
					return "Ugh... what?";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<DimensionalForgeItem>());
			shop.item[nextSlot].shopCustomPrice = 10;
			shop.item[nextSlot].shopSpecialCurrency = MultidimensionMod.DimensiumEuronen;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<BaitLeaf>());
			shop.item[nextSlot].shopCustomPrice = 7;
			shop.item[nextSlot].shopSpecialCurrency = MultidimensionMod.DimensiumEuronen;
			nextSlot++;
			if (NPC.downedBoss3)
            {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ArchtyrantsFace>());
				shop.item[nextSlot].shopCustomPrice = 15;
				shop.item[nextSlot].shopSpecialCurrency = MultidimensionMod.DimensiumEuronen;
				nextSlot++;
			}
			if (Main.hardMode)
            {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<UnknownEmoji>());
				shop.item[nextSlot].shopCustomPrice = 3;
				shop.item[nextSlot].shopSpecialCurrency = MultidimensionMod.DimensiumEuronen;
				nextSlot++;
			}
			if (NPC.downedPlantBoss)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<CheliaPlushiePlaceable>());
				shop.item[nextSlot].shopCustomPrice = 16;
				shop.item[nextSlot].shopSpecialCurrency = MultidimensionMod.DimensiumEuronen;
				nextSlot++;
			}
			if (NPC.downedMoonlord)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<DataMiner>());
				shop.item[nextSlot].shopCustomPrice = 40;
				shop.item[nextSlot].shopSpecialCurrency = MultidimensionMod.DimensiumEuronen;
				nextSlot++;
			}
			if (Main.LocalPlayer.HasItem(ModContent.ItemType<Shinorian>()) && Main.LocalPlayer.HasItem(ModContent.ItemType<ArchtyrantsFace>()) && !Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<WeirdStone>());
				shop.item[nextSlot].shopCustomPrice = 100;
				shop.item[nextSlot].shopSpecialCurrency = MultidimensionMod.DimensiumEuronen;
				nextSlot++;
			}
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), ModContent.ItemType<DataMiner>());
			Item.NewItem(npc.getRect(), ModContent.ItemType<EleanoraBodypillow>());
			Item.NewItem(npc.getRect(), ModContent.ItemType<EleanoraPlushie>());
			Item.NewItem(npc.getRect(), ModContent.ItemType<EleanoraPlushiePlaceable>());
			Item.NewItem(npc.getRect(), ModContent.ItemType<October1Item>());
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
			projType = ModContent.ProjectileType<BubbleBolt>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}