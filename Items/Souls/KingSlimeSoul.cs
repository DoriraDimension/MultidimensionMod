using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class KingSlimeSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the King Slime");
			Tooltip.SetDefault("The soul of the king of everything slimy.\nThe King Slime was once a ordinary blue slime who wanted to become the ultimate being.\nHe absorbed hundreds of other slimes and grew larger and larger to become allmighty...\nsadly blue slimes are very damn weak so the result wasnt too great in the end.\nIt's a mystery where he got his crown or who that idiot inside of him is.");
			DisplayName.AddTranslation(GameCulture.German, "Seele des Schleimkönigs");
			Tooltip.AddTranslation(GameCulture.German, "Die Seele des Königs allen Schleims.\nDer Schleimkönig war einst ein gewöhnlicher Schleim der das ultimative Wesen werden wollte.\nEr absorbierte hunderte andere Schleime and wurde größer und größer um allmächtig zu werden...\nLeider sind blaue Schleime ziemlich schwach sodass das Endergebnis am ende nicht so toll war.\nEs ist ein Mysterium wo er seine Krone her hat oder wer der Idiot im inneren ist.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(7, 5));
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 36;
			item.rare = ItemRarityID.Blue;
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
							item.overrideColor = new Color(89, 164, 254);
							break;
						case 1:
							item.overrideColor = new Color(228, 196, 74);
							break;
					}
				}
			}
		}
	}
}
