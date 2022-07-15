using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class SkeletonSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of Skeletron");
			Tooltip.SetDefault("A curse, Skeletron was nothing more than the physical incarnation of a old curse,\nthis curse binds the one poor soul that has to carry it, to guard the dark dungeon for all eternity.\nA old clothier fell victim to this curse due to his own curiosity when he entered a place he wasnt supposed to enter.\nThe curses influence didn't just possess the old man but also created copies of its physical form to guard the dungeon on lower levels.\nThe origins of the curse lie deep within the dungeon itself, but only a fool would dare to find it.");
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 32;
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
							Item.OverrideColor = new Color(204, 204, 159);
							break;
						case 1:
							Item.OverrideColor = new Color(45, 45, 29);
							break;
					}
				}
			}
		}
	}
}