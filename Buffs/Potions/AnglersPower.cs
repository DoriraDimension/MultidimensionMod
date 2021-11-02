using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class AnglersPower : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Angler's power");
            Description.SetDefault("You are filled with the power of a true fisher.");
            DisplayName.AddTranslation(GameCulture.German, "Anglers Kraft");
            Description.AddTranslation(GameCulture.German, "Du bist erfüllt von der kraft eines wahren Fischers.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.fishingSkill += 30;
            player.sonarPotion = true;
            player.cratePotion = true;
        }
    }
}
