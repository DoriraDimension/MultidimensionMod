using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class WeirdStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rune Stone");
			Tooltip.SetDefault("A rune stone with weird markings, it is sturdy enough to withstand the energy of a archruler.");
			DisplayName.AddTranslation(GameCulture.German, "Runenstein");
			Tooltip.AddTranslation(GameCulture.German, "Ein Runenstein mit seltsamen Markierungen, er ist stabil genug um der Energie eines Erzherrschers standzuhalten.");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 24;
			item.maxStack = 1;
			item.rare = ItemRarityID.White;
		}
	}
}