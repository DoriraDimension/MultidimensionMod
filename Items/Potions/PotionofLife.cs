using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
	public class PotionofLife : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Potion of Life");
            Tooltip.SetDefault("Increases heart pickup range. \nIncreases max HP by 50. \nGives +2 life regen");
            DisplayName.AddTranslation(GameCulture.German, "Trank des Lebens");
            Tooltip.AddTranslation(GameCulture.German, "Erhöht Herz aufsammel reichweite. \nErhöht maximale HP um 50. \nGibt +2 Lebend Regeneration.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(silver: 15);
            item.buffType = ModContent.BuffType<Buffs.Potions.LifePower>();
            item.buffTime = 36000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HeartreachPotion);
            recipe.AddIngredient(ItemID.LifeforcePotion);
            recipe.AddIngredient(ItemID.RegenerationPotion);
            recipe.AddTile(355);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
