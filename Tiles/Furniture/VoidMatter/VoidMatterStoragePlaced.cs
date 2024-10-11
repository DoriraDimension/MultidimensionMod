using MultidimensionMod.Items.Placeables.Furniture.VoidMatter;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Audio;

namespace MultidimensionMod.Tiles.Furniture.VoidMatter
{
	public class VoidMatterStoragePlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileContainer[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1200;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, false);
			TileObjectData.newTile.AnchorInvalidTiles = new[] { 127 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileID.Sets.HasOutlines[Type] = true;
			TileID.Sets.BasicChest[Type] = true;
			TileID.Sets.DisableSmartCursor[Type] = true;
			TileObjectData.newTile.AnchorInvalidTiles = new[] { 127 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(25, 19, 39), name);
			DustType = ModContent.DustType<DarkDust>();
			HitSound = SoundID.Dig;
			AdjTiles = new int[]
			{
				TileID.Containers
			};
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 1;
		}

        public override LocalizedText DefaultContainerName(int frameX, int frameY) => CreateMapEntryName();

        public override IEnumerable<Item> GetItemDrops(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			yield return new Item(ModContent.ItemType<VoidMatterStorage>());
		}

		public string MapChestName(string name, int i, int j)
		{
			int left = i;
			int top = j;

			Tile tile = Main.tile[i, j];

			if (tile.TileFrameX % 36 != 0)
			{
				left--;
			}

			if (tile.TileFrameY != 0)
			{
				top--;
			}

			int chest = Chest.FindChest(left, top);

			if (Main.chest[chest].name == "")
			{
				return name;
			}

			return name + ": " + Main.chest[chest].name;
		}

		public override bool RightClick(int i, int j)
		{
			Player player = Main.LocalPlayer;

			Tile tile = Main.tile[i, j];

			int left = i;
			int top = j;

			if (tile.TileFrameX % 36 != 0)
			{
				left--;
			}

			if (tile.TileFrameY != 0)
			{
				top--;
			}

			if (player.sign >= 0)
			{
				SoundEngine.PlaySound(SoundID.MenuClose);

				Main.npcChatText = "";

				player.sign = -1;
			}

			if (Main.editChest)
			{
				SoundEngine.PlaySound(SoundID.MenuTick);

				Main.npcChatText = "";
			}

			if (player.editedChestName)
			{
				NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f);

			}

			if (Main.netMode == NetmodeID.MultiplayerClient)
			{
				if (left == player.chestX && top == player.chestY && player.chest >= 0)
				{
					player.chest = -1;

					Recipe.FindRecipes();

					SoundEngine.PlaySound(SoundID.MenuClose);
				}
				else
				{
					NetMessage.SendData(MessageID.RequestChestOpen, -1, -1, null, left, top);

					Main.stackSplit = 600;
				}
			}
			else
			{
				int chest = Chest.FindChest(left, top);

				if (chest >= 0)
				{
					Main.stackSplit = 600;

					if (chest == player.chest)
					{
						player.chest = -1;

						SoundEngine.PlaySound(SoundID.MenuClose);
					}
					else
					{
						Main.playerInventory = true;

						player.chest = chest;

						player.chestX = left;
						player.chestY = top;

						SoundEngine.PlaySound(player.chest < 0 ? SoundID.MenuOpen : SoundID.MenuTick);
					}

					Recipe.FindRecipes();
				}
			}

			return true;
		}

		public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;

			Tile tile = Main.tile[i, j];

			int left = i;
			int top = j;

			if (tile.TileFrameX % 36 != 0)
			{
				left--;
			}

			if (tile.TileFrameY != 0)
			{
				top--;
			}

			int chest = Chest.FindChest(left, top);

			player.cursorItemIconID = -1;

			if (chest < 0)
			{
				player.cursorItemIconText = Language.GetTextValue("LegacyChestType.0");
			}
			else
			{
				player.cursorItemIconText = Main.chest[chest].name.Length > 0 ? Main.chest[chest].name : "Void Matter Storage";

				if (player.cursorItemIconText == "Void Matter Storage")
				{
					player.cursorItemIconID = ModContent.ItemType<VoidMatterStorage>();
					player.cursorItemIconText = "";
				}
			}

			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
		}

		public override void MouseOverFar(int i, int j)
		{
			MouseOver(i, j);

			Player player = Main.LocalPlayer;

			if (player.cursorItemIconText == "")
			{
				player.cursorItemIconID = 0;
			}
		}
	}
}