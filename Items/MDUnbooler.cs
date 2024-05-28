using MultidimensionMod.Common.Systems;
using MultidimensionMod.Items.Souls;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using MultidimensionMod.Common.Globals;

namespace MultidimensionMod.Items
{
    public class MDUnbooler : ModItem
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
            DownedSystem.seenFU = false;
            DownedSystem.seenHell = false;
            DownedSystem.seenDungeon = false;
            DownedSystem.seenTemple = false;
            DownedSystem.seenAether = false;
            DownedSystem.metAdel = false;
            DownedSystem.metVertrarius = false;
            DownedSystem.metDapper = false;
            DownedSystem.listenedToNonsense = false;
            DownedSystem.seenMushroom = false;
            DownedSystem.seenInferno = false;
            DownedSystem.seenVolcano = false;
            DownedSystem.seenMire = false;
            DownedSystem.seenLake = false;
            MemorySystem.seenMemory = false;

            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.WorldData);

            return true;
        }
    }
}