using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class SkeletonSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of Skeletron");
			Tooltip.SetDefault("A curse, Skeltron was nothing more than the physical incarnation of a old curse,\nthis curse binds the one poor soul that has to carry it, to guard the dark dungeon for all eternity.\nA old clothier fell victim to this curse due to his own curiosity when he entered a place he wasnt supposed to enter.\nThe curses influence didn't just possess the old man but also created copies of its physical form if anyone else tries to enter the dungeon.\nThe origins of the curse lie deep within the dungeon itself, but only a fool would dare to find it.");
			DisplayName.AddTranslation(GameCulture.German, "Seele von Skeletron");
			Tooltip.AddTranslation(GameCulture.German, "Ein Fluch, SKeletron was nichts weiter als die Physische inkarnation eines Fluchs,\ndieser Fluch bindet die eine arme Seele die sie trägt, das dunkle Verlies auf ewig zu bewachen.\nEin alter Schneider wurde dem Fluch zum opfer als er orte betrat die er nie hätte betreten sollen.\nDer Einfluss des Fluchs nahm nicht nur besitz vom alten mann, es erschuf auch Kopien seiner physischen Form sollte irgendjemand versuchen das Verlies zu betreten.\nDer Ursprung des Fluchs liegt irgendwo tief untem im Verlies verborgen, aber nur ein Narr würde versuchen es zu finden.");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 32;
			item.rare = ItemRarityID.Orange;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					switch (Main.GameUpdateCount / 60 % 2)
					{
						case 0:
							item.overrideColor = new Color(204, 204, 159);
							break;
						case 1:
							item.overrideColor = new Color(45, 45, 29);
							break;
					}
				}
			}
		}
	}
}