using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials.Mushrooms
{
    public class Green : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Green Alchemical Mushroom");
            //Tooltip.SetDefault(@"It smells weird");
        }
        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 30;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 50, 0);
        }
    }
}