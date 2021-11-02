using MultidimensionMod.Items.Materials;
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
            item.width = 28;
            item.height = 34;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item2;
            item.maxStack = 999;
            item.consumable = true;
            item.rare = ItemRarityID.Green;
            item.value = Item.sellPrice(silver: 10);
            item.buffType = (BuffID.WellFed);
            item.buffTime = 7200;
        }
    }
}
