using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class WarriorsHeart : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Warriors Heart");
            Description.SetDefault("Increased meele damage.");
            DisplayName.AddTranslation(GameCulture.German, "Herz eines kriegers");
            Description.AddTranslation(GameCulture.German, "Erhöhter Nahkampfschaden");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeDamage += 0.2f;
        }
    }
}
