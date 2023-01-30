using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class Prismatine : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prismatine");
			Tooltip.SetDefault("A prismatic shard empowered by the Empress of Light,\nit is rumored that they are Crystal Shards in their purest form");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 20;
			Item.maxStack = 9999;
			Item.rare = ItemRarityID.Yellow;
		}
	}
}
