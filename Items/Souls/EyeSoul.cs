using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class EyeSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the Eye");
			Tooltip.SetDefault("Yes, this eye actually had a soul on its own.\nThe ever watching eye, true eye or not, it doesnt matter, it was just waiting for another being to grow stronger.\nSome people call it the Eye of Judgement, the first test.");
			DisplayName.AddTranslation(GameCulture.German, "Seele des Auges");
			Tooltip.AddTranslation(GameCulture.German, "Ja, dieses Auge hatte eine eigene Seele.\nDas immer beobachtende Auge, wahres Auge oder nicht, es ist egal, es hat nur darauf gewartet das ein weiters Wesen an stärke gewinnt.\nEinige Leute nennen es das Auge des Urteils, der erste Test.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(7, 12));
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 36;
			item.rare = ItemRarityID.Green;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					switch (Main.GameUpdateCount / 60 % 3)
					{
						case 0:
							item.overrideColor = new Color(55, 49, 181);
							break;
						case 1:
							item.overrideColor = new Color(230, 230, 230);
							break;
						case 2:
							item.overrideColor = new Color(181, 37, 37);
							break;
					}
				}
			}
		}
	}
}
