using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Mushrooms
{
    public class Pink : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Pink Alchemical Mushroom");
            //Tooltip.SetDefault(@"It smells weird");
        }
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 30;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 50, 0);
        }
    }
}