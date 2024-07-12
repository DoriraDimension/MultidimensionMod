using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using ReLogic.Content;
using MultidimensionMod.Tiles.Biomes.Mire;
using Terraria.Audio;

namespace MultidimensionMod.Tiles.Ores
{
    public class AbyssiumOrePlaced : ModTile
    {
        private Asset<Texture2D> glowTexture;
        public static readonly SoundStyle MineSound = new SoundStyle("MultidimensionMod/Sounds/Tiles/DreadsoilHit", 3);
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileOreFinderPriority[Type] = 330; 
            Main.tileSpelunker[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<DenseBiomatterPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthsandPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DankDepthstonePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthsandstonePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthsandHardenedPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<PermafrostPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthIce>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthstonePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<MireGrass>()] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMerge[TileID.Mud][Type] = true;
            Main.tileMerge[Type][TileID.Mud] = true;
            TileID.Sets.JungleSpecial[Type] = true;
            HitSound = AbyssiumOrePlaced.MineSound;
            Main.tileLighted[Type] = true; 
            DustType = ModContent.DustType<AbyssiumDust>();
            LocalizedText name = CreateMapEntryName();
            //name.SetDefault("Abyssium Ore");
            AddMapEntry(new Color(0, 0, 51), name);
			MinPick = 65;
            if (!Main.dedServ)
                glowTexture = ModContent.Request<Texture2D>(Texture + "_Glow");
        }


        public override bool CanExplode(int i, int j)
        {
            return false;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            int height = tile.TileFrameY == 36 ? 18 : 16;
            Main.spriteBatch.Draw(glowTexture.Value, new Vector2((i * 16) - (int)Main.screenPosition.X, (j * 16) - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)   //light colors
        {
            r = 0;
            g = 0.1f;
            b = 0.25f;
        }
    }
}