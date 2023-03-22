﻿using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Placeables;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Items.Summons;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Weapons.Melee.Others;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items;
using MultidimensionMod.Common.Systems;
using MultidimensionMod.Projectiles.Ranged;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using System.Collections.Generic;
using ReLogic.Content;

namespace MultidimensionMod.NPCs.TownNPCs
{
	[AutoloadHead]
	public class Dorira : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Dimensional God");
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
				.SetBiomeAffection<OceanBiome>(AffectionLevel.Dislike)
				.SetBiomeAffection<DesertBiome>(AffectionLevel.Hate) //I am vulnurable to heat lol
				.SetNPCAffection(NPCID.Angler, AffectionLevel.Love)
			    .SetNPCAffection(NPCID.Cyborg, AffectionLevel.Like)
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
			NPC.lifeMax = 10000;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0f;
			AnimationType = NPCID.Mechanic;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
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
				switch (Main.rand.Next(8))
				{
					case 0:
						return "Birds are singing, flowers are blooming, on days like these... I should stop with this phylosophy crap.";
					case 1:
						return "When you are going to the underworld dont run into a wall.";
					case 2:
						return "I wonder when the others will arrive.";
					case 3:
						return "serglhw3o85zhp35ognpügdmfghödfdlhgftzjmdzinhwüß046ihn";
					case 4:
						return "Some weirdo blocked my Hyperlink.";
					case 5:
						return "Do you know how FUCKING painful it is to learn programming? It's like you are thrown into a pit full of puzzles, but the puzzles are in japanese.";
					case 6:
						return "I once saw a fucking big ass serpent flying past me, ripping through the dimensions. I teleported behind him and then slapped him, but I told him that it's nothing personal.";
					case 7:
						return "nakasday";

				}
			}
			if (!Main.dayTime)
			{
				switch (Main.rand.Next(10))
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
					case 6:
						return "Some weirdo blocked my Hyperlink.";
					case 7:
						return "Do you know how FUCKING painful it is to learn programming? It's like you are thrown into a pit full of puzzles, but the puzzles are in japanese.";
					case 8:
						return "I once saw a fucking big ass serpent flying past me, ripping through the dimensions. I teleported behind him and then slapped him, but I told him that it's nothing personal.";
					case 9:
						return "nakasday";
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
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<IronUndies>());
			shop.item[nextSlot].shopCustomPrice = 5;
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
			if (DownedSystem.downedSmiley)
            {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<UnknownEmoji>());
				shop.item[nextSlot].shopCustomPrice = 3;
				shop.item[nextSlot].shopSpecialCurrency = MultidimensionMod.DimensiumEuronen;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<FishLegacy>());
				shop.item[nextSlot].shopCustomPrice = 10;
				shop.item[nextSlot].shopSpecialCurrency = MultidimensionMod.DimensiumEuronen;
				nextSlot++;
			}
			if (NPC.downedPlantBoss)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<CheliaPlushie>());
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
			if (Main.LocalPlayer.HasItem(ModContent.ItemType<Shinorian>()) || Main.LocalPlayer.HasItem(ModContent.ItemType<ArchtyrantsFace>()))
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<WeirdStone>());
				shop.item[nextSlot].shopCustomPrice = 25;
				shop.item[nextSlot].shopSpecialCurrency = MultidimensionMod.DimensiumEuronen;
				nextSlot++;
			}
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