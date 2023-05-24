using MultidimensionMod.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Flamethrowers
{
	public class Spazmelter : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 46; 
			Item.DamageType = DamageClass.Ranged;
			Item.width = 42;
			Item.height = 26;
			Item.useTime = 3;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0.3f;
			Item.value = Item.sellPrice(0, 1, 60, 0);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<SpazmicFlame>();
			Item.shootSpeed = 7f;
			Item.useAmmo = AmmoID.Gel;
			Item.consumeAmmoOnLastShotOnly = true;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, -2);
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Ranged/Flamethrowers/Spazmelter_Glow").Value;
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
					Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.HallowedBar, 11)
			.AddIngredient(ItemID.SoulofSight, 7)
			.AddIngredient(ItemID.CursedFlame, 6)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}
