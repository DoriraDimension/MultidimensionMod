using MultidimensionMod.Projectiles.Minions;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Minions
{
	public class DrakeBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Tame Ice Drake Juvenile");
			Description.SetDefault("A cute Ice Drake bby is MURDERING YOUR ENEMIES!");
			DisplayName.AddTranslation(GameCulture.German, "Zahmes Eis Draken Bby");
			Description.AddTranslation(GameCulture.German, "Einer süßes Eis Draken bby ERMORDET DEINE FEINDE!");
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