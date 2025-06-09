using MultidimensionMod.Tiles.Biomes.Mire;
using Terraria.ModLoader;
using Terraria.ID;
using MultidimensionMod.Tiles.Biomes.Void;

namespace MultidimensionMod.Items.Placeables.Biomes.Void
{
    public class WarpsandHardened : ModItem
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
            Item.createTile = ModContent.TileType<WarpsandHardenedPlaced>();
        }

        public override void SetStaticDefaults()
        {

        }

    }
}