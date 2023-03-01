using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.ToolsEnviromentChange
{
	public class MoonlightMoth : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Moonlight Moth");
			// Tooltip.SetDefault("A artifact shaped after a deity of balance, it's magic power scares the sun away\nThis butterfly resembles the blue goddess who is more childish and playful.");
		}

		public override void SetDefaults()
		{
			Item.width = 66;
			Item.height = 60;
			Item.rare = ItemRarityID.Orange;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.useStyle = 4;
			Item.UseSound = SoundID.Item60;
            Item.consumable = false;
		}

		public override bool? UseItem(Player player)
		{
			if (Main.netMode != 1)
			{
                Main.dayTime = false;
				Main.time = 0.0;
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<FrostScale>(), 8)
			.AddIngredient(ItemID.Moonglow, 3)
			.AddRecipeGroup("EvilSample", 6)
			.AddTile(16)
			.Register();
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/ToolsEnviromentChange/MoonlightMoth_Glow").Value;
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
