using MultidimensionMod.Common.Systems;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using MultidimensionMod.Common.Globals;

namespace MultidimensionMod.Items
{
    public class VanillaUndowner : ModItem
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

        public override bool AltFunctionUse(Player player) => true;

        public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse != 2)
            {
                NPC.downedSlimeKing = false;
                NPC.downedBoss1 = false;
                NPC.downedBoss2 = false;
                NPC.downedQueenBee = false;
                NPC.downedBoss3 = false;
                NPC.downedDeerclops = false;
            }
            else if (player.altFunctionUse == 2)
            {
                NPC.downedQueenSlime = false;
                NPC.downedMechBoss1 = false;
                NPC.downedMechBoss2 = false;
                NPC.downedMechBoss3 = false;
                NPC.downedPlantBoss = false;
                NPC.downedGolemBoss = false;
                NPC.downedEmpressOfLight = false;
                NPC.downedFishron = false;
                NPC.downedAncientCultist = false;
                NPC.downedTowerSolar = false;
                NPC.downedTowerVortex = false;
                NPC.downedTowerNebula = false;
                NPC.downedTowerStardust = false;
                NPC.downedMoonlord = false;
            }

            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.WorldData);

            return true;
        }
    }
}