using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class SoulRemnant : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 22;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.White;
		}
	}
}