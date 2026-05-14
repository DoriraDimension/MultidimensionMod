using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MultidimensionMod.Tiles.Plushies;
using MultidimensionMod.Rarities;

namespace MultidimensionMod.Items.Placeables.Plushies
{
    public class CultissimaPlushie : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 56;
            Item.maxStack = 1;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = ModContent.RarityType<DeepGreen>();
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.createTile = ModContent.TileType<CultissimaPlushiePlaced>();
        }
    }
}