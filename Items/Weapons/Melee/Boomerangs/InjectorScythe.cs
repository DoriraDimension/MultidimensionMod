using MultidimensionMod.Projectiles.Melee.Boomerangs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Boomerangs
{
	public class InjectorScythe : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Injector Scythe");
			// Tooltip.SetDefault("A throwable scythe that was restored from old relics, inflicts the ichor debuff on hit for 3 seconds.");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Bananarang);
			Item.shootSpeed *= 1f;
			Item.width = 38;
			Item.height = 52;
			Item.damage = 65;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.value = Item.sellPrice(silver: 78);
			Item.rare = ItemRarityID.LightRed;
			Item.shoot = ModContent.ProjectileType<InjectorScytheProj>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<FleshRipper>())
			.AddIngredient(ItemID.Ichor, 8)
			.AddTile(134)
			.Register();
		}
	}
}