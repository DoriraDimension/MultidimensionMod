using System;
using Microsoft.Xna.Framework;
using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class ScalyMeatballs : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(129, 109, 117),
                new Color(107, 95, 191),
                new Color(58, 55, 125)
            };
            ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(34, 22, ModContent.BuffType<ScalyMeatballsBuff>(), 18000, false);
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.RottenChunk, 4)
            .AddIngredient(ItemID.ShadowScale, 2)
            .AddTile(TileID.CookingPots)
            .Register();
        }
    }
}