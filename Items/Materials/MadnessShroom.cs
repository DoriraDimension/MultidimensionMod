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
        }

        public override void SetDefaults()
        {
            Item.maxStack = 999;

            Item.width = 36;
            Item.height = 38;
            Item.rare = ItemRarityID.White;
        }

    }
}
