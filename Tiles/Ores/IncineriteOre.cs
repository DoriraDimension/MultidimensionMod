using MultidimensionMod.Dusts;
using MultidimensionMod.Base;
using MultidimensionMod.Tiles.Biomes.Inferno;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using ReLogic.Content;

namespace MultidimensionMod.Tiles.Ores
{
    public class IncineriteOre : ModTile
    {
        private Asset<Texture2D> glowTexture;

        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 340; 
            Main.tileMerge[Type][ModContent.TileType<TorchstonePlaced>()] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            HitSound = SoundID.Tink;  
            DustType = ModContent.DustType<IncineriteDust>();
            LocalizedText name = CreateMapEntryName();
            //name.SetDefault("Incinerite Ore");
            AddMapEntry(new Color(204, 102, 0), name);
			MinPick = 65;
            if (!Main.dedServ)
                glowTexture = ModContent.Request<Texture2D>(Texture + "_Glow");
        }


        public override bool CanExplode(int i, int j)
        {
            return false;
        }

        public override void ModifyLight(int x, int y, ref float r, ref float g, ref float b)
        {
            Color color = BaseUtility.ColorMult(MDColors.IncineriteColor, 0.7f);
            r = color.R / 255f; g = color.G / 255f; b = color.B / 255f;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            Vector2 zero = new(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
                zero = Vector2.Zero;

            int height = tile.TileFrameY == 36 ? 18 : 16;

            Main.spriteBatch.Draw(glowTexture.Value, new Vector2((i * 16) - (int)Main.screenPosition.X, (j * 16) - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), Color.White, 0f, Vector2.Zero, 1f, 0, 0f);
        }
    }
}