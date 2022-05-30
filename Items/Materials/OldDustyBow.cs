﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class OldDustyBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Dusty Bow");
			Tooltip.SetDefault("A worn bow, covered in sandy dust.\nWith some love and craftmanship it could be repaired");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 30;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(silver: 14);
			Item.rare = ItemRarityID.Gray;
		}
	}
}