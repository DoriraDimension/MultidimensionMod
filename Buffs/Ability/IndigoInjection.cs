using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Ability
{
    public class IndigoInjection : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.manaCost -= 100f;
            player.buffImmune[BuffID.ManaSickness] = true;
        }
    }
}