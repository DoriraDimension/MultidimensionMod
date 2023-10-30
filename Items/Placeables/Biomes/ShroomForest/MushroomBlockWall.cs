﻿using MultidimensionMod.Walls;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace MultidimensionMod.Items.Placeables.Biomes.ShroomForest
{
    public class MushroomBlockWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 400;
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.DefaultToPlaceableWall(ModContent.WallType<MushroomBlockWallPlaced>());
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
                .AddIngredient(ModContent.ItemType<MushroomBlock>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();
        }
    }
}