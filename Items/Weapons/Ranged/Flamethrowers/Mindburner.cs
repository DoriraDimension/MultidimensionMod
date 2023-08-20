using MultidimensionMod.Projectiles.Ranged;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Flamethrowers
{
	public class Mindburner : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 23;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 42;
			Item.height = 26;
			Item.useTime = 3;
			Item.useAnimation = 30;
			Item.reuseDelay = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0.3f;
			Item.value = Item.sellPrice(0, 0, 45, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<MadnessFlame>();
			Item.shootSpeed = 3f;
			Item.useAmmo = AmmoID.Gel;
			Item.consumeAmmoOnLastShotOnly = true;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, -2);
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 15f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Blowpipe)
			.AddIngredient(ModContent.ItemType<MadnessFragment>(), 8)
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 4)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}
