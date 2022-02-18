using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class BeeSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of a Queen Bee");
			Tooltip.SetDefault("These giant bees live deep in the jungle, disturb one of their larvae and feel their fury.");
			DisplayName.AddTranslation(GameCulture.German, "Seele einer Bienenkönigin");
			Tooltip.AddTranslation(GameCulture.German, "Diese gigantischen Bienen leben tief im Dschungel, störe eine ihrer Larven und fühl ihren Zorn.");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 38;
			item.rare = ItemRarityID.Orange;
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
							item.overrideColor = new Color(63, 39, 105);
							break;
						case 1:
							item.overrideColor = new Color(228, 215, 70);
							break;
					}
				}
			}
		}
	}
}