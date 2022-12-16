using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles.Furniture.VoidMatter;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Tools
{
	public class MatterMiner : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Matter Miner");
			Tooltip.SetDefault("A void matter pickaxe made to mine any matter... and it still cannot mine anything thats higher tier than Cobalt or Palladium...");
		}

		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Melee;
			Item.width = 46;
			Item.height = 36;
			Item.useTime = 16;
			Item.useAnimation = 24;
			Item.pick = 100;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(silver: 6);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.tileBoost += 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 12)
			.AddTile(ModContent.TileType<EmptyKingsFabricatorPlaced>())
			.Register();
		}
	}
}