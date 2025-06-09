using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using MultidimensionMod.Tiles.Biomes.Void;

namespace MultidimensionMod.Items.Placeables.Biomes.Void
{
    public class Doomstone : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Charged Doomstone");
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
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Red;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<DoomstonePlaced>();
        }
    }
}
