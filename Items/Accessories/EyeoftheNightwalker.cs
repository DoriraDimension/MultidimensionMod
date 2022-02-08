using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using MultidimensionMod.Items.Accessories;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Face)]
	public class EyeoftheNightwalker : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of the Nightwalker");
			Tooltip.SetDefault("A true resident of the night can see through the darkness.\nOne of the forbidden eyes.\nYou now have improved vision at night.");
			DisplayName.AddTranslation(GameCulture.German, "Auge des Nachtläufers");
			Tooltip.AddTranslation(GameCulture.German, "Ein wahrer bewohner der Nacht kann durch die Dunkelheit sehen.\nEins der verbotenen Augen.\nDu hast verbesserte Nachtsicht in der Nacht.");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 12;
			item.accessory = true;
			item.value = Item.sellPrice(copper: 60);
			item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.nightVision = true;
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/Accessories/EyeoftheNightwalker_Glow");
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