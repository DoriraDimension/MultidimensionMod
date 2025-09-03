using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class MistyMire : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[4] {
                new Color(231, 34, 60),
                new Color(87, 7, 96),
                new Color(71, 179, 202),
                new Color(24, 37, 88)
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
            .AddIngredient(ModContent.ItemType<MistyPear>())
            .AddIngredient(ModContent.ItemType<Cranberry>())
            .AddTile(TileID.CookingPots)
            .Register();
        }
    }
}