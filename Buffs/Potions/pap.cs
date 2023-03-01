using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class pap : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 9999;
            player.moveSpeed = 10f;
            player.GetDamage(DamageClass.Generic) += 10f;
            player.statLifeMax2 += 1000000;
            player.lifeRegen += 10;
        }
    }
}
