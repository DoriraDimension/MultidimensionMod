using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class DukeSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of Duke Fishron");
			Tooltip.SetDefault("A weird pigron mutation from the seas, he seems to have some sort of connection to the Storm and it's aggressive scouts.\nPerhaps the duke of the seas has a more important role than one thinks.");
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 30;
			Item.rare = ItemRarityID.Yellow;
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
							Item.OverrideColor = new Color(48, 248, 171);
							break;
						case 1:
							Item.OverrideColor = new Color(25, 120, 181);
							break;
					}
				}
			}
		}
	}
}