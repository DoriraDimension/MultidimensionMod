using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions.Food
{
    public class GourmetTruffle : ModItem
    {

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(30, 24, BuffID.WellFed2, 12000);
            Item.maxStack = 9999;
        }
    }
}