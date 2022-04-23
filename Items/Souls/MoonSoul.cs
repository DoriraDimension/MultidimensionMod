using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class MoonSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the Moon Lord");
			Tooltip.SetDefault("The one being the Lunatic Cultist wanted to reawake, it was waiting behind the moon, gathering new power to strike once more.\nTho the thing that was supposed to bring doom upon this world was nothing more than a weak imperfect incarnation of what it once has been.");
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 36;
			Item.rare = ItemRarityID.Red;
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
							Item.overrideColor = new Color(137, 232, 204);
							break;
						case 1:
							Item.overrideColor = new Color(29, 139, 113);
							break;
					}
				}
			}
		}
	}
}