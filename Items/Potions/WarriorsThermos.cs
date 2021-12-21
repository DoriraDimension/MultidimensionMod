using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
    public class WarriorsThermos : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warriors Thermos");
            Tooltip.SetDefault("A warm drink to strengthen your power. \nIncreases melee damage by 20%.");
            DisplayName.AddTranslation(GameCulture.German, "Thermoskanne des Kriegers");
            Tooltip.AddTranslation(GameCulture.German, "Ein warmer Drink um deine Kraft zu stärken. \nErhöht Nahkampfschaden um 20%.");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 42;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(silver: 5);
            item.buffType = ModContent.BuffType<WarriorsHeart>();
            item.buffTime = 18000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddIngredient(ItemID.AntlionMandible);
            recipe.AddTile(13);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
