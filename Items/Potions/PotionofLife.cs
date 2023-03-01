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
            // DisplayName.SetDefault("Potion of Life");
            // Tooltip.SetDefault("Increases heart pickup range. \nIncreases max HP by 50. \nGives +2 life regen");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 28;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(silver: 25);
            Item.buffType = ModContent.BuffType<Buffs.Potions.LifePower>();
            Item.buffTime = 36000;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.HeartreachPotion)
            .AddIngredient(ItemID.LifeforcePotion)
            .AddIngredient(ItemID.RegenerationPotion)
            .AddTile(355)
            .Register();

        }
    }
}
