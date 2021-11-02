using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class DimensionalShield : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Dimensional Shield");
            Description.SetDefault("Your body is surrounded by a dimensional energy shield.");
            DisplayName.AddTranslation(GameCulture.German, "Dimensionschield");
            Description.AddTranslation(GameCulture.German, "Dein Körper ist von einem dimensions Energieschild umgeben.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 10;
            player.endurance += 0.10f;
        }
    }
}
