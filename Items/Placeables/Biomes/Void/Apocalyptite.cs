using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ID;
using MultidimensionMod.Tiles.Ores;

namespace MultidimensionMod.Items.Placeables.Biomes.Void
{
    public class Apocalyptite : ModItem
    {
        public override void SetStaticDefaults()
		{
			/*DisplayName.SetDefault("Apocalyptite");
            Tooltip.SetDefault(@"A material not from this world
Found inside the islands that make up the void islands.
It is named after the inevitable, the very thing the trinity feared.
When they realized all their efforts were in vain, they gave up, on life and their try to defy fate.");*/
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
            Item.createTile = ModContent.TileType<ApocalyptitePlaced>();  
        }   
    }
}
