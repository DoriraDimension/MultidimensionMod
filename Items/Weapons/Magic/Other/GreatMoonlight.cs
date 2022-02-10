using System.Collections.Generic;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Dusts;
using MultidimensionMod.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Other
{
	public class GreatMoonlight : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Great Moonlight");
			Tooltip.SetDefault("The blue crystal blade is composed only of light.\nThe lunatic Cultist is a insane fanatic of the moon and so stole this legendary blade to use it himself,\ntho the Great Moonlight seems to not belong in this world and instead obeys an otherworldly moon.");
			DisplayName.AddTranslation(GameCulture.German, "Großes Mondlicht");
			Tooltip.AddTranslation(GameCulture.German, "Die blaue Kristallklinge ist nur aus Licht zusammengesetzt.\nDer Irre Kultist ist ein Fanatier des Mondes und so stahl er diese Legendäre Klinge um sie selbst zu benutzen,\nallerdings scheint es als gehöre das Große Mondlicht nicht in diese Welt und stattdessen gehorcht einem jenseitigen Mond.");
		}

		public override void SetDefaults()
		{
			item.damage = 100;
			item.magic = true;
			item.width = 72;
			item.height = 72;
			item.useTime = 61;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 6;
			item.autoReuse = true;
			item.value = Item.sellPrice(gold: 4);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<MoonlightWave>();
			item.shootSpeed = 15f;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			for (int i = 0; i < 6; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (ModContent.DustType<Moondust>()));
				Main.dust[dustIndex].noGravity = true;
			}
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/Weapons/Magic/Other/GreatMoonlight_Glow");
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
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
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<CultistSoul>());
			recipe.AddIngredient(ModContent.ItemType<Dimensium>(), 20);
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}