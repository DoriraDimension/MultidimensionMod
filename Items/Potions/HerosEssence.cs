using MultidimensionMod.Buffs.Potions;
using MultidimensionMod.Tiles;
using MultidimensionMod.Items.Materials;
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
            DisplayName.SetDefault("Eternal's Essence");
            Tooltip.SetDefault("Grants temporary a tiny bit of weird power.");
            DisplayName.AddTranslation(GameCulture.German, "Essenz des Eternals");
            Tooltip.AddTranslation(GameCulture.German, "Gewährt temporär ein winziges stück seltsame Kraft.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
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
            recipe.AddIngredient(ModContent.ItemType<Dimensium>(), 3);
            recipe.AddTile(ModContent.TileType<DimensionalForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
