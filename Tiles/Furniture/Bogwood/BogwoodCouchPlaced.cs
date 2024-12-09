using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent;

namespace MultidimensionMod.Tiles.Furniture.Bogwood
{
    public class BogwoodCouchPlaced : ModTile
	{
        public const int NextStyleHeight = 40;
        public override void SetStaticDefaults()
		{
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.CanBeSatOnForPlayers[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            //name.SetDefault("Bogwood Couch");
            AddMapEntry(new Color(12, 62, 205), name);
            DustType = ModContent.DustType<Dusts.BogwoodDust>();
            AdjTiles = new int[] { TileID.Benches };
        }

		
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

        public override void ModifySittingTargetInfo(int i, int j, ref TileRestingInfo info)
        {
            Tile tile = Framing.GetTileSafely(i, j);

            info.TargetDirection = -1;
            if (tile.TileFrameX != 0)
            {
                info.TargetDirection = 1;
            }


            info.AnchorTilePosition.X = i;
            info.AnchorTilePosition.Y = j;

            if (tile.TileFrameY % NextStyleHeight == 0)
            {
                info.AnchorTilePosition.Y++;
            }
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;

            if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
            {
                player.GamepadEnableGrappleCooldown();
                player.sitting.SitDown(player, i, j);
            }

            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;

            if (!player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
            {
                return;
            }

            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<Items.Placeables.Furniture.BogwoodF.BogwoodCouch>();

            if (Main.tile[i, j].TileFrameX / 18 < 1)
            {
                player.cursorItemIconReversed = true;
            }
        }
    }
}
