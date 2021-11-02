using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class LifePower : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Life Power");
            Description.SetDefault("You feel as if you could live forever.");
            DisplayName.AddTranslation(GameCulture.German, "Kraft des Lebens");
            Description.AddTranslation(GameCulture.German, "Du fühlst dich als ob du für immer leben könntest.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeMagnet = true;
            player.statLifeMax2 += 50;
            player.lifeRegen += 2;
        }
    }
}
