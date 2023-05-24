using MultidimensionMod.Rarities;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class CerebroAlloy : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 34;
			Item.maxStack = 9999;
			Item.rare = ModContent.RarityType<AseGneblessaArtifact>();
			Item.value = Item.sellPrice(0, 0, 10, 0);
		}
	}
}