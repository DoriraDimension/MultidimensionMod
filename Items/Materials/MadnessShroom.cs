using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
    public class MadnessShroom : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 15;
        }

        public override void SetDefaults()
        {
            Item.maxStack = 9999;
            Item.width = 36;
            Item.height = 38;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.rare = ItemRarityID.Green;
        }

    }
}
