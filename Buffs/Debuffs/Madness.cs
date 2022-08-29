using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Debuffs
{
    public class Madness : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Madness");
            Description.SetDefault("you suck and just realized it.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MDPlayer>().Madness = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
        }
    }
}
