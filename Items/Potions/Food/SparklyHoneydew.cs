using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class SparklyHoneydew : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[2] {
                new Color(47, 201, 194),
                new Color(47, 72, 88)
            };
            //ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
            ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.Ambrosia;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(32, 34, BuffID.WellFed, 12000);
            Item.maxStack = 9999;
        }
    }
}