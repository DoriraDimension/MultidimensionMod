using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class WormSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the World Eater");
			Tooltip.SetDefault("A giant worm, responsible for the chasms in the corruption.\nThis creature might be named Eater of Worlds but it never actually consumed anything that size,\nit might got its name because of its size and habit to devour anything it finds.\nThe existence of this creature shows the potential of the corruption.");
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.rare = ItemRarityID.Green;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.Mod == "Terraria" && Item.Name == "ItemName")
				{
					switch (Main.GameUpdateCount / 60 % 2)
					{
						case 0:
							Item.OverrideColor = new Color(116, 94, 97);
							break;
						case 1:
							Item.OverrideColor = new Color(115, 127, 33);
							break;
					}
				}
			}
		}
	}
}