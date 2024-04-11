using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
    public class Mushmatter : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 34;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 0, 30);
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Mushmatter");
            //Tooltip.SetDefault("A piece of fungal flesh from a royal mushroom creature\nIt is of high quality");
        }
    }
}
