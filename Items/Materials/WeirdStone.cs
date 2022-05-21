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
			Tooltip.SetDefault("A rune stone with weird markings, it is sturdy enough to withstand a lot of energy.");
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 24;
			Item.maxStack = 1;
			Item.rare = ItemRarityID.White;
		}
	}
}