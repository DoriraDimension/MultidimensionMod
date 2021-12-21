using MultidimensionMod.Projectiles.SwordProjectiles;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class OceanicGlowshard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Oceanic Glowshard");
			Tooltip.SetDefault("A otherworldly blade from the back of a Glowmarin.\nShoots energized Glowshards.");
			DisplayName.AddTranslation(GameCulture.German, "Ozeanische Leuchtscherbe");
			Tooltip.AddTranslation(GameCulture.German, "Eine jenseitige Klinge vom Rücken eines Leuchtmarin \nVerschießt geladene Leuchtscherben.");
		}

		public override void SetDefaults()
		{
			item.damage = 60;
			item.melee = true;
			item.width = 24;
			item.height = 34;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 4;
			item.autoReuse = true;
			item.value = Item.sellPrice(gold: 2);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<Glowshard>();
			item.shootSpeed = 14f;
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/Weapons/Melee/Swords/OceanicGlowshard_Glow");
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
	}
}