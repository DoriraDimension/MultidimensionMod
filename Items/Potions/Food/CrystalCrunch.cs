using Microsoft.Xna.Framework;
using MultidimensionMod.Buffs.Potions;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class CrystalCrunch : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[4] {
                new Color(235, 194, 19),
                new Color(147, 88, 191),
                new Color(166, 4, 244),
                new Color(73, 13, 92)
            };
            ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(34, 28, ModContent.BuffType<CrystalCrunchBuff>(), 12000, false);
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.LightRed;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.CrystalShard, 3)
            .AddIngredient(ItemID.PixieDust, 5)
            .AddTile(TileID.CookingPots)
            .Register();
        }
    }
}