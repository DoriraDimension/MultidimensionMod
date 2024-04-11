using MultidimensionMod.Tiles.Relics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Relics
{
    public class FungusRelic : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 52;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Master;
            Item.master = true;
            Item.value = Item.buyPrice(0, 5);
            Item.DefaultToPlaceableTile(ModContent.TileType<FungusRelicPlaced>(), 0);
        }
    }
}