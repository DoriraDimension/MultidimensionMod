using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Achievements;
using Terraria.Achievements;

namespace MultidimensionMod.Achievements
{
    public class ShimmerFishAchievement : ModAchievement
    {
        public CustomFlagCondition ShimmerFishCondition { get; private set; }

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);
            ShimmerFishCondition = AddCondition();
        }
    }
}