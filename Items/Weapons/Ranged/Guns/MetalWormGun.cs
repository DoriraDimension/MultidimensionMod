using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Ranged.Guns
{
	public class MetalWormGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 107;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 68;
			Item.height = 22;
			Item.useTime = 47;
			Item.useAnimation = 47;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.rare = ItemRarityID.Pink;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 30f;
			Item.useAmmo = AmmoID.Bullet;
			Item.crit = 25;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			SoundEngine.PlaySound(SoundID.Item33 with { Volume = 0.4f }, player.position);
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<SnipeWorm>())
			.AddIngredient(ItemID.SoulofMight, 12)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<DestroyerDualLaser>();
		}
	}
}