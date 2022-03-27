using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class CultistSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the Lunatic Cultist");
			Tooltip.SetDefault("The weird cultist who worships the moon wanted to reawaken something that was sealed away for hundreds of years,\nbut he got interrupted and absorbed the energy used for the ritual to fight instead.\nThe absorbed celestial energy smashed his soul into 4 pieces driving him even more insane.\nThere was no hope for this guy anymore, or perhaps never was.");
			DisplayName.AddTranslation(GameCulture.German, "Seele des Irren Kultisten");
			Tooltip.AddTranslation(GameCulture.German, "Der seltsame Kultist der den Mond verehrt wollte etwas wiedererwecken das seit Jahrhunderten versiegelt war\naber er wurde unterbrochen und absorbierte die Energie für das Ritual zum Kämpfen.\nDie absorbierte Energie zerschlug seine Seele in 4 Teil was ihn noch verrückter machte.\nDa war keine Hoffnung mehr für diesen Typen, oder womöglich war da nie welche");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(7, 8));
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.rare = ItemRarityID.Cyan;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					switch (Main.GameUpdateCount / 60 % 4)
					{
						case 0:
							item.overrideColor = new Color(0, 177, 227);
							break;
						case 1:
							item.overrideColor = new Color(247, 178, 11);
							break;
						case 2:
							item.overrideColor = new Color(20, 223, 147);
							break;
						case 3:
							item.overrideColor = new Color(246, 92, 216);
							break;
					}
				}
			}
		}
	}
}