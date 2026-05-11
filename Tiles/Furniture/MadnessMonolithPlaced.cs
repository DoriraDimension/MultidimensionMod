using MultidimensionMod.Dusts;
using MultidimensionMod.Items.Placeables.Furniture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Graphics.Effects;

namespace MultidimensionMod.Tiles.Furniture
{
    public class MadnessMonolithPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.Origin = new Point16(1, 3);
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16};
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop, 4, 0);
            TileObjectData.addTile(Type);
            RegisterItemDrop(ModContent.ItemType<MadnessMonolith>());
            AddMapEntry(new Color(7, 7, 7));
            DustType = ModContent.DustType<MadnessY>();
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            Player player = Main.LocalPlayer;
            if (Main.tile[i, j].TileFrameY < 71)
            {
                SkyManager.Instance.Deactivate("MadnessMoonSky");
                player.ManageSpecialBiomeVisuals("MultidimensionMod:Madness", false);
                return;
            }

            if (player is null)
            {
                return;
            }

            if (player.active)
            {
                SkyManager.Instance.Activate("MadnessMoonSky");
                player.ManageSpecialBiomeVisuals("MultidimensionMod:Madness", true);
            }
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<MadnessMonolith>();
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

        public override bool RightClick(int i, int j)
        {
            HitWire(i, j);
            SoundEngine.PlaySound(SoundID.Mech, new Vector2(i * 16, j * 16));
            return true;
        }

        public override void HitWire(int i, int j)
        {
            int left = i - Main.tile[i, j].TileFrameX / 18 % 2;
            int top = j - Main.tile[i, j].TileFrameY / 18 % 4;
            for (int x = left; x < left + 2; x++)
            {
                for (int y = top; y < top + 4; y++)
                {

                    if (Main.tile[x, y].TileFrameY >= 72)
                        Main.tile[x, y].TileFrameY -= 72;
                    else
                        Main.tile[x, y].TileFrameY += 72;
                }
            }
            if (Wiring.running)
            {
                Wiring.SkipWire(left, top);
                Wiring.SkipWire(left, top + 1);
            }
            NetMessage.SendTileSquare(-1, left, top + 1, 2);
        }
    }
}