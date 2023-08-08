using MultidimensionMod.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Ranged.Others
{
	public class SunrayBrick : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 110;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 70;
			Item.height = 70;
			Item.useTime = 56;
			Item.useAnimation = 56;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true;
			Item.knockBack = 10;
			Item.noUseGraphic = true;
			Item.value = Item.sellPrice(0, 2, 30, 0);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<SunrayBrickThrown>();
			Item.shootSpeed = 15f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.LihzahrdBrick, 20)
			.AddIngredient(ItemID.LunarTabletFragment, 4)
			.AddIngredient(ItemID.LihzahrdPowerCell)
			.AddTile(TileID.LihzahrdFurnace)
			.Register();
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Ranged/Others/SunrayBrick_Glow").Value;
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