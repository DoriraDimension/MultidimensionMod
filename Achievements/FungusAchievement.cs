using MultidimensionMod.NPCs.Bosses.FeudalFungus;
using Terraria.ModLoader;

namespace MultidimensionMod.Achievements;

public class FungusAchievement : ModAchievement
{
    public override void SetStaticDefaults()
    {
        AddNPCKilledCondition(ModContent.NPCType<FeudalFungus>());
    }

    //public override Position GetDefaultPosition() => new After("EYE_ON_YOU");
}