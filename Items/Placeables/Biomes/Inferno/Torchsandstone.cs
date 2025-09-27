using MultidimensionMod.Tiles.Biomes.Inferno;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Biomes.Inferno
{
    public class Torchsandstone : ModItem
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
            Item.rare = ItemRarityID.Green;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<TorchsandstonePlaced>(); //put your CustomBlock Tile name
        }

        public override void SetStaticDefaults()
        {
          //DisplayName.SetDefault("Torchsandstone");
        }

    }
}
