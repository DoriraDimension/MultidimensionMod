using Microsoft.Xna.Framework;
using MultidimensionMod.Buffs.Potions;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class EvilNugget : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(202, 37, 66),
                new Color(142, 39, 98),
                new Color(49, 23, 71)
            };
            ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(22, 24, BuffID.WellFed, 1);
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(0, 0, 0, 0);
        }

        public override void OnConsumeItem(Player player)
        {
            int ILovegambling = Main.rand.Next(100);

            if (ILovegambling <= 10)
            {
                player.AddBuff(ModContent.BuffType<GoldenNuggetBuff>(), 36000);
            }
            else if (ILovegambling <= 65)
            {
                player.AddBuff(ModContent.BuffType<EvilNuggetBuff>(), 36000);
            }
            else
            {
                player.AddBuff(ModContent.BuffType<EvilNuggetBuff2>(), 36000);
            }
        }
    }
}