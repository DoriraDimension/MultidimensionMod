using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using MultidimensionMod.Base;
using ReLogic.Content;
using MultidimensionMod.Tiles.Biomes.Void;

namespace MultidimensionMod.Tiles.Ores
{
    public class ApocalyptitePlaced : ModTile
    {
        private Asset<Texture2D> glowTexture;
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<DoomstonePlaced>()] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileOreFinderPriority[Type] = 860;
            Main.tileBlockLight[Type] = true;
            HitSound = SoundID.Tink;   
            DustType = ModContent.DustType<Dusts.DoomDust>();
            LocalizedText name = CreateMapEntryName();
            //name.SetDefault("Apocalyptite Ore");
            AddMapEntry(new Color(70, 20, 20), name);
			MinPick = 225;
            if (!Main.dedServ)
                glowTexture = ModContent.Request<Texture2D>(Texture + "_Glow");
        }

        public override void ModifyLight(int x, int y, ref float r, ref float g, ref float b)
        {
            Color color = BaseUtility.ColorMult(Color.DarkRed, 0.7f);
            r = color.R / 255f; g = color.G / 255f; b = color.B / 255f;
        }

        public override void PostDraw(int x, int y, SpriteBatch sb)
        {
            Tile tile = Main.tile[x, y];
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            int height = tile.TileFrameY == 36 ? 18 : 16;
            Main.spriteBatch.Draw(glowTexture.Value, new Vector2((x * 16) - (int)Main.screenPosition.X, (x * 16) - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}