using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class MistyPear : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[2] {
                new Color(71, 179, 202),
                new Color(24, 37, 88)
            };
            //ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
            ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.Ambrosia;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(24, 36, BuffID.WellFed, 12000);
            Item.maxStack = 9999;
        }
    }
}