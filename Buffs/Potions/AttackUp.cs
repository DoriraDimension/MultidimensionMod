using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class AttackUp : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Attack Up");
            Description.SetDefault("Increased offensive stats.");
            DisplayName.AddTranslation(GameCulture.German, "Angriff Hoch");
            Description.AddTranslation(GameCulture.German, "Erhöhte Offensive Werte.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage += 0.12f;
            player.meleeCrit += 12;
            player.rangedCrit += 12;
            player.magicCrit += 12;
            player.thrownCrit += 12;
            player.kbBuff = true;
        }
    }
}
