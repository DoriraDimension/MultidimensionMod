using MultidimensionMod.Tiles.Ores;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Biomes.Mire
{
    public class Abyssium : ModItem
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
            Item.rare = ItemRarityID.Blue;
            Item.value = Terraria.Item.sellPrice(0, 0, 8, 0);
            Item.consumable = true;
            Item.createTile = ModContent.TileType<AbyssiumOrePlaced>();
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Dreadsoil Ore");
            //Tooltip.SetDefault("An especially soft metal consisting of fossilized remains that sank into the Shrouded Mire fused with metallic minerals within the soil,\n it is imbued with a dreadful presence.\nIt is in some parts known as Cursed Earth.");
        }
    }
}
