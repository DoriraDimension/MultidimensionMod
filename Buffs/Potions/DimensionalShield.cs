using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class DimensionalShield : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dimensional Shield");
            Description.SetDefault("Your body is surrounded by a dimensional energy shield.");
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
