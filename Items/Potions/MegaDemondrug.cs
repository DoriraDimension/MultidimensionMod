using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
    public class MegaDemondrug : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mega Demondrug");
            Tooltip.SetDefault("Increases all damage and crit chance by 12% and increases knockback.");
            DisplayName.AddTranslation(GameCulture.German, "Mega Dämonenmittel");
            Tooltip.AddTranslation(GameCulture.German, "Erhöht allen schaden und kritische Trefferchance um 12% um 12 und erhöht Rückstoß.");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 36;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(silver: 25);
            item.buffType = ModContent.BuffType<AttackUp>();
            item.buffTime = 36000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WrathPotion);
            recipe.AddIngredient(ItemID.RagePotion);
            recipe.AddIngredient(ItemID.TitanPotion);
            recipe.AddTile(355);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
