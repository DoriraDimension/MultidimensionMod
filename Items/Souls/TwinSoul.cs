using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class TwinSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Core of the Twins");
			Tooltip.SetDefault("A long forgotten pair of mechs in shape of two eyes that were lying dormant for years, it was now reactivated when the forces of light and darkness were unleashed.\nTheir design was likely inspired by the eye of judgement, their purpose was to scout certain targets and eliminate them or call for support.\nIt's creator remains unknown... for now...");
			DisplayName.AddTranslation(GameCulture.German, "Kern der Zwillinge");
			Tooltip.AddTranslation(GameCulture.German, "Ein lange vergessenes paar Mechs in Form von zwei Augen das für Jahre tief im Untergrund ruhte, er war nun reaktiviert wenn Licht und Dunkelheit entfesselt wurden.\nIhr Design war wahrscheinlich vom Auge des Urteils inspiriert, ihr Zweck war es bestimmte Ziele ausfinsig zu machen und dann zu eliminieren oder um verstärkung zu rufen.\nSein schöpfer bleibt unbekannt... fürs erste...");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(7, 12));
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 38;
			item.rare = ItemRarityID.Pink;
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
							item.overrideColor = new Color(210, 210, 210);
							break;
						case 1:
							item.overrideColor = new Color(85, 202, 150);
							break;
					}
				}
			}
		}
	}
}