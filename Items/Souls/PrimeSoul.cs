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
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 26;
			Item.rare = ItemRarityID.Pink;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.mod == "Terraria" && Item.Name == "ItemName")
				{
					switch (Main.GameUpdateCount / 60 % 2)
					{
						case 0:
							Item.overrideColor = new Color(210, 210, 210);
							break;
						case 1:
							Item.overrideColor = new Color(217, 50, 24);
							break;
					}
				}
			}
		}
	}
}