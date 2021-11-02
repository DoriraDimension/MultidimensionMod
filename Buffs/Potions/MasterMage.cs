using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class MasterMage : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Master Mage");
            Description.SetDefault("Magic abilities are stronger.");
            DisplayName.AddTranslation(GameCulture.German, "Meistermagier");
            Description.AddTranslation(GameCulture.German, "Magische Fähigkeiten sind stärker.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.magicDamage += 0.2f;
            player.manaRegenBonus += 1;
            player.statManaMax2 += 40;
            player.manaMagnet = true;
        }
    }
}
