﻿using MultidimensionMod.Tiles.Furniture.VoidMatter;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.VoidMatter
{
	public class VoidMatterClock : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Void Matter Clock");
			// Tooltip.SetDefault("Does time even matter in timeless space?");
		}

		public override void SetDefaults()
		{
			Item.width = 44;
			Item.height = 46;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(silver: 15);
			Item.createTile = ModContent.TileType<VoidMatterClockPlaced>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<VoidMatterMass>(), 10)
			.AddRecipeGroup("IronBar", 3)
			.AddIngredient(ItemID.Glass, 6)
			.Register();
		}
	}
}