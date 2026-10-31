using System.Collections.Generic;
using System.IO;
using System.Linq;
using Humanizer;
using Microsoft.Xna.Framework;
using MultidimensionMod.Biomes;
using MultidimensionMod.Dusts;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Drives;
using MultidimensionMod.Items.Placeables;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using MultidimensionMod.Sounds;
using ReLogic.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles
{
	public class DimensionalForge : ModTile
	{
		public int StoredDimensionalEnergy;
        public const int Height = 2;
        public const int Width = 3;
        public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.HookPostPlaceMyPlayer = ModContent.GetInstance<DimensionalForgeTileEntity>().Generic_HookPostPlaceMyPlayer;
            TileID.Sets.DisableSmartCursor[Type] = true;
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(35, 189, 236), name);
			DustType = ModContent.DustType<DimensionDust1>();
			AnimationFrameHeight = 38;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 5;
		}

		public override void AnimateTile(ref int frame, ref int frameCounter)
		{

			frameCounter++;
			if (frameCounter > 6) 
			{
				frameCounter = 0;
				frame++;
				if (frame > 5)
				{
					frame = 0;
				}
			}
		}

        public override bool CanExplode(int i, int j) => false;

        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
        {
            Point16 position = new Point16(i, j);
            if (TileEntity.ByPosition.TryGetValue(position, out TileEntity entity) && entity is DimensionalForgeTileEntity forge)
            {
                if (forge.IsAnalysing)
                {
                    return false;
                }
            }
            return true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Point16 position = new Point16(i, j);
            if (TileEntity.ByPosition.TryGetValue(position, out TileEntity entity) && entity is DimensionalForgeTileEntity forge)
            {
                if (forge.IsEquippedWithMadnessDrive)
                {
                    forge.IsEquippedWithMadnessDrive = false;
                }
                forge.IsAnalysing = false;
                forge.AnalyseTimer = 0;
                forge.CurrentlyAnalysingMadnessDrive = false;
            }
            ModContent.GetInstance<DimensionalForgeTileEntity>().Kill(i, j);
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            Point16 position = new Point16(i, j);
            yield return new Item(ModContent.ItemType<DimensionalForgeItem>());
            if (TileEntity.ByPosition.TryGetValue(position, out TileEntity entity) && entity is DimensionalForgeTileEntity forge)
            {
                if (forge.IsEquippedWithMadnessDrive)
                {
                    yield return new Item(ModContent.ItemType<MadnessDrive>());
                    forge.IsEquippedWithMadnessDrive = false;
                }
            }
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Framing.GetTileSafely(i, j);

            int left = i - (tile.TileFrameX % (18 * Width)) / 18;
            int top = j - (tile.TileFrameY % (18 * Height)) / 18;
            Point16 position = new Point16(left, top);

            if (TileEntity.ByPosition.TryGetValue(position, out TileEntity entity) && entity is DimensionalForgeTileEntity forge)
            {
                if (!forge.IsAnalysing)
                {
                    if (player.HeldItem.ModItem is MadnessDrive && !forge.IsEquippedWithMadnessDrive)
                    {
                        if (RememberAnalysis.AnalysedMadnessDrive)
                        {
                            player.HeldItem.stack--;
                            forge.IsEquippedWithMadnessDrive = true;
                            return true;
                        }
                        else
                        {
                            CombatText.NewText(player.getRect(), MDColors.AdminColor, Language.GetTextValue("Mods.MultidimensionMod.MiscText.Analysing"), true, false);
                            player.HeldItem.stack--;
                            forge.IsAnalysing = true;
                            forge.CurrentlyAnalysingMadnessDrive = true;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }

    public class DimensionalForgeTileEntity : ModTileEntity
    {
        public bool IsEquippedWithMadnessDrive;
        public bool IsEquippedWithDarkMatterDrive;
        public bool IsAnalysing;
        public bool CurrentlyAnalysingMadnessDrive;
        public int AnalyseTimer;
        private ActiveSound AnalysisSound;
        private SlotId AnalysisLoop;

        public override bool IsTileValidForEntity(int x, int y)
        {
            Tile tile = Main.tile[x, y];

            bool valid = tile.HasTile &&
                         tile.TileType == ModContent.TileType<DimensionalForge>();

            return valid;
        }
        public Vector2 ForgePosition => Position.ToWorldCoordinates(8f * DimensionalForge.Width, 8f * DimensionalForge.Height);
        public override void Update()
        {
            Player player = Main.LocalPlayer;
            if (IsAnalysing)
            {
                AnalyseTimer++;
                if (AnalysisSound == null)
                {
                    AnalysisLoop = SoundEngine.PlaySound(CustomSounds.AnalysisLoop with { Volume = 0.50f }, ForgePosition);

                }
                if (SoundEngine.TryGetActiveSound(AnalysisLoop, out AnalysisSound))
                {
                    AnalysisSound.Position = ForgePosition;
                }
            }
            if (!IsAnalysing)
            {
                if (AnalysisSound != null)
                {
                    AnalysisSound.Stop();
                    AnalysisLoop = SlotId.Invalid;
                }
            }
            if (AnalyseTimer >= 600)
            {
                if (CurrentlyAnalysingMadnessDrive)
                {
                    CombatText.NewText(player.getRect(), MDColors.AdminColor, Language.GetTextValue("Mods.MultidimensionMod.MiscText.AnalysisDone"), true, false);
                    SoundEngine.PlaySound(CustomSounds.AnalysisDone, ForgePosition);
                    IsEquippedWithMadnessDrive = true;
                    RememberAnalysis.AnalysedMadnessDrive = true;
                }
                IsAnalysing = false;
                AnalyseTimer = 0;
            }
        }
    }

    public class RememberAnalysis : ModSystem
    {
        public static bool AnalysedMadnessDrive;
        public static bool AnalysedDarkMatterDrive;

        public override void OnWorldLoad()
        {
            AnalysedMadnessDrive = false;
            AnalysedDarkMatterDrive = false;
        }

        public override void OnWorldUnload()
        {
            AnalysedMadnessDrive = false;
            AnalysedDarkMatterDrive = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            var analysed = new List<string>();

            if (AnalysedMadnessDrive)
                analysed.Add("AnalysedMadnessDrive");
            if (AnalysedDarkMatterDrive)
                analysed.Add("AnalysedDarkMatterDrive");

            tag["analysed"] = analysed;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var analysed = tag.GetList<string>("analysed");

            AnalysedMadnessDrive = analysed.Contains("AnalysedMadnessDrive");
            AnalysedDarkMatterDrive = analysed.Contains("AnalysedDarkMatterDrive");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = AnalysedMadnessDrive;
            flags[1] = AnalysedDarkMatterDrive;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            AnalysedMadnessDrive = flags[0];
            AnalysedDarkMatterDrive = flags[1];
        }
    }
}