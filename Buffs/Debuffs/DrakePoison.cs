using MultidimensionMod.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Debuffs
{
    public class DrakePoison : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MDPlayer>().DrakePoison = true;
            player.statDefense -= 5;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MDGlobalNPC>().DrakePoison = true;
            npc.defense -= 5;
        }
    }
}
