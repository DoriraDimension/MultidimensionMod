using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class TwinSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Core of the Twins");
			Tooltip.SetDefault("A long forgotten pair of mechs in shape of two eyes that were lying dormant for years, it was now reactivated when the forces of light and darkness were unleashed.\nTheir design was likely inspired by the eye of judgement, their purpose was to scout certain targets.\nIt's creator remains unknown... for now...");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 12));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 38;
			Item.rare = ItemRarityID.Pink;
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
							Item.OverrideColor = new Color(210, 210, 210);
							break;
						case 1:
							Item.OverrideColor = new Color(85, 202, 150);
							break;
					}
				}
			}
		}
	}
}