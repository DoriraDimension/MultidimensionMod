using MultidimensionMod.Tiles.Biomes;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Biomes
{
    public class SmolderingShaleplate : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 54;
            Item.height = 34;
            Item.maxStack = 9999;
            //Item.useTurn = true;
            //Item.autoReuse = true;
            //Item.useAnimation = 15;
            //Item.useTime = 10;
            Item.rare = ItemRarityID.Green;
            //Item.useStyle = ItemUseStyleID.Swing;
            //Item.consumable = true;
            //Item.createTile = ModContent.TileType<SmolderingShaleplatePlaced>();
        }
    }
}