using MultidimensionMod.Tiles.FrozenUnderworld;
using MultidimensionMod.Items.Weapons.Typeless;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace MultidimensionMod
{
    public class MDGlobalTile : GlobalTile
    {
        public override void RandomUpdate(int i, int j, int type)
        {
            if (type == ModContent.TileType<ColdAsh>() && Main.rand.NextBool(1000))
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<Iceblossom>(), mute: true);
            }
        }

        public override bool Drop(int i, int j, int type)
        {
            if (Main.player[Main.myPlayer].GetModPlayer<MDPlayer>().Geodes)
            {
                if (TileID.Sets.Conversion.Stone[type] && Main.rand.NextBool(100))
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<Geode>(), 1, false, 0, false, false);
                }
            }
            else
                if (TileID.Sets.Conversion.Stone[type] && Main.rand.NextBool(200))
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<Geode>(), 1, false, 0, false, false);
                }
            if (Main.player[Main.myPlayer].GetModPlayer<MDPlayer>().Geodes && Main.hardMode)
            {
                if (TileID.Sets.Conversion.Stone[type] && Main.rand.NextBool(100))
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<OmniGeode>(), 1, false, 0, false, false);
                }
            }
            else
                if (TileID.Sets.Conversion.Stone[type] && Main.rand.NextBool(200) && Main.hardMode)
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<OmniGeode>(), 1, false, 0, false, false);
                }
            if (Main.player[Main.myPlayer].GetModPlayer<MDPlayer>().Geodes)
            {
                if (TileID.Sets.Conversion.Ice[type] && Main.rand.NextBool(100))
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<FrozenGeode>(), 1, false, 0, false, false);
                }
            }
            else
                if (TileID.Sets.Conversion.Ice[type] && Main.rand.NextBool(200))
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<FrozenGeode>(), 1, false, 0, false, false);
                }
            if (Main.player[Main.myPlayer].GetModPlayer<MDPlayer>().Geodes)
            {
                if (TileID.Sets.Conversion.Sandstone[type] && Main.rand.NextBool(100) || TileID.Sets.Conversion.HardenedSand[type] && Main.rand.NextBool(100))
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<SandstoneGeode>(), 1, false, 0, false, false);
                }
            }
            else
                if (TileID.Sets.Conversion.Sandstone[type] && Main.rand.NextBool(200) || TileID.Sets.Conversion.HardenedSand[type] && Main.rand.NextBool(200))
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<SandstoneGeode>(), 1, false, 0, false, false);
                }
            if (Main.player[Main.myPlayer].GetModPlayer<MDPlayer>().Geodes)
            {
                if (MDSets.Tiles.EbonBlocks[type] && Main.rand.NextBool(100))
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<DecayGeode>(), 1, false, 0, false, false);
                }
            }
            else
                if (MDSets.Tiles.EbonBlocks[type] && Main.rand.NextBool(200))
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<DecayGeode>(), 1, false, 0, false, false);
                }
            if (Main.player[Main.myPlayer].GetModPlayer<MDPlayer>().Geodes)
            {
                if (MDSets.Tiles.CrimBlocks[type] && Main.rand.NextBool(100))
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<BloodGeode>(), 1, false, 0, false, false);
                }
            }
            else
                if (MDSets.Tiles.CrimBlocks[type] && Main.rand.NextBool(200))
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<BloodGeode>(), 1, false, 0, false, false);
                }
            if (Main.player[Main.myPlayer].GetModPlayer<MDPlayer>().Geodes && Main.hardMode)
            {
                if (MDSets.Tiles.JungleBlocks[type] && Main.rand.NextBool(100))
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<MuddyGeode>(), 1, false, 0, false, false);
                }
            }
            else
                if (MDSets.Tiles.JungleBlocks[type] && Main.rand.NextBool(200) && Main.hardMode)
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<MuddyGeode>(), 1, false, 0, false, false);
                }
            if (Main.player[Main.myPlayer].GetModPlayer<MDPlayer>().Geodes)
            {
                if (MDSets.Tiles.HellBlocks[type] && Main.rand.NextBool(100))
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<MagmaGeode>(), 1, false, 0, false, false);
                }
            }
            else
                if (MDSets.Tiles.HellBlocks[type] && Main.rand.NextBool(200))
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<MagmaGeode>(), 1, false, 0, false, false);
                }
            if (Main.player[Main.myPlayer].GetModPlayer<MDPlayer>().Geodes)
            {
                if (MDSets.Tiles.HallowBlocks[type] && Main.rand.NextBool(100) && Main.hardMode)
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<FairyGeode>(), 1, false, 0, false, false);
                }
            }
            else
                if (MDSets.Tiles.HallowBlocks[type] && Main.rand.NextBool(200) && Main.hardMode)
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<FairyGeode>(), 1, false, 0, false, false);
                }
            return base.Drop(i, j, type);
        }
    }
}