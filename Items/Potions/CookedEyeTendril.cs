using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
    public class CookedEyeTendril : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cooked Tendril");
            Tooltip.SetDefault("Good for the eyes.");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 14;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item2;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(copper: 23);
            Item.buffType = (BuffID.NightOwl);
            Item.buffTime = 3600; 
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<EyeTendril>())
            .AddTile(17)
            .Register();
        }
    }
}
