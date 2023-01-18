using Terraria.ID;

namespace MultidimensionMod
{
    internal static class MDSets
    {
        #region Tiles
        internal static bool[] EbonBlocks = TileID.Sets.Factory.CreateBoolSet(25, 112, 400, 398, 163);

        internal static bool[] CrimBlocks = TileID.Sets.Factory.CreateBoolSet(203, 234, 401, 399, 200);

        internal static bool[] HallowBlocks = TileID.Sets.Factory.CreateBoolSet(117, 116, 403, 402, 164);

        internal static bool[] HellBlocks = TileID.Sets.Factory.CreateBoolSet(57, 58);

        internal static bool[] JungleBlocks = TileID.Sets.Factory.CreateBoolSet(59);
        #endregion

        #region NPCs
        internal static bool[] DemonEyes = NPCID.Sets.Factory.CreateBoolSet(2, -43, 190, -38, 191, -39, 192, -40, 193, -41, 194, -42, 317, 318); //All Demon Eye variants

        internal static bool[] DropsHunterEye = NPCID.Sets.Factory.CreateBoolSet(6, -11, -12, 173, -22, -23); //Eater of Souls & Crimera (all sizes)

        internal static bool[] SkeletalEntity = NPCID.Sets.Factory.CreateBoolSet(21, -46, -47, 201, -48, -49, 202, -50, -51, 203, -52, -53, 322, 323, 324, 39); //All Skeleton variants & Bone Serpent

        internal static bool[] MossHornet = NPCID.Sets.Factory.CreateBoolSet(176, -18, -19, -20, -21); //All Moss Hornet sizes

        internal static bool[] DoesntDropDimensium = NPCID.Sets.Factory.CreateBoolSet(25, 30, 33, 371, 384, 516, 519, 521, 522, 523, 694, 665, 666, 112); //NPCs that aren't actual entities, like things shot from other NPCs 
        #endregion
    }
}