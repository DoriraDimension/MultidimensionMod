using MultidimensionMod.NPCs.Bosses.Smiley;
using Terraria.ModLoader;

namespace MultidimensionMod.Achievements;

public class SmileyAchievement : ModAchievement
{
    public override void SetStaticDefaults()
    {
        AddNPCKilledCondition(ModContent.NPCType<Smiley>());
    }

    //public override Position GetDefaultPosition() => new After("EYE_ON_YOU");
}