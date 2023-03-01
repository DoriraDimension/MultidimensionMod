using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
	public class LophiiformesBaculum : ModItem
	{
		public int WaveTimer = 0;
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Lophiiformes Baculum");
			// Tooltip.SetDefault("A staff created from old blueprints found at the shores. The ancient depictions show it being used by wise magicians.");
			Item.staff[Item.type] = true; 
		}

		public override void SetDefaults()
		{
			Item.damage = 87;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 16;
			Item.width = 52;
			Item.height = 52;
			Item.useTime = 46;
			Item.useAnimation = 46;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Lophiiformes>();
			Item.shootSpeed = 22f;
			Item.crit = 8;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 4; i++)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(47)); 																																																																											
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
			}

			if (WaveTimer == 2)
            {
				Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ModContent.ProjectileType<GiantWave>(), damage, knockback, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<AtlanteanTrident>())
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 5)
			.AddIngredient(ItemID.HallowedBar, 11)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}

		public override bool? UseItem(Player player)
		{
			WaveTimer += 1;
			if (WaveTimer >= 3)
			{
				WaveTimer = 0;
			}
			return true;
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Magic/Staffs/LophiiformesBaculum_Glow").Value;
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
	}
}