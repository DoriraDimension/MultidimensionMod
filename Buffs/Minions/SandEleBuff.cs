using MultidimensionMod.Projectiles.Summon.Minions;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Minions
{
	public class SandEleBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lesser Sand Elemental");
			Description.SetDefault("A living ball of sand fights for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<FlyingSand>()] > 0)
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