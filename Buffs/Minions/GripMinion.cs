using MultidimensionMod.Projectiles.Summon.Minions;
using MultidimensionMod.Common.Players;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Minions
{
    public class GripMinion : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Grips of Chaos");
			//Description.SetDefault("Summons a chaos claw to fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MDPlayer modPlayer = player.GetModPlayer<MDPlayer>();
			if (player.ownedProjectileCounts[ModContent.ProjectileType<DragonClaw>()] > 0 || player.ownedProjectileCounts[ModContent.ProjectileType<HydraClaw>()] > 0)
            {
				modPlayer.GripMinion = true;
			}
			if (!modPlayer.GripMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}