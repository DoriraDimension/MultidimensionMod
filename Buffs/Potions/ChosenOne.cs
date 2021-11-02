using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class ChosenOne : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Chosen One");
            Description.SetDefault("You are filled with the power of a former hero.");
            DisplayName.AddTranslation(GameCulture.German, "Auserwählter");
            Description.AddTranslation(GameCulture.German, "Du bist erfüllt von der Kraft eines ehemaligen Helden.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage += 0.15f;
            player.meleeCrit += 15;
            player.rangedCrit += 15;
            player.magicCrit += 15;
            player.thrownCrit += 15;
            player.kbBuff = true;
            player.lifeMagnet = true;
            player.statLifeMax2 += 50;
            player.lifeRegen += 2;
            player.statDefense += 12;
            player.endurance += 0.20f;
        }
    }
}
