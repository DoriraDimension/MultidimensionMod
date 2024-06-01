using MultidimensionMod.Tiles.Biomes.Mire;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Biomes.Mire
{
    public class DankDepthstone : ModItem
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
            Item.consumable = true;
            Item.rare = ItemRarityID.Lime;
            Item.createTile = ModContent.TileType<DankDepthstonePlaced>();
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Depthstone");
            //Tooltip.SetDefault("Dank");
        }
    }
}