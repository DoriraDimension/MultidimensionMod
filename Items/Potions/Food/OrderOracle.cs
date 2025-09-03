using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class OrderOracle : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[4] {
                new Color(124, 120, 178),
                new Color(50, 54, 109),
                new Color(114, 71, 91),
                new Color(56, 27, 46)
            };
            //ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(26, 26, BuffID.WellFed, 12000, true);
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<TranquilityFig>())
            .AddIngredient(ModContent.ItemType<PassionFruit>())
            .AddTile(TileID.CookingPots)
            .Register();
        }
    }
}