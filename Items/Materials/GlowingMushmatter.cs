using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MultidimensionMod.Items.Materials
{
	public class GlowingMushmatter : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 32;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 0, 30);
			Item.rare = ItemRarityID.Green;
		}
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Materials/GlowingMushmatter_Glow").Value;
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
