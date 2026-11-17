using Microsoft.Xna.Framework;
using MultidimensionMod.Buffs.Potions;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class Mirrorberry : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(12, 124, 69),
                new Color(19, 192, 77),
                new Color(9, 90, 55)
            };
            ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
            ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.Ambrosia;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(32, 44, ModContent.BuffType<MirrorberryBuff>(), 18000);
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Orange;
        }
    }
}