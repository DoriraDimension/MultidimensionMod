using MultidimensionMod.Common.Players;
using MultidimensionMod.Projectiles.Melee.Swords;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Debuffs
{
    public class Nihil : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MDGlobalNPC>().Nihil = true;
            npc.defense -= npc.defense;
        }
    }
}