using Microsoft.Xna.Framework;
using MultidimensionMod.Buffs.Debuffs;
using MultidimensionMod.Buffs.Potions;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class GhostPepper : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(140, 238, 255),
                new Color(0, 140, 244),
                new Color(21, 52, 171)
            };
            ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(28, 34, ModContent.BuffType<GhostPepperBuff>(), 18000, false);
            Item.maxStack = 9999;
        }

        public override void OnConsumeItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<BlazingSuffering>(), 300);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.SpicyPepper)
            .AddIngredient(ItemID.Ectoplasm)
            .AddTile(TileID.CookingPots)
            .Register();
        }
    }
}