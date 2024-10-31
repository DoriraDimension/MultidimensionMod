using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Materials.Mushrooms
{
    public class Rainbow : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Rainbow Mushroom");
            //Tooltip.SetDefault(@"You're not really sure if it's colorful naturally or because you're high.");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.rare = ItemRarityID.Expert;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(0, 2, 0, 0);
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Materials/Mushrooms/Rainbow_Glow").Value;
            spriteBatch.Draw
                (
                texture,
                new Vector2
                (
                    Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
                    Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Main.DiscoColor,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
                );
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Materials/Mushrooms/Rainbow_Glow").Value;
            Texture2D texture2 = ModContent.Request<Texture2D>("MultidimensionMod/Items/Materials/Mushrooms/Rainbow").Value;
            spriteBatch.Draw(texture2, position, null, drawColor, 0, origin, scale, SpriteEffects.None, 0f);
            for (int i = 0; i < 4; i++)
            {
                //Vector2 offsetPositon = Vector2.UnitY.RotatedBy(MathHelper.PiOver2 * i) * 2;
                spriteBatch.Draw(texture, position, null, Main.DiscoColor, 0, origin, scale, SpriteEffects.None, 0f);

            }
            return false;
        }
    }
}
