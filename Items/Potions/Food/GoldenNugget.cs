using Microsoft.Xna.Framework;
using MultidimensionMod.Buffs.Potions;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class GoldenNugget : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(225, 249, 181),
                new Color(203, 179, 73),
                new Color(102, 77, 14)
            };
            ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(22, 24, ModContent.BuffType<GoldenNuggetBuff>(), 18000);
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Yellow;
        }
    }
}