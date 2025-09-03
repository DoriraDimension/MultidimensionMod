using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class MycelialCantaloupe : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[2] {
                new Color(197, 162, 146),
                new Color(83, 105, 94)
            };
            //ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
            ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.Ambrosia;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(36, 30, BuffID.WellFed, 12000);
            Item.maxStack = 9999;
        }
    }
}