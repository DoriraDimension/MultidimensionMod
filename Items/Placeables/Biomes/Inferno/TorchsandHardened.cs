using MultidimensionMod.Tiles.Biomes.Inferno;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Biomes.Inferno
{
    public class TorchsandHardened : ModItem
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
            Item.rare = 2;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<TorchsandHardenedPlaced>(); //put your CustomBlock Tile name
        }

        public override void SetStaticDefaults()
        {
          //DisplayName.SetDefault("Hardened Torchsand");
        }
    }
}
