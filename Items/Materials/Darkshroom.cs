using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
    public class Darkshroom : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Lunar Mushroom");
            //Tooltip.SetDefault("Only grows at night in dank bogs");
        }
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
        }
    }
}
