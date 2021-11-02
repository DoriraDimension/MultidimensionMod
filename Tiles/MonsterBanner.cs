using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles
{
	public class MonsterBanner : ModTile
	{
		public override void SetDefaults()
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
			TileObjectData.addTile(Type);
			dustType = -1;
			disableSmartCursor = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Banner");
			AddMapEntry(new Color(13, 88, 130), name);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			int style = frameX / 18;
			string item;
			switch (style)
			{
				case 0:
					item = "DarklingBanner";
					break;
				case 1:
					item = "InfestedBanner";
					break;
				case 2:
					item = "TridentBanner";
					break;
				case 3:
					item = "GlowmarinBanner";
					break;
				case 4:
					item = "StormEelBanner";
					break;
				case 5:
					item = "ParrotLobsterBanner";
					break;
				case 6:
					item = "BabyGlowmarinBanner";
					break;
				case 7:
					item = "BbyDrakeBanner";
					break;
				case 8:
					item = "FrostburnSlimeBanner";
					break;
				case 9:
					item = "LesserSandEleBanner";
					break;
				case 10:
					item = "GilaBanner";
					break;
				default:
					return;
			}
			Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType(item));
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (closer)
			{
				Player player = Main.LocalPlayer;
				int style = Main.tile[i, j].frameX / 18;
				string type;
				switch (style)
				{
					case 0:
						type = "Darkling";
						break;
					case 1:
						type = "CorrGuy";
						break;
					case 2:
						type = "MagicTrident";
						break;
					case 3:
						type = "OtherworldlyGlowmarin";
						break;
					case 4:
						type = "StormFrontEel";
						break;
					case 5:
						type = "ParrotLobster";
						break;
					case 6:
						type = "BabyGlowmarin";
						break;
					case 7:
						type = "IceDrakeJuvenile";
						break;
					case 8:
						type = "FrostburnSlime";
						break;
					case 9:
						type = "LesserSandElemental";
						break;
					case 10:
						type = "GilaMonster";
						break;
					default:
						return;
				}
				player.NPCBannerBuff[mod.NPCType(type)] = true;
				player.hasBanner = true;
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
