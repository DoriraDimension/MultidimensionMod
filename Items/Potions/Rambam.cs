using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
	public class Rambam : ModItem
	{
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fucking overpowered super hyper mega ultra extreme hacker potion of absolute death limited edition");
            // Tooltip.SetDefault("If you buy now, you get nothing for free.");
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 60;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 1;
            Item.consumable = true;
            Item.rare = -12;
            Item.value = Item.sellPrice(platinum: 420);
            Item.buffType = ModContent.BuffType<pap>();
            Item.buffTime = 3600000;
        }
    }
}
