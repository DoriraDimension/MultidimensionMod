using MultidimensionMod.Tiles.Biomes.Harmony;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Biomes.Harmony
{
    public class TerraCrystalItem : ModItem
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
            Item.useStyle = 1;
            Item.rare = 1;
            Item.value = Terraria.Item.sellPrice(0, 0, 8, 0);
            Item.consumable = true;
            Item.createTile = ModContent.TileType<TerraCrystalPlaced>();
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Crystal of Order");
            //Tooltip.SetDefault(@"A piece of the Terrarium, said to be the shed shell of a Greater One,
            //it radiates pure order energy.");
        }
    }
}