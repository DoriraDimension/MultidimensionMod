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
            Tooltip.SetDefault("Gives you a small fragmant of a dimensional serpents power. \nIncreases defense by 10 and reduces Damage taken by 20%.");
            DisplayName.AddTranslation(GameCulture.German, "Dimensionsschild Trank");
            Tooltip.AddTranslation(GameCulture.German, "Gibt dir einen kleinen Teil der Kraft der Dimensionsschlange. \nErhöht verteidigung um 10 und reduziert erhaltenen Schaden um 20%.");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 42;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 999;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(silver: 19);
            item.buffType = ModContent.BuffType<DimensionalShield>();
            item.buffTime = 36000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronskinPotion);
            recipe.AddIngredient(ItemID.EndurancePotion);
            recipe.AddTile(355);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
