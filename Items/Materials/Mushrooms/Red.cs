using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials.Mushrooms
{
    public class Red : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Red Alchemical Mushroom");
            //Tooltip.SetDefault(@"It smells weird");
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 40;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 50, 0);
        }
    }
}