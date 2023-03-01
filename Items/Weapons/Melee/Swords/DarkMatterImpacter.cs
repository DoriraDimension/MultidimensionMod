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
			// DisplayName.SetDefault("Void Matter Impacter");
			// Tooltip.SetDefault("A massive void matter sword used to hit enemies with a hefty swing\nCharge to yeet enemies even further.");
		}

		public override void SetDefaults()
		{
			Item.damage = 48;
			Item.DamageType = DamageClass.Melee;
			Item.width = 62;
			Item.height = 86;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.channel = true;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(silver: 23);
			Item.rare = ItemRarityID.Orange;
			Item.shootSpeed = 5f;
			Item.autoReuse = false;
			Item.shoot = ModContent.ProjectileType<DarkMatterImpacterProj>();
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