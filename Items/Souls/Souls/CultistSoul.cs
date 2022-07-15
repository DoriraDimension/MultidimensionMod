using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class CultistSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the Lunatic Cultist");
			Tooltip.SetDefault("The weird cultist who worships the moon wanted to reawaken something that was sealed away for hundreds of years,\nbut he got interrupted and absorbed the energy used for the ritual to fight instead.\nThe absorbed celestial energy smashed his soul into 4 pieces driving him even more insane.\nThere was no hope for this guy anymore, or perhaps never was.");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 8));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.rare = ItemRarityID.Cyan;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.Mod == "Terraria" && Item.Name == "ItemName")
				{
					switch (Main.GameUpdateCount / 60 % 4)
					{
						case 0:
							Item.OverrideColor = new Color(0, 177, 227);
							break;
						case 1:
							Item.OverrideColor = new Color(247, 178, 11);
							break;
						case 2:
							Item.OverrideColor = new Color(20, 223, 147);
							break;
						case 3:
							Item.OverrideColor = new Color(246, 92, 216);
							break;
					}
				}
			}
		}
	}
}