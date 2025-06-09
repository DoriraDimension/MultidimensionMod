using MultidimensionMod.Tiles.Biomes.Void;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Biomes.Void
{
    public class DoomstoneB : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Doomstone");
            //Tooltip.SetDefault("");
        }

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
            Item.rare = 2;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<DoomstoneBPlaced>();
        }
    }
}
