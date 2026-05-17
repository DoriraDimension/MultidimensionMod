using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class Toadstool : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[2] {
                new Color(8, 179, 255),
                new Color(0, 69, 156)
            };
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(30, 24, BuffID.WellFed2, 18000);
            Item.maxStack = 9999;
        }
    }
}