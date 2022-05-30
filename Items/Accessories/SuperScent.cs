﻿using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class SuperScent : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Super Scent");
			Tooltip.SetDefault("The combination of stinky paste and a aromatic Leaf created a scent that smells, to say it nicely, interesting.\nIncreases minion damage by 6% and gives +1 minion slot.\nRub it onto your skin to smell worse than the human mind can comprehend");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 36;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 14);
			Item.rare = ItemRarityID.Orange;
			Item.buffType = (BuffID.Stinky);
			Item.buffTime = 28800;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Summon) += 0.06f;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<StinkyPaste>())
			.AddIngredient(ModContent.ItemType<BaitLeaf>())
			.AddIngredient(ItemID.JungleSpores, 5)
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 3)
			.AddTile(18)
			.Register();
		}
	}
}