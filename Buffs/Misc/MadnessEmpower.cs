using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using MultidimensionMod.Common.Players;

namespace MultidimensionMod.Buffs.Misc
{
    public class MadnessEmpower : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MDGlobalNPC>().MadnessEmpower = true;
        }
    }
}
