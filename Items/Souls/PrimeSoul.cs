using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class PrimeSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Core of Skeletron Prime");
			Tooltip.SetDefault("A long forgotten mech in shape of a curse that was lying dormant for years, it was now reactivated when the forces of light and darkness were unleashed.\nAges ago someone found a sample of the Skeletron curse and recreated it as a mechanical form with even more weapons.\nIt's creator remains unknown... for now...");
			DisplayName.AddTranslation(GameCulture.German, "Kern von Skeletron Prime");
			Tooltip.AddTranslation(GameCulture.German, "Ein lange vergessener Mech in Form eines Fluchs der für Jahre ruhte, er war nun reaktiviert wenn Licht und Dunkelheit entfesselt wurden.\nJahre zuvor hat jemand eine Probe des Skeletron Fluchs und rekreirte ihn als eine mechanische Form mit noch mehr Waffen.\nSein schöpfer bleibt unbekannt... fürs erste...");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 26;
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
							item.overrideColor = new Color(217, 50, 24);
							break;
					}
				}
			}
		}
	}
}