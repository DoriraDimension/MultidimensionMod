using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class CoralCandy : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(190, 67, 101),
                new Color(97, 64, 139),
                new Color(3, 168, 137)
            };
            ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(18, 18, BuffID.WellFed, 12000, false);
            Item.maxStack = 9999;
        }

        public override void OnConsumeItem(Player player)
        {
            player.breath = player.breathMax;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Coral, 2)
            .AddIngredient(ItemID.BottledHoney)
            .AddTile(TileID.Furnaces)
            .Register();
        }
    }
}