using MultidimensionMod.Tiles.Biomes.Mire;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using MultidimensionMod.Tiles.Biomes.Void;

namespace MultidimensionMod.Items.Placeables.Biomes.Void
{
    public class DustSnow : ModItem
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
            Item.createTile = ModContent.TileType<DustSnowPlaced>();
        }

        public override void SetStaticDefaults()
        {

        }
    }
}