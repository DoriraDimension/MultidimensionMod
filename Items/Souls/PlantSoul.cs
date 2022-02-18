using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class PlantSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of Plantera");
			Tooltip.SetDefault("Plantera is the guardian of the jungle.\nShe will hunt down and kill anyone who damages the small pink bulbs that are scattered around the jungle,\nas these are actually young plants that will eventually grow into another guardian, Plantera will defend them with her life.");
			DisplayName.AddTranslation(GameCulture.German, "Seele von Plantera");
			Tooltip.AddTranslation(GameCulture.German, "Plantera ist der Wächter des Dschungels.\nSie wird jeden Jagen und töten der ihre kleinen pinken Knospen beschädigt,\ndiese sind junge Pflanzen welche irgendwann zu einem neuen Wächter heranwachsen, Plantera wird sie mit ihrem Leben verteidigen.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(7, 10));
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 36;
			item.rare = ItemRarityID.Lime;
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
							item.overrideColor = new Color(225, 128, 206);
							break;
						case 1:
							item.overrideColor = new Color(110, 183, 4);
							break;
					}
				}
			}
		}
	}
}