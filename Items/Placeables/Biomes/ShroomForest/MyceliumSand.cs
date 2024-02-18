using MultidimensionMod.Tiles.Biomes.ShroomForest;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.GameContent;
using System;

namespace MultidimensionMod.Items.Placeables.Biomes.ShroomForest
{
    public class MyceliumSand : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemTrader.ChlorophyteExtractinator.AddOption_OneWay(Type, 1, ItemID.SandBlock, 1);
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.DefaultToPlaceableTile(ModContent.TileType<MyceliumSandPlaced>(), 0);
        }
    }
}