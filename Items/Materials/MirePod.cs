using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
    public class MirePod : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Swamp Scale");
            //Tooltip.SetDefault("The scale of a creature that lives in the mire");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
        }
    }
}