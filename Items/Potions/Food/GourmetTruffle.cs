using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class GourmetTruffle : ModItem
    {

        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[4] {
                new Color(112, 99, 73),
                new Color(75, 58, 47),
                new Color(56, 40, 34),
                new Color(34, 22, 19)
            };
            ItemID.Sets.IsFood[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(30, 24, BuffID.WellFed2, 12000);
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
        }
    }
}