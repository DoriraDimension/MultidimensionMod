using MultidimensionMod.Projectiles.Minions;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Minions
{
	public class SandEleBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Lesser Sand Elemental");
			Description.SetDefault("A living ball of sand fights for you");
			DisplayName.AddTranslation(GameCulture.German, "Niederer Sand Elementar");
			Description.AddTranslation(GameCulture.German, "Ein lebender Ball aus Sand kämpft für dich");
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