﻿using MultidimensionMod.Tiles;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class RubyPlushiePlaceable : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ruby Plushie (placeable)");
			Tooltip.SetDefault("A plushie shaped like a catgirl, it is weirdly warm.");
		}

		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 60;
			Item.maxStack = 1;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Red;
			Item.createTile = ModContent.TileType<RubyPlushiePlaced>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.FragmentSolar, 10)
			.AddIngredient(ItemID.Silk, 15)
			.AddIngredient(ItemID.SoulofLight, 5)
			.AddTile(134)
			.Register();
		}
	}
}