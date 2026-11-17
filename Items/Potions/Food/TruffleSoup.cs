using Microsoft.Xna.Framework;
using MultidimensionMod.Buffs.Potions;
using MultidimensionMod.Items.Critters;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class TruffleSoup : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(56, 40, 34),
                new Color(150, 35, 50),
                new Color(110, 50, 25)
            };
            ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(32, 20, BuffID.WellFed2, 30000, true);
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
        }

        public override void OnConsumeItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<TruffleSoupBuff>(), 18000);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<GourmetTruffle>())
            .AddIngredient(ModContent.ItemType<MushbugBabyItem>())
            .AddIngredient(ModContent.ItemType<HovercapItem>())
            .AddTile(TileID.CookingPots)
            .Register();
        }
    }
}