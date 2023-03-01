using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
    public class MasterMagePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Master Mage Potion");
            // Tooltip.SetDefault("Increases magic damage by 20%, increases mana regeneration, increases max mana by 40 and mana star pickup range");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(silver: 34);
            Item.buffType = ModContent.BuffType<MasterMage>();
            Item.buffTime = 26000;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.MagicPowerPotion)
                .AddIngredient(ItemID.ManaRegenerationPotion)
                .AddIngredient(ItemID.ManaCrystal)
                .AddIngredient(ItemID.Prismite)
                .AddTile(355)
                .Register();
        }
    }
}
