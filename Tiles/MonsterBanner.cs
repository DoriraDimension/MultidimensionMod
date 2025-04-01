using MultidimensionMod.NPCs.Dungeon;
using MultidimensionMod.NPCs.Corruption;
using MultidimensionMod.NPCs.Tundra;
using MultidimensionMod.NPCs.Ocean;
using MultidimensionMod.NPCs.Desert;
using MultidimensionMod.NPCs.Critters;
using MultidimensionMod.NPCs.Underworld;
using MultidimensionMod.NPCs.FU;
using MultidimensionMod.NPCs.Madness;
using MultidimensionMod.NPCs.MushBiomes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.GameContent.Drawing;

namespace MultidimensionMod.Tiles
{
	public class MonsterBanner : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.MultiTileSway[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 18 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom | AnchorType.PlanterBox, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.DrawYOffset = -2;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.Platform, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.DrawYOffset = -10;
            TileObjectData.addAlternate(0);
            TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(13, 88, 130), Language.GetText("MapObject.Banner"));
			DustType = -1;
		}

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                return;
            }

            int tileStyle = TileObjectData.GetTileStyle(Main.tile[i, j]);
            int itemType = TileLoader.GetItemDropFromTypeAndStyle(Type, tileStyle);
            int bannerID = NPCLoader.BannerItemToNPC(itemType);

            if (bannerID == -1)
            {
                return;
            }

            if (ItemID.Sets.BannerStrength.IndexInRange(itemType) && ItemID.Sets.BannerStrength[itemType].Enabled)
            {
                Main.SceneMetrics.NPCBannerBuff[bannerID] = true;
                Main.SceneMetrics.hasBanner = true;
            }
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];

            if (TileObjectData.IsTopLeft(tile))
            {
                Main.instance.TilesRenderer.AddSpecialPoint(i, j, TileDrawing.TileCounterType.MultiTileVine);
            }
            return false;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            offsetY += 2;
            return;
        }
    }
}
