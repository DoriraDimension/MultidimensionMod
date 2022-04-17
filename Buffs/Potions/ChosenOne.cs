using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class ChosenOne : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Weird Essence");
            Description.SetDefault("You are filled with the power of a ancient being.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Generic) += 0.15f;
            player.GetCritChance(DamageClass.Melee) += 15;
            player.kbBuff = true;
            player.lifeMagnet = true;
            player.statLifeMax2 += 50;
            player.lifeRegen += 2;
            player.statDefense += 12;
            player.endurance += 0.13f;
        }
    }
}
