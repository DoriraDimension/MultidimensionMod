using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Materials
{
    public class Hotshroom : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Solar Mushroom");
            //Tooltip.SetDefault("Only grows during the day");
        }
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 24;
			Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
        }
    }
}
