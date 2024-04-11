using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Ability
{
    public class RoseVenom : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.venom = true;
            player.statDefense += 20;
            player.thorns += 25;
        }
    }
}
