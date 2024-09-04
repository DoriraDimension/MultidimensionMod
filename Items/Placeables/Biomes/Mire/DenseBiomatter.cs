﻿using MultidimensionMod.Tiles.Biomes.Mire;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Biomes.Mire
{
    public class DenseBiomatter : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = ItemRarityID.LightPurple;
            Item.createTile = ModContent.TileType<DenseBiomatterPlaced>();
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Depthstone");
            //Tooltip.SetDefault("Dank");
        }
    }
}