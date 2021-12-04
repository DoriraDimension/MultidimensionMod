using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items
{
	public class WeirdStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Weird Stone");
			Tooltip.SetDefault("A stone with weird markings, it is entirely useless");
			DisplayName.AddTranslation(GameCulture.German, "Seltsamer Stein");
			Tooltip.AddTranslation(GameCulture.German, "Ein Stein mit seltsamen Markierungen, er ist komplett nutzlos.");
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