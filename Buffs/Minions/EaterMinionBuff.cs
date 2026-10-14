using MultidimensionMod.Projectiles.Summon.Minions;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Minions
{
    public class EaterMinionBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Demon Eater");
			//Description.SetDefault("Summons a demonite eater to fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<EaterMinion>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
	}
}