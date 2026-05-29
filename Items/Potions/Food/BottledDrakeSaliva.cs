using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class BottledDrakeSaliva : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(166, 216, 231),
                new Color(91, 129, 159),
                new Color(77, 101, 141)
            };
            //ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 15;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(10, 22, BuffID.WellFed, 12000, true);
            Item.maxStack = 9999;
        }
    }
}