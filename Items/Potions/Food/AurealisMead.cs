using Microsoft.Xna.Framework;
using MultidimensionMod.Buffs.Potions;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class AurealisMead : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(247, 240, 200),
                new Color(208, 186, 118),
                new Color(167, 137, 97)
            };
            ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(30, 28, ModContent.BuffType<AurealisMeadBuff>(), 12000, true);
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.BottledWater)
            .AddIngredient(ItemID.BottledHoney, 2)
            .AddIngredient(ModContent.ItemType<BottledDrakeSaliva>())
            .AddTile(TileID.Kegs)
            .Register();
        }
    }
}