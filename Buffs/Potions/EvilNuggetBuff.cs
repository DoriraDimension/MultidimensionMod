using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Potions
{
    public class EvilNuggetBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense *= 0.80f;
        }
    }

    public class EvilNuggetBuff2 : ModBuff
    {
        public override string Texture => "MultidimensionMod/Buffs/Potions/EvilNuggetBuff";
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed *= 0.50f;
            player.statLifeMax2 -= 50;
        }
    }
}