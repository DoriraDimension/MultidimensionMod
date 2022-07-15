using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class SmileySoulshard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Smiley Soulshard");
			Tooltip.SetDefault("A shard that reflects the soul of a dark being.\nSmiley was born as a being of pure dark whos purpose was to spread darkness all across existence, but unlike his siblings, he refused to be evil.\nWhen his creator wasn't paying attention he left his home together with a small army of Darklings.\nNow he is hiding in the Terrarian world with hope to find a person strong enough to take on his creator.");
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
			Item.rare = ItemRarityID.LightRed;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.Mod == "Terraria" && Item.Name == "ItemName")
				{
					switch (Main.GameUpdateCount / 60 % 3)
					{
						case 0:
							Item.OverrideColor = new Color(255, 242, 0);
							break;
						case 1:
							Item.OverrideColor = new Color(120, 13, 255);
							break;
						case 2:
							Item.OverrideColor = new Color(19, 19, 22);
							break;
					}
				}
			}
		}
	}
}
