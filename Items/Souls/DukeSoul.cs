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
			Tooltip.SetDefault("A weird pigron mutation from the seas, he seems to have some sort of connection to the Storm and it's aggressive scouts.\nPerhaps the duke of the seas is a more important role than one thinks.");
			DisplayName.AddTranslation(GameCulture.German, "Seele von Herzog Fischron");
			Tooltip.AddTranslation(GameCulture.German, "Eine seltsame Pigron Mutation aus dem Meer, er scheint eine Verbindung tum Sturm und seinen aggressiven Spähern zu haben.\nVielleicht hat der Herzog des Meeres doch eine wichtigere Rolle als einer denkt.");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 30;
			item.rare = ItemRarityID.Yellow;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					switch (Main.GameUpdateCount / 60 % 2)
					{
						case 0:
							item.overrideColor = new Color(48, 248, 171);
							break;
						case 1:
							item.overrideColor = new Color(25, 120, 181);
							break;
					}
				}
			}
		}
	}
}