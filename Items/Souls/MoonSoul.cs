using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class MoonSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the Moon Lord");
			Tooltip.SetDefault("The one being the Lunatic Cultist wanted to reawake, it was waiting behind the moon, gathering new power to strike once more.\nTho the thing that was supposed to bring doom upon this world was nothing more than a weak imperfect incarnation of what it once have been.");
			DisplayName.AddTranslation(GameCulture.German, "Seele des Mondherren");
			Tooltip.AddTranslation(GameCulture.German, "Das eine Wesen das der Irre Kultist wiedererwecken wollte, es wartete hinter dem Mond und sammelte Kraft um ein weiteres mal zuzuschlagen.\nAllerdings war das Ding das Verdammnis über diese Welt bringen sollte nichts weiter als eine unvollkommene Inkarnation seines früheren selbst.");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 36;
			item.rare = ItemRarityID.Red;
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
							item.overrideColor = new Color(137, 232, 204);
							break;
						case 1:
							item.overrideColor = new Color(29, 139, 113);
							break;
					}
				}
			}
		}
	}
}