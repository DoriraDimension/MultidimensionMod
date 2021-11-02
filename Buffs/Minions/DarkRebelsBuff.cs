using MultidimensionMod.Projectiles.Minions;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Minions
{
	public class DarkRebelsBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Dark Rebel");
			Description.SetDefault("One of Smiley's trusted soldiers helps you in battle");
			DisplayName.AddTranslation(GameCulture.German, "Dunkle Rebell");
			Description.AddTranslation(GameCulture.German, "Einer von Smiley's vertrauten Soldaten hilft dir im Kampf.");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<DarkRebelsMinion>()] > 0)
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