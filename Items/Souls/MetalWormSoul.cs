using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class MetalWormSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Core of the Destroyer");
			Tooltip.SetDefault("A long forgotten mech in shape of a worm that was lying dormant for years deep underground, it was now reactivated when the forces of light and darkness were unleashed.\nIt's only purpose is to tunnel through the ground and destroy everything in it's path.\nIt's creator remains unknown... for now...");
			DisplayName.AddTranslation(GameCulture.German, "Kern des Zerstörers");
			Tooltip.AddTranslation(GameCulture.German, "Ein lange vergessener Mech in Form eines Wurms der für Jahre tief im Untergrund ruhte, er was nun reaktiviert wenn Licht und Dunkelheit entfesselt wurden.\nSein einziger Zweck ist sich durchdie Erde zu graben und alles in seinem Weg zu zerstören.\nSein schöpfer bleibt unbekannt... fürs erste...");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
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
							item.overrideColor = new Color(49, 94, 202);
							break;
					}
				}
			}
		}
	}
}