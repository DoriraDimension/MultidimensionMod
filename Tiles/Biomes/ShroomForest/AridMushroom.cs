using MultidimensionMod.Dusts;
using MultidimensionMod.NPCs.MushBiomes;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.ID;
using System;
using Terraria.DataStructures;

namespace MultidimensionMod.Tiles.Biomes.ShroomForest
{
    public class AridMushroom : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.RandomStyleRange = 5;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            TileID.Sets.SwaysInWindBasic[Type] = true;
            RegisterItemDrop(ItemID.Mushroom);
            DustType = ModContent.DustType<MushroomDust>();
            HitSound = SoundID.Grass;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 10;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (Main.rand.NextBool(50) && !fail && Main.netMode != NetmodeID.MultiplayerClient)
                NPC.NewNPC(new EntitySource_TileBreak(i, j), i * 16 + 8, j * 16 + 8, ModContent.NPCType<ShroomJelly>());
        }
    }
}