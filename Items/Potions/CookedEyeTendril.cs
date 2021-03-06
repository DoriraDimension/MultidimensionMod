using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Weapons.Ranged.Bows;
using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
    public class CookedEyeTendril : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cooked Tendril");
            Tooltip.SetDefault("Good for the eyes.");
            DisplayName.AddTranslation(GameCulture.German, "Gebratener Tentakel");
            Tooltip.AddTranslation(GameCulture.German, "Gut für die Augen.");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 14;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item2;
            item.maxStack = 999;
            item.consumable = true;
            item.rare = ItemRarityID.Green;
            item.value = Item.sellPrice(copper: 23);
            item.buffType = (BuffID.NightOwl);
            item.buffTime = 3600; 
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Materials.EyeTendril>());
            recipe.AddTile(17);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TendrilBow>());
            recipe.AddTile(17);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();

        }
    }
}
