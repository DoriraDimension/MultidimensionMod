using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class GolemSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Core of a Golem");
			Tooltip.SetDefault("A solar essence powered protector Golem, it is in no way perfect and seems to be as it was build in a rush.\nIf it was build in a rush, then what happened?");
			DisplayName.AddTranslation(GameCulture.German, "Kern eines Golems");
			Tooltip.AddTranslation(GameCulture.German, "Ein durch Solar Essenz betriebener Schutzgolem erbaut von den Lihzahrds, er ist keinesfalls perfekt und scheint eine eher hastig gebaute version zu sein.\nWenn es schnell gebaut werden musste, dann was ist hier passiert?");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(7, 8));
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.rare = ItemRarityID.Lime;
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
							item.overrideColor = new Color(141, 56, 0);
							break;
						case 1:
							item.overrideColor = new Color(255, 216, 0);
							break;
					}
				}
			}
		}
	}
}