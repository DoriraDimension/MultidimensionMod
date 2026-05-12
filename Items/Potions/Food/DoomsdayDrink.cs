using Microsoft.Xna.Framework;
using MultidimensionMod.Items.Materials;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class DoomsdayDrink : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[4] {
                new Color(204, 62, 62),
                new Color(204, 181, 62),
                new Color(135, 54, 54),
                new Color(60, 24, 38)
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
            .AddIngredient(ModContent.ItemType<BinaryStarFruit>())
            .AddIngredient(ModContent.ItemType<VoidenMangosteen>())
            .AddTile(TileID.CookingPots)
            .Register();
        }
    }
}