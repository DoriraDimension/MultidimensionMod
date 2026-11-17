using Microsoft.Xna.Framework;
using MultidimensionMod.Buffs.Potions;
using MultidimensionMod.Items.Materials;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class WhiteMeatImmunizing : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(231, 215, 227),
                new Color(170, 152, 171),
                new Color(186, 169, 44)
            };
            ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(16, 22, BuffID.WellFed, 36000);
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<WhiteMeat>())
            .AddIngredient(ModContent.ItemType<MadnessShroom>())
            .AddIngredient(ItemID.GoldDust, 3)
            .AddTile(TileID.Bottles)
            .Register();
        }
    }
}