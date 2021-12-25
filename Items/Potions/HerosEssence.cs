using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
    public class HerosEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hero's Essence");
            Tooltip.SetDefault("Gives you the powers of a former hero.");
            DisplayName.AddTranslation(GameCulture.German, "Essenz des Helden");
            Tooltip.AddTranslation(GameCulture.German, "Gibt dir die Kraft eines ehemaligen Helden.");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item4;
            item.maxStack = 999;
            item.consumable = true;
            item.rare = ItemRarityID.Yellow;
            item.value = Item.sellPrice(gold: 1);
            item.buffType = ModContent.BuffType<ChosenOne>();
            item.buffTime = 36000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Potions.MegaDemondrug>());
            recipe.AddIngredient(ModContent.ItemType<Potions.PotionofLife>());
            recipe.AddIngredient(ModContent.ItemType<Potions.DimensionalShieldPotion>());
            recipe.AddIngredient(ItemID.Ectoplasm);
            recipe.AddTile(355);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
