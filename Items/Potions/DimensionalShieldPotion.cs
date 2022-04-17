using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
	public class DimensionalShieldPotion : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dimensional Shield Potion");
            Tooltip.SetDefault("Gives you a small fragmant of a dimensional serpents power. \nIncreases defense by 10 and reduces Damage taken by 20%.");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 42;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(silver: 19);
            Item.buffType = ModContent.BuffType<DimensionalShield>();
            Item.buffTime = 36000;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.IronskinPotion)
            .AddIngredient(ItemID.EndurancePotion)
            .AddTile(355)
            .Register();

        }
    }
}
