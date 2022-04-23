using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class EyeSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the Eye");
			Tooltip.SetDefault("Yes, this eye actually had a soul on its own.\nThe ever watching eye, true eye or not, it doesnt matter, it was just waiting for another being to grow stronger.\nSome people call it the Eye of Judgement, the first test.");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 12));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 36;
			Item.rare = ItemRarityID.Green;
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
							Item.overrideColor = new Color(55, 49, 181);
							break;
						case 1:
							Item.overrideColor = new Color(230, 230, 230);
							break;
						case 2:
							Item.overrideColor = new Color(181, 37, 37);
							break;
					}
				}
			}
		}
	}
}
