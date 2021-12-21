using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
    public class MasterMagePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Master Mage Potion");
            Tooltip.SetDefault("Increases magic damage by 20%, increases mana regeneration, increases max mana by 40 and mana star pickup range");
            DisplayName.AddTranslation(GameCulture.German, "Meistermagier Trank");
            Tooltip.AddTranslation(GameCulture.German, "Erhöht Magieschaden um 20%, erhöht Mana Regeneration, erhöht maxumales Mana um 40 und erhöht Mana Stern aufsammel reichweite.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(silver: 34);
            item.buffType = ModContent.BuffType<MasterMage>();
            item.buffTime = 26000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicPowerPotion);
            recipe.AddIngredient(ItemID.ManaRegenerationPotion);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddIngredient(ItemID.Prismite);
            recipe.AddTile(355);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
