using MultidimensionMod.Rarities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class DimensionalForgeItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Dimensional Forge");
			// Tooltip.SetDefault("The forge of the dimensional god, it is able to craft Items with Dimensium.\nIs capable of transmutation, needs Dimensium as fuel.");
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 20;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ModContent.RarityType<DoriraRarity>();
			Item.createTile = ModContent.TileType<Tiles.DimensionalForge>();
		}
	}
}