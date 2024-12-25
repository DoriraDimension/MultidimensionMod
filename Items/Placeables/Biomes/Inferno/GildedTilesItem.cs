﻿using MultidimensionMod.Tiles.Biomes.Inferno;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Biomes.Inferno
{
    public class GildedTilesItem : ModItem
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
            Item.useStyle = 1;
            Item.consumable = true;
            Item.rare = ItemRarityID.Purple;
            Item.createTile = ModContent.TileType<GildedTiles>();
        }

        public override void SetStaticDefaults()
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Incinerite>(), 1)
            .AddIngredient(ItemID.RedDynastyShingles, 1)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}