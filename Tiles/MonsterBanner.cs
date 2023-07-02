using MultidimensionMod.NPCs.Dungeon;
using MultidimensionMod.NPCs.Corruption;
using MultidimensionMod.NPCs.Tundra;
using MultidimensionMod.NPCs.Ocean;
using MultidimensionMod.NPCs.Desert;
using MultidimensionMod.NPCs.Critters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles
{
	public class MonsterBanner : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.StyleWrapLimit = 111;
			TileID.Sets.DisableSmartCursor[Type] = true;
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(13, 88, 130), name);
			DustType = -1;
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (closer)
			{
				Player player = Main.LocalPlayer;
				int style = Main.tile[i, j].TileFrameX / 18;
				int type = 0;
				switch (style)
				{
					case 0:
						type = ModContent.NPCType<Darkling>();
						break;
					case 1:
						type = ModContent.NPCType<CorrGuy>();
						break;
					case 2:
						//type = ModContent.NPCType<MagicTrident>();
						break;
					case 3:
						type = ModContent.NPCType<OtherworldlyGlowmarin>();
						break;
					case 4:
						type = ModContent.NPCType<StormFrontEel>();
						break;
					case 5:
						type = ModContent.NPCType<ParrotLobster>();
						break;
					case 6:
						type = ModContent.NPCType<BabyGlowmarin>();
						break;
					case 7:
						type = ModContent.NPCType<IceDrakeJuvenile>();
						break;
					case 8:
						//type = ModContent.NPCType<FrostburnSlime>();
						break;
					case 9:
						type = ModContent.NPCType<LesserSandElemental>();
						break;
					case 10:
						type = ModContent.NPCType<GilaMonster>();
						break;
					default:
						return;
				}
				Main.SceneMetrics.NPCBannerBuff[type] = true;
				Main.SceneMetrics.hasBanner = true;
			}
		}

		public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
		{
			if (i % 2 == 1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}
	}
}
