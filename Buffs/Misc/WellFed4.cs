using MultidimensionMod.Common.Globals;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Misc
{
    public class WellFed4 : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            BuffID.Sets.IsWellFed[Type] = true;
            BuffID.Sets.IsFedState[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 5;
            player.GetDamage(DamageClass.Generic) += 0.12f;
            player.GetCritChance(DamageClass.Generic) += 5;
            player.GetAttackSpeed(DamageClass.Melee) *= 1.12f;
            player.GetKnockback(DamageClass.Summon).Base *= 1.25f;
            player.moveSpeed *= 1.5f;
            player.pickSpeed *= 0.8f;
            player.wellFed = true;
        }

        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
        {
            if (Main.expertMode)
            {
                tip = Language.GetTextValue("Mods.MultidimensionMod.Buffs.WellFed4.DescriptionExpert");
            }
        }
    }
}