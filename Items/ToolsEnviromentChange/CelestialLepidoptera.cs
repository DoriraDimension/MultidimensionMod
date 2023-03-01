using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.ToolsEnviromentChange
{
	public class CelestialLepidoptera : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Celestial Lepidoptera");
			// Tooltip.SetDefault("A artifact shaped after the celestial deity of balance.\nCan be used to change day to night and vice versa.\nWhen needed the goddess sisters can combine their powers to create a energy projection resembling a giant purple colored goddess.");
		}

		public override void SetDefaults()
		{
			Item.width = 98;
			Item.height = 82;
			Item.rare = ItemRarityID.LightRed;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.useStyle = 4;
			Item.UseSound = SoundID.Item60;
			Item.consumable = false;
		}

		public override bool? UseItem(Player player)
		{
			if (Main.netMode != 1 && Main.dayTime)
			{
				Main.dayTime = false;
				Main.time = 0.0;
			}
			else
            {
				Main.dayTime = true;
				Main.time = 0.0;
            }
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<SunlightButterfly>())
			.AddIngredient(ModContent.ItemType<MoonlightMoth>())
			.AddIngredient(ItemID.SoulofLight, 5)
			.AddIngredient(ItemID.SoulofNight, 5)
			.AddIngredient(ItemID.PixieDust, 12)
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 12)
			.AddIngredient(ModContent.ItemType<Dimensium>(), 6)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/ToolsEnviromentChange/CelestialLepidoptera_Glow").Value;
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
