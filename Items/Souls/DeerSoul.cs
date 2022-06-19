using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class DeerSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the Deerclops");
			Tooltip.SetDefault("A weird creature that resembles a one eyed deer on two legs, it originates from another world.\nThe creature only appears in snowy regions and is extremely hostile towards anything that comes near it.");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 8));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 44;
			Item.height = 26;
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
							Item.OverrideColor = new Color(211, 204, 196);
							break;
						case 1:
							Item.OverrideColor = new Color(27, 3, 123);
							break;
					}
				}
			}
		}
	}
}