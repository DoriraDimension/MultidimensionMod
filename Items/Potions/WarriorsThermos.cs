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
            // DisplayName.SetDefault("Warriors Thermos");
            // Tooltip.SetDefault("A warm drink to strengthen your power. \nIncreases melee damage by 20%.");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 42;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 5);
            Item.buffType = ModContent.BuffType<WarriorsHeart>();
            Item.buffTime = 18000;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.BottledWater)
            .AddIngredient(ItemID.Fireblossom)
            .AddIngredient(ItemID.AntlionMandible)
            .AddTile(13)
            .Register();

        }
    }
}
