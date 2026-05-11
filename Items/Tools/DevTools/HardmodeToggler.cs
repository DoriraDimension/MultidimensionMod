using MultidimensionMod.Common.Systems;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using MultidimensionMod.Common.Globals;

namespace MultidimensionMod.Items.Tools.DevTools
{
    public class HardmodeToggler : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.rare = ItemRarityID.Green;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
        }

        public override bool? UseItem(Player player)
        {
            if (Main.hardMode)
            {
                Main.hardMode = false;
            }
            else
                Main.hardMode = true;
            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.WorldData);

            return true;
        }
    }
}