using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Debuffs
{
    public class Madness : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Madness");
            Description.SetDefault("You witnessed cosmic knowledge, its burning your mind away.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MDPlayer>().Madness = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MDGlobalNPC>().Madness = true;
        }
    }
}
