using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items
{
    public class TitleTester : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Title Tester");
            // Tooltip.SetDefault("Tests titles I think I guess?");
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.maxStack = 1;
            Item.value = 22000;
            Item.noUseGraphic = true;
            Item.rare = ItemRarityID.Orange;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
        }
        public override bool? UseItem(Player player)
        {
            if (!Main.dedServ)
            {
                MDSystem.Instance.TitleCardUIElement.DisplayTitle("Title Testing", 60, 90, 0.8f, 0, Color.LightSkyBlue, "There are bugs under your skin");
            }
            return true;
        }
    }
}
