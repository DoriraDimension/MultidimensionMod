using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class CalmMind : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Calm Mind");
            Description.SetDefault("Madness has a harder time reaching your mind.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MDPlayer>().CalmMind = true;
        }
    }
}