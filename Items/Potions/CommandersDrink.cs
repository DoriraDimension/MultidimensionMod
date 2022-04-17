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
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 3);
            Item.buffType = ModContent.BuffType<PerfectLeader>();
            Item.buffTime = 18000;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.BottledWater)
            .AddIngredient(ItemID.Moonglow)
            .AddIngredient(ItemID.JungleSpores)
            .AddTile(13)
            .Register();
        }
    }
}