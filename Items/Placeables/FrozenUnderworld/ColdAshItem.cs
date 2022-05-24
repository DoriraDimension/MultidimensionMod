﻿using MultidimensionMod.Tiles.FrozenUnderworld;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.FrozenUnderworld
{
	public class ColdAshItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cold Ash");
			Tooltip.SetDefault("Normal underworld ash that was cooled down by icy winds.");
		}

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<ColdAsh>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.AshBlock)
			.AddTile(TileID.IceMachine)
			.Register();
		}
	}
}
