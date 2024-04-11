using MultidimensionMod.Tiles.Relics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Relics
{
    public class MonarchRelic : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 46;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Master;
            Item.master = true;
            Item.value = Item.buyPrice(0, 5);
            Item.DefaultToPlaceableTile(ModContent.TileType<MonarchRelicPlaced>(), 0);
        }
    }
}