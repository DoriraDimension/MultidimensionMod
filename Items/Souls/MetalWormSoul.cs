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
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
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
							Item.overrideColor = new Color(49, 94, 202);
							break;
					}
				}
			}
		}
	}
}