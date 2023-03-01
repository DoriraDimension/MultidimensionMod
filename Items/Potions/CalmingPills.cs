using MultidimensionMod.Buffs.Potions;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
    public class CalmingPills : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Calming Pills");
            // Tooltip.SetDefault("Calms your mind and fends off madness.");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item2;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(silver: 7);
            Item.buffType = ModContent.BuffType<CalmMind>();
            Item.buffTime = 18000;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Bottle)
            .AddIngredient(ModContent.ItemType<MadnessFragment>(), 5)
            .AddIngredient(ModContent.ItemType<EyeTendril>(), 2)
            .AddTile(TileID.Bottles)
            .Register();

        }
    }
}