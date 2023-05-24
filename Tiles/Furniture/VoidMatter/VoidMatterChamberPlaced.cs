using MultidimensionMod.Items.Placeables.Furniture.VoidMatter;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;

namespace MultidimensionMod.Tiles.Furniture.VoidMatter
{
	public class VoidMatterChamberPlaced : ModTile
	{
		public const int NextStyleHeight = 38;

		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Width = 4;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileID.Sets.DisableSmartCursor[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;
			TileID.Sets.CanBeSleptIn[Type] = true; 
			TileID.Sets.InteractibleByNPCs[Type] = true;
			TileID.Sets.IsValidSpawnPoint[Type] = true;
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
			AdjTiles = new int[] { TileID.Beds };
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Void Matter Chamber");
			AddMapEntry(new Color(25, 19, 39), name);
			DustType = ModContent.DustType<DarkDust>();
		}

		public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
		{
			return true;
		}

		public override void ModifySmartInteractCoords(ref int width, ref int height, ref int frameWidth, ref int frameHeight, ref int extraY)
		{
			width = 2; 
			height = 2; 
		}

		public override void ModifySleepingTargetInfo(int i, int j, ref TileRestingInfo info)
		{
			info.VisualOffset.Y += 4f;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 1;
		}

		public override bool RightClick(int i, int j)
		{
			Player player = Main.LocalPlayer;
			Tile tile = Main.tile[i, j];
			int spawnX = (i - (tile.TileFrameX / 18)) + (tile.TileFrameX >= 72 ? 5 : 2);
			int spawnY = j + 2;

			if (tile.TileFrameY % NextStyleHeight != 0)
			{
				spawnY--;
			}

			if (!Player.IsHoveringOverABottomSideOfABed(i, j))
			{ // This assumes your bed is 4x2 with 2x2 sections. You have to write your own code here otherwise
				if (player.IsWithinSnappngRangeToTile(i, j, PlayerSleepingHelper.BedSleepingMaxDistance))
				{
					player.GamepadEnableGrappleCooldown();
					player.sleeping.StartSleeping(player, i, j);
				}
			}
			else
			{
				player.FindSpawn();

				if (player.SpawnX == spawnX && player.SpawnY == spawnY)
				{
					player.RemoveSpawn();
					Main.NewText(Language.GetTextValue("Game.SpawnPointRemoved"), byte.MaxValue, 240, 20);
				}
				else if (Player.CheckSpawn(spawnX, spawnY))
				{
					player.ChangeSpawn(spawnX, spawnY);
					Main.NewText(Language.GetTextValue("Game.SpawnPointSet"), byte.MaxValue, 240, 20);
				}
			}

			return true;
		}

		public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;

			if (!Player.IsHoveringOverABottomSideOfABed(i, j))
			{
				if (player.IsWithinSnappngRangeToTile(i, j, PlayerSleepingHelper.BedSleepingMaxDistance))
				{ // Match condition in RightClick. Interaction should only show if clicking it does something
					player.noThrow = 2;
					player.cursorItemIconEnabled = true;
					player.cursorItemIconID = ItemID.SleepingIcon;
				}
			}
			else
			{
				player.noThrow = 2;
				player.cursorItemIconEnabled = true;
				player.cursorItemIconID = ModContent.ItemType<VoidMatterChamber>();
			}
		}
	}
}