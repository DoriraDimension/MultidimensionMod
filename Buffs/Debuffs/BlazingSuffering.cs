using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Debuffs
{
    public class BlazingSuffering : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Blazing Suffering");
            Description.SetDefault("Your body is getting incinerated from the inside.");
            DisplayName.AddTranslation(GameCulture.German, "Loderndes Leiden");
            Description.AddTranslation(GameCulture.German, "Dein Körper wird von innen heraus verbrannt");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MDPlayer>().Blaze = true;
            player.statDefense -= 5;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MDGlobalNPC>().Blaze = true;
            npc.defense -= 5;
        }
    }
}
