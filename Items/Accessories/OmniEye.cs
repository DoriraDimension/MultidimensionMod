﻿using MultidimensionMod.Items.Materials;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class OmniEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Omni Eye");
			Tooltip.SetDefault("You... can... see. \nHighlights danger sources, enemies and treasures, also gives nightvision");
			DisplayName.AddTranslation(GameCulture.German, "Omni Auge");
			Tooltip.AddTranslation(GameCulture.German, "Du... kannst... sehen. \nGefahrenquellen, Gegner und Schätze werden hervorgehoben, außerdem gibt es Nachtsicht.");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 16;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 5);
			item.rare = ItemRarityID.LightRed;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.findTreasure = true;
			player.detectCreature = true;
			player.nightVision = true;
			player.dangerSense = true;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EyeoftheExplorer>());
			recipe.AddIngredient(ModContent.ItemType<EyeoftheHunter>());
			recipe.AddIngredient(ModContent.ItemType<EyeoftheNightwalker>());
			recipe.AddIngredient(ModContent.ItemType<EyeofDesire>());
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 10);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/Accessories/OmniEye_Glow");
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