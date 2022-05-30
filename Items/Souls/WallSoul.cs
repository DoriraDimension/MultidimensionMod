﻿using System.Collections.Generic;
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
			Tooltip.SetDefault("Ages ago the race of the underworld with great help of another race, captured and contained the forces of light and darkness.\nIn this world, neither light nor darkness are good or bad, but both forces possessed too much power over this place,\nthey were always conflicting with eachother which had influence on the world around them,\ncontaining them got rid of these problems but now you unleashed them again... make sure you are prepared.");
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 30;
			Item.rare = ItemRarityID.LightRed;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.mod == "Terraria" && Item.Name == "ItemName")
				{
					switch (Main.GameUpdateCount / 60 % 3)
					{
						case 0:
							Item.overrideColor = new Color(158, 48, 83);
							break;
						case 1:
							Item.overrideColor = new Color(162, 95, 234);
							break;
						case 2:
							Item.overrideColor = new Color(220, 29,183);
							break;
					}
				}
			}
		}
	}
}