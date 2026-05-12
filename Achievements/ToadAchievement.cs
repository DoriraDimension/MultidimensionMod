using MultidimensionMod.NPCs.MushBiomes;
using Terraria.ModLoader;

namespace MultidimensionMod.Achievements;

public class ToadAchievement : ModAchievement
{
    public override void SetStaticDefaults()
    {
        AddNPCKilledCondition(ModContent.NPCType<TruffleToad>());
    }

    //public override Position GetDefaultPosition() => new After("EYE_ON_YOU");
}