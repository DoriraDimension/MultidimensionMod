using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class WormSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the World Eater");
			Tooltip.SetDefault("A giant worm, responsible for the chasms in the corruption.\nThis creature might be named Eater of Worlds but it never actually consumed anything that size,\nit might got its name because of its size and habit to devour anything it finds.\nThe existence of this creature shows the potential of the corruption.");
			DisplayName.AddTranslation(GameCulture.German, "Seele des Weltenfressers");
			Tooltip.AddTranslation(GameCulture.German, "Ein riesiger Wurm der für die Kluften im Verderben verantwortlich ist.\nDiese Kreatur heisst zwar Weltenfresser, hat aber niemals etwas in derartiger größe verschlungen,\nvielleicht bekam es seinen namen wehen seiner größe und drang alles zu verschlingen das es findet.\nDie existenz dieser Kreatur zeigt das Potenzial des Verderbens.");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.rare = ItemRarityID.Green;
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
							item.overrideColor = new Color(116, 94, 97);
							break;
						case 1:
							item.overrideColor = new Color(115, 127, 33);
							break;
					}
				}
			}
		}
	}
}