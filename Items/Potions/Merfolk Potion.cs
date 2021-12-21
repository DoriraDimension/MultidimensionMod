using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
	public class MerfolkPotion : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Let's you breath underwater. \nGives you the ability to swim. \nIncreases movement speed by 10%.");
            DisplayName.AddTranslation(GameCulture.German, "Meervolk Trank");
            Tooltip.AddTranslation(GameCulture.German, "Lässt dich unterwasser atmen. \nGibt dir die Fähigkeit zu schwimmen. \n Erhöht Bewegungsgeschwindigkeit um 10%.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(silver: 21);
            item.buffType = ModContent.BuffType<OceansBlessing>();
            item.buffTime = 36000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GillsPotion);
            recipe.AddIngredient(ItemID.FlipperPotion);
            recipe.AddIngredient(ItemID.SwiftnessPotion);
            recipe.AddTile(355);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
