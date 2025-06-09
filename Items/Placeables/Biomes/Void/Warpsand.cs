using MultidimensionMod.Tiles.Biomes.Mire;
using Terraria.ModLoader;
using Terraria.ID;
using MultidimensionMod.Tiles.Biomes.Void;

namespace MultidimensionMod.Items.Placeables.Biomes.Void
{
    public class Warpsand : ModItem
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
            Item.createTile = ModContent.TileType<WarpsandPlaced>();
        }

        public override void SetStaticDefaults()
        {

        }
    }
}