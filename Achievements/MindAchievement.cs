using MultidimensionMod.NPCs.Madness;
using Terraria.ModLoader;

namespace MultidimensionMod.Achievements;

public class MindAchievement : ModAchievement
{
    public override void SetStaticDefaults()
    {
        AddNPCKilledCondition(ModContent.NPCType<AMindFromBeyond>());
    }

    //public override Position GetDefaultPosition() => new After("EYE_ON_YOU");
}