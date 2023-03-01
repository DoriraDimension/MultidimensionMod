using MultidimensionMod.Projectiles.Summon.Minions;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Minions
{
	public class DrakeBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<IceDrakeOfDOOM>()] > 0)
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