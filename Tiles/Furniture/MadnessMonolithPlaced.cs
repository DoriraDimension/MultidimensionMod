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
            TileObjectData.newTile.Width = 4;
            TileObjectData.newTile.Origin = new Point16(2, 3);
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16 };
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop, 4, 0);
            TileObjectData.addTile(Type);
            RegisterItemDrop(ModContent.ItemType<MadnessMonolith>());
            AddMapEntry(new Color(7, 7, 7));
            DustType = ModContent.DustType<MadnessY>();
            AnimationFrameHeight = 56;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {

            Player player = Main.LocalPlayer;
            if (Main.tile[i, j].TileFrameY < 72)
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

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter >= 7.2)
            {
                frameCounter = 0;
                if (++frame >= 3)
                {
                    frame = 0;
                }
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
            int x = i - Main.tile[i, j].TileFrameX / 18 % 4;
            int y = j - Main.tile[i, j].TileFrameY / 18 % 4;
            int tileXX18 = 18 * 4;
            for (int l = x; l < x + 4; l++)
            {
                for (int m = y; m < y + 4; m++)
                {
                    if (Main.tile[l, m].HasTile && Main.tile[l, m].TileType == Type)
                    {
                        if (Main.tile[l, m].TileFrameY < tileXX18)
                            Main.tile[l, m].TileFrameY += (short)(tileXX18);
                        else
                            Main.tile[l, m].TileFrameY -= (short)(tileXX18);
                    }
                }
            }
            if (Wiring.running)
            {
                for (int o = 0; o < 4; o++)
                {
                    for (int p = 0; p < 4; p++)
                    {
                        Wiring.SkipWire(x + 0, x + p);
                    }
                }
            }
            NetMessage.SendTileSquare(-1, x, y + 1, 3);
        }
    }
}