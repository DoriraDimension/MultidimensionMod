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
            // DisplayName.SetDefault("Merfolk Potion");
            // Tooltip.SetDefault("Let's you breath underwater. \nGives you the ability to swim. \nIncreases movement speed by 10%.");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(silver: 21);
            Item.buffType = ModContent.BuffType<OceansBlessing>();
            Item.buffTime = 36000;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.GillsPotion)
            .AddIngredient(ItemID.FlipperPotion)
            .AddTile(355)
            .Register();

        }
    }
}
