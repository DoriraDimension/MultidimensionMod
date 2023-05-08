using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Melee.Swords;
using MultidimensionMod.Tiles.Furniture.VoidMatter;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class DarkMatterImpacter : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.damage = 61;
			Item.DamageType = DamageClass.Melee;
			Item.width = 62;
			Item.height = 86;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.knockBack = 8;
			Item.value = Item.sellPrice(silver: 23);
			Item.rare = ItemRarityID.Orange;
			Item.shootSpeed = 5f;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 14)
			.AddTile(ModContent.TileType<EmptyKingsFabricatorPlaced>())
			.Register();
		}
	}
}