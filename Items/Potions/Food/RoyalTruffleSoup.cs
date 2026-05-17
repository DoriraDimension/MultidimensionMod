using Microsoft.Xna.Framework;
using MultidimensionMod.Items.Materials;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class RoyalTruffleSoup : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(159, 36, 118),
                new Color(72, 30, 96),
                new Color(37, 15, 64)
            };
            //ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(26, 26, BuffID.WellFed3, 45000, true);
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<GourmetTruffle>())
            .AddIngredient(ModContent.ItemType<Mushmatter>())
            .AddIngredient(ModContent.ItemType<GlowingMushmatter>())
            .AddIngredient(ItemID.StoneBlock, 5)
            .AddTile(TileID.CookingPots)
            .Register();
        }
    }
}