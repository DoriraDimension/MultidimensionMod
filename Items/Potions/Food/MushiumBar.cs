using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class MushiumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[2] {
                new Color(237, 160, 69),
                new Color(185, 98, 42)
            };
            ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(32, 32, BuffID.WellFed, 12000);
            Item.value = Item.buyPrice(silver: 4);
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
        }
    }
}