using Microsoft.Xna.Framework;
using MultidimensionMod.Tiles.Biomes.Void;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Biomes.Void
{
    class OroborosWood : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Oroboros Wood");
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
            Item.consumable = true;
            Item.createTile = ModContent.TileType<OroborosWoodPlaced>();
        }
    }
}
