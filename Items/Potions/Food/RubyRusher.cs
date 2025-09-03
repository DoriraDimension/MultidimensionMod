using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class RubyRusher : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[4] {
                new Color(136, 38, 23),
                new Color(19, 30, 27),
                new Color(197, 162, 146),
                new Color(83, 105, 94)
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
            .AddIngredient(ModContent.ItemType<RedPersimmon>())
            .AddIngredient(ModContent.ItemType<MycelialCantaloupe>())
            .AddTile(TileID.CookingPots)
            .Register();
        }
    }
}