using MultidimensionMod.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Weapons.Magic.Guns
{
	public class Retilazor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Retilazor");
			Tooltip.SetDefault("Fires 4 lazors per shot.");
		}

		public override void SetDefaults()
		{
			Item.damage = 56;
			Item.DamageType = DamageClass.Magic;
			Item.width = 38;
			Item.height = 28;
			Item.useTime = 10;
			Item.useAnimation = 35;
			Item.reuseDelay = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Pink;
			Item.mana = 11;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<RedLazor>();
			Item.shootSpeed = 35f;
			Item.crit = 4;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			SoundEngine.PlaySound(SoundID.Item33 with {Volume = 0.4f}, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.HallowedBar, 12)
			.AddIngredient(ItemID.SoulofSight, 7)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}