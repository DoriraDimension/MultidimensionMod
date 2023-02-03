using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using MultidimensionMod.Rarities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Weapons.Magic.Tomes
{
	public class SpazzicCurse : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spazzic Curse");
			Tooltip.SetDefault("Summons a cursed flame at your cursor that then explodes into smaller fireballs");
		}

		public override void SetDefaults()
		{
			Item.damage = 47;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 20;
			Item.width = 36;
			Item.height = 38;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0f;
			Item.value = Item.sellPrice(silver: 12);
			Item.rare = ModContent.RarityType<BossSoulItem>();
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<SpazzicFlame>();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, Main.MouseWorld, velocity, type, damage, knockback, player.whoAmI);
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<TwinSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 20)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}