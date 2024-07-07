﻿using MultidimensionMod.Tiles.Biomes.Mire;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Biomes.Mire
{
    public class Permafrost : ModItem
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
            Item.rare = ItemRarityID.White;
            Item.value = 0;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<PermafrostPlaced>();
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Volcanic Ash");
        }
    }
}