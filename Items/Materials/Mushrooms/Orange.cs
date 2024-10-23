using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials.Mushrooms
{
    public class Orange : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Orange Alchemical Mushroom");
            //Tooltip.SetDefault(@"It smells weird");
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 34;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 50, 0);
        }
    }
}