using MultidimensionMod.Buffs.Debuffs;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class RoyalTruffleSoupBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[ModContent.BuffType<PotionInfection>()] = true;
            player.manaRegenBonus += 2;
        }
    }
}