using MultidimensionMod.Projectiles.Melee.Boomerangs;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Boomerangs
{
	public class FleshRipper : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Flesh Ripper");
			// Tooltip.SetDefault("A throwable Scythe that was restored from old relics, perfect for making big wounds.");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.WoodenBoomerang);
			Item.shootSpeed *= 2f;
			Item.width = 30;
			Item.height = 42;
			Item.damage = 19;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(silver: 25);
			Item.rare = ItemRarityID.Green;
			Item.shoot = ModContent.ProjectileType<FleshRipperProj>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<OldStainedScythe>())
			.AddIngredient(ItemID.TissueSample, 20)
			.AddTile(377)
			.Register();
		}
	}
}