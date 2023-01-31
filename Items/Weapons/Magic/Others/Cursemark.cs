using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Rarities;
using MultidimensionMod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Weapons.Magic.Others
{
	public class Cursemark : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursemark");
			Tooltip.SetDefault("While you press the attack button, your mouse gains a damaging aura.");
		}

		public override void SetDefaults()
		{
			Item.damage = 24;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 1;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0f;
			Item.value = Item.sellPrice(silver: 12);
			Item.rare = ModContent.RarityType<BossSoulItem>();
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Curse>();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, Main.MouseWorld, velocity, type, damage, knockback, player.whoAmI);
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<SkeletonSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 10)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}