using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class BeeSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of a Queen Bee");
			Tooltip.SetDefault("These giant bees live deep in the jungle, disturb one of their larvae and feel their fury.");
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 38;
			Item.rare = ItemRarityID.Orange;
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
							Item.OverrideColor = new Color(63, 39, 105);
							break;
						case 1:
							Item.OverrideColor = new Color(228, 215, 70);
							break;
					}
				}
			}
		}
	}
}