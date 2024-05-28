using MultidimensionMod.Tiles.Biomes.Mire;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Biomes.Mire
{
    public class DepthsandHardened : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.rare = 0;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<DepthsandHardenedPlaced>(); //put your CustomBlock Tile name
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Hardened Depthsand");
        }

    }
}
