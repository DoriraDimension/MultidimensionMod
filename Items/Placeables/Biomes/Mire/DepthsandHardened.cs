using MultidimensionMod.Tiles.Biomes.Mire;
using Terraria.ModLoader;
using Terraria.ID;

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
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.White;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<DepthsandHardenedPlaced>(); //put your CustomBlock Tile name
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Hardened Depthsand");
        }

    }
}
