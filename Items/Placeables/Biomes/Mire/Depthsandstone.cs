using MultidimensionMod.Tiles.Biomes.Mire;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Biomes.Mire
{
    public class Depthsandstone : ModItem
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
            Item.consumable = true;
            Item.rare = ItemRarityID.White;
            Item.createTile = ModContent.TileType<DepthsandstonePlaced>();
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Depthsandstone");
        }

    }
}
