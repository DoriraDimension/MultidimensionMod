﻿using MultidimensionMod.Items.Weapons.Melee.Flails;
using MultidimensionMod.Items.Weapons.Ranged.Others;
using MultidimensionMod.Items.Weapons.Magic.Others;
using MultidimensionMod.Items.Weapons.Summon;
using MultidimensionMod.Items.Vanity;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Bags
{
	public class SmileyBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
			ItemID.Sets.BossBag[Type] = true;
			ItemID.Sets.PreHardmodeLikeBossBag[Type] = true;
		}

		public override void SetDefaults()
		{
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.width = 34;
			Item.height = 38;
			Item.rare = ItemRarityID.LightRed;
			Item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void ModifyItemLoot(ItemLoot Itemloot)
		{
			Itemloot.Add(ItemDropRule.Common(ModContent.ItemType<SmileyMask>(), 7));
			Itemloot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<LonelySword>(), ModContent.ItemType<DarkMatterLauncher>(), ModContent.ItemType<SmileySmile>(), ModContent.ItemType<DarkRebels>()));
			Itemloot.Add(ItemDropRule.Common(ModContent.ItemType<ShadowEmoji>()));
			Itemloot.Add(ItemDropRule.Common(ModContent.ItemType<PaleMatter>(), 1, 5, 10));
			Itemloot.Add(ItemDropRule.Common(ModContent.ItemType<CuteEmoji>(), 10));
			Itemloot.Add(ItemDropRule.FewFromOptions(1, ModContent.ItemType<LonelyWarriorsVisor>(), ModContent.ItemType<DarkCloak>()));
		}
	}
}