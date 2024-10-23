using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Materials.Mushrooms
{
    public class RealityBendingShroom : ModItem
    {

        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 5));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 56;
            Item.rare = ItemRarityID.Quest;
            Item.value = Item.sellPrice(0, 30, 0, 0);
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Mushrooms/RealityBendingShroom").Value;
            Texture2D textureGlow = ModContent.Request<Texture2D>("MultidimensionMod/Items/Mushrooms/RealityBendingShroom_Glow").Value;
            Rectangle frame;
            frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
            Vector2 origin = frame.Size() / 2f;
            spriteBatch.Draw(texture, Item.Center - Main.screenPosition, frame, lightColor, rotation, origin, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureGlow, Item.Center - Main.screenPosition, frame, Color.White, rotation, origin, scale, SpriteEffects.None, 0f);
        }
    }
}