using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
    public class CommandersDrink : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Commander's Drink");
            Tooltip.SetDefault("Become a true leader. \nIncreases summon damage by 20%.");
            DisplayName.AddTranslation(GameCulture.German, "Komandants Drink");
            Tooltip.AddTranslation(GameCulture.German, "Werde zu einem echten Anführer. \nErhöht Günstlings Schaden um 20%.");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 32;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 999;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(silver: 3);
            item.buffType = ModContent.BuffType<PerfectLeader>();
            item.buffTime = 18000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.JungleSpores);
            recipe.AddTile(13);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}