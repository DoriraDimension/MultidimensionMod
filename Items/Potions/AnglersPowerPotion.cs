using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
	public class AnglersPowerPotion : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angler's Power Potion");
            Tooltip.SetDefault("Increases your fishing power by 30. \nIncreases your chance to fish up crates by 10%. \nYou can see what is biting your hook.");
            DisplayName.AddTranslation(GameCulture.German, "Anglers Krafttrank");
            Tooltip.AddTranslation(GameCulture.German, "Erhöht Angelkraft um 30. \nErhöht deine Chance Kisten zu Angeln um 10%. \nDu kannst sehen was du am Haken hast.");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 38;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(silver: 70);
            item.buffType = ModContent.BuffType<AnglersPower>();
            item.buffTime = 36000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CratePotion);
            recipe.AddIngredient(ItemID.SonarPotion);
            recipe.AddIngredient(ItemID.FishingPotion);
            recipe.AddTile(355);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
