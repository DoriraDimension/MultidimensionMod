using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
    public class KFC : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("KFC");
            Tooltip.SetDefault("Kevin's Fried Chicken.");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 34;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item2;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 10);
            Item.buffType = (BuffID.WellFed);
            Item.buffTime = 7200;
        }
    }
}
