using MultidimensionMod.Tiles.Biomes.Inferno;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Biomes.Inferno
{
    public class VolcanicRock : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Torchstone");
            //Tooltip.SetDefault("Warm to the touch");
        }

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
            Item.rare = ItemRarityID.Lime;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<VolcanicRockPlaced>();
        }
    }
}