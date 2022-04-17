using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class MasterMage : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Master Mage");
            Description.SetDefault("Magic abilities are stronger.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Magic) += 0.2f;
            player.manaRegenBonus += 1;
            player.statManaMax2 += 10;
            player.manaMagnet = true;
        }
    }
}
