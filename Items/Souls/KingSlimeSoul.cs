using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class KingSlimeSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the King Slime");
			Tooltip.SetDefault("The soul of the king of everything slimy.\nThe King Slime was once a ordinary blue slime who wanted to become the ultimate being.\nHe absorbed hundreds of other slimes and grew larger and larger to become allmighty...\nsadly blue slimes are very damn weak so the result wasnt too great in the end.\nIt's a mystery where he got his crown or who that idiot inside of him is.");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 5));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 36;
			Item.rare = ItemRarityID.Blue;
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
							Item.OverrideColor = new Color(89, 164, 254);
							break;
						case 1:
							Item.OverrideColor = new Color(228, 196, 74);
							break;
					}
				}
			}
		}
	}
}
