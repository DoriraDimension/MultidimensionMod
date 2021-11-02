using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class OceansBlessing : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Oceans Blessing");
            Description.SetDefault("You can swim and breathe like a resident of the sea.");
            DisplayName.AddTranslation(GameCulture.German, "Segnung des Ozeans");
            Description.AddTranslation(GameCulture.German, "Du kannst schwimmen und atmen wie ein Bewohner der see.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.gills = true;
            player.accFlipper = true;
            player.moveSpeed += 0.10f;
        }
    }
}
