using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class WallSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the Underworld");
			Tooltip.SetDefault("Ages ago the race of the underworld with great help of another race, captured and contained the forces of light and darkness.\nIn this world, neither light nor darkness are good or bad, but both forces possessed too much power over this place,\nthey were always fighting in the background which had influence on the world around them,\ncontaining them got rid of these problems but now you unleashed them again... make sure you are prepared.");
			DisplayName.AddTranslation(GameCulture.German, "Seele der Unterwelt");
			Tooltip.AddTranslation(GameCulture.German, "Vor vielen Jahren schaffte es die Rasse der Unterwelt mit hilfe einer anderen Rasse, Licht und Dunkelheit gefangen zu nehem und wegzusperren.\nIn dieser Welt ist weder Licht noch Dunkelheit böse oder gut, aber beide Kräfte besaßen zu viel Macht über diesen Ort,\nsie kämpften immer im Hintergrund was einen Einfluss auf die Welt um sie herum hatte,\ndie Probleme wahren beseitigt wenn sie weggesperrt waren aber nun hast du sie wieder entfesselt... sie sicher das du vorbereitet bist.");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 30;
			item.rare = ItemRarityID.LightRed;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					switch (Main.GameUpdateCount / 60 % 3)
					{
						case 0:
							item.overrideColor = new Color(158, 48, 83);
							break;
						case 1:
							item.overrideColor = new Color(162, 95, 234);
							break;
						case 2:
							item.overrideColor = new Color(220, 29,183);
							break;
					}
				}
			}
		}
	}
}