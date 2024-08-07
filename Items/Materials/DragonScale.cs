using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
    public class DragonScale : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Dragon Scale");
            //Tooltip.SetDefault("The scale of a being with draconic ancestors");
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