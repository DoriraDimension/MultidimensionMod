using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class WhiteMeat : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(231, 215, 227),
                new Color(170, 152, 171),
                new Color(135, 120, 139)
            };
            ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(16, 22, BuffID.WellFed, 12000);
            Item.maxStack = 9999;
        }
    }
}