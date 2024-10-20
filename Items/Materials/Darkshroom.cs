using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
    public class Darkshroom : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Lunar Mushroom");
            //Tooltip.SetDefault("Only grows at night in dank bogs");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 26;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
        }

        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (!Main.dayTime)
            {
                Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Materials/Darkshroom_Glow").Value;
                spriteBatch.Draw(texture, position, null, drawColor, 0f, origin, scale, SpriteEffects.None, 0f);
            }
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            if (!Main.dayTime)
            {
                Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Materials/Darkshroom_Glow").Value;
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
                    Item.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally,
                    0f
                );
            }
        }
    }
}
