using Microsoft.Xna.Framework;
using MultidimensionMod.Buffs.Potions;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class SpineKebab : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(214, 127, 88),
                new Color(157, 53, 53),
                new Color(92, 15, 25)
            };
            ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(42, 42, ModContent.BuffType<SpineKebabBuff>(), 18000, false);
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Vertebrae, 4)
            .AddIngredient(ItemID.TissueSample, 2)
            .AddTile(TileID.CookingPots)
            .Register();
        }
    }
}