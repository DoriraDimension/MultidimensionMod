using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class RimeberryAle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(185, 206, 244),
                new Color(31, 86, 219),
                new Color(27, 43, 167)
            };
            ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(18, 28, BuffID.WellFed, 12000, true);
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Bottle)
            .AddIngredient(ModContent.ItemType<Rimeberry>())
            .AddIngredient(ItemID.Hay, 10)
            .AddTile(TileID.Kegs)
            .Register();
        }
    }
}