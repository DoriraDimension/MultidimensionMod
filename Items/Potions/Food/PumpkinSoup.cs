using Microsoft.Xna.Framework;
using MultidimensionMod.Items.Materials;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class PumpkinSoup : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[4] {
                new Color(87, 126, 60),
                new Color(225, 163, 94),
                new Color(191, 95, 42),
                new Color(169, 67, 30)
            };
            //ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(30, 24, BuffID.WellFed2, 48000, true);
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Pumpkin, 3)
            .AddIngredient(ModContent.ItemType<BambooPowder>(), 2)
            .AddTile(TileID.CookingPots)
            .Register();
        }
    }
}