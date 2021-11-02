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
            DisplayName.SetDefault("Fucking overpowered super hyper mega ultra extreme hacker potion of absolute death limited edition");
            Tooltip.SetDefault("If you buy now, you get nothing for free.");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 60;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = -12;
            item.value = Item.sellPrice(platinum: 420);
            item.buffType = ModContent.BuffType<pap>();
            item.buffTime = 3600000;
        }
    }
}
