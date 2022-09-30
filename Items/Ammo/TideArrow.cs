using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Ammo
{
	public class TideArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tide Arrow");
			Tooltip.SetDefault("this arrow does arrotic stuff. what...?");
		}

		public override void SetDefaults()
		{
			Item.damage = 13;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 44;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.knockBack = 1.5f;
			Item.value = Item.sellPrice(copper: 24);
			Item.rare = ItemRarityID.Yellow;
			Item.shoot = ModContent.ProjectileType<TideArrowProj>();
			Item.shootSpeed = 5f;
			Item.ammo = AmmoID.Arrow;
		}

		public override void AddRecipes()
		{
			CreateRecipe(150)
			.AddIngredient(ItemID.WoodenArrow, 150)
			.AddIngredient(ModContent.ItemType<TidalQuartz>())
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}
