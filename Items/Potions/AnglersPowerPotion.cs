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
            Tooltip.SetDefault("Increases your fishing power by 30.\nIncreases your chance to fish up crates by 10%. \nYou can see what is biting your hook.");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 38;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(silver: 23);
            Item.buffType = ModContent.BuffType<AnglersPower>();
            Item.buffTime = 36000;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.CratePotion)
            .AddIngredient(ItemID.SonarPotion)
            .AddIngredient(ItemID.FishingPotion)
            .AddTile(355)
            .Register();
        }
    }
}
