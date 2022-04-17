using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class PerfectLeader : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Perfect Leader");
            Description.SetDefault("Increased summon damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Summon) += 0.2f;
        }
    }
}
