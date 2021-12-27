using MultidimensionMod.Projectiles.Minions;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Minions
{
	public class OcramServantBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Forgotten Servant");
			Description.SetDefault("The servant of a long lost time is fighting for you");
			DisplayName.AddTranslation(GameCulture.German, "Vergessener Diener");
			Description.AddTranslation(GameCulture.German, "Der Diener einer lang vergessenen Zeit kämpft für dich");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<ServantofOcram2>()] > 0)
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