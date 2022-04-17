using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class OceansBlessing : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oceans Blessing");
            Description.SetDefault("You can swim and breathe like a resident of the sea.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.gills = true;
            player.accFlipper = true;
        }
    }
}
