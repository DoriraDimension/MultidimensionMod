using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class PerfectLeader : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Perfect Leader");
            Description.SetDefault("Increased summon damage.");
            DisplayName.AddTranslation(GameCulture.German, "Perfekter Anführer");
            Description.AddTranslation(GameCulture.German, "Erhöhter Beschwörungsschaden");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.minionDamage += 0.2f;
        }
    }
}
