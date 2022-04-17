using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
    public class MegaDemondrug : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mega Demondrug");
            Tooltip.SetDefault("Increases all damage and crit chance by 12% and increases knockback.");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 36;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(silver: 25);
            Item.buffType = ModContent.BuffType<AttackUp>();
            Item.buffTime = 36000;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.WrathPotion)
            .AddIngredient(ItemID.RagePotion)
            .AddIngredient(ItemID.TitanPotion)
            .AddTile(355)
            .Register();

        }
    }
}
