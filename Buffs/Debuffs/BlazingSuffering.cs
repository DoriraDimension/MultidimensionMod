using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Debuffs
{
    public class BlazingSuffering : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blazing Suffering");
            Description.SetDefault("Your body is getting incinerated from the inside.");
           Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MDPlayer>().Blaze = true;
            player.endurance -= 0.06f;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MDGlobalNPC>().Blaze = true;
        }
    }
}
