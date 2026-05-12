using MultidimensionMod.NPCs.Bosses.MushroomMonarch;
using Terraria.ModLoader;

namespace MultidimensionMod.Achievements;

public class MonarchAchievement : ModAchievement
{
    public override void SetStaticDefaults()
    {
        AddNPCKilledCondition(ModContent.NPCType<MushroomMonarch>());
    }

    //public override Position GetDefaultPosition() => new After("EYE_ON_YOU");
}