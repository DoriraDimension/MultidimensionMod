using MultidimensionMod.Common.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class EyeoftheNightwalker : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of the Nightwalker");
			Tooltip.SetDefault("A true resident of the night can see through the darkness.\nOne of the forbidden eyes.\nYou now have improved vision at night.\nHas a chance to inflict the Blackout debuff when you get it");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.accessory = true;
			Item.value = Item.sellPrice(copper: 60);
			Item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.nightVision = true;
			player.GetModPlayer<MDPlayer>().NightEye = true;
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Accessories/EyeoftheNightwalker_Glow").Value;
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