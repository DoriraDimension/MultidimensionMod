using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Achievements;
using Terraria.Achievements;

namespace MultidimensionMod.Achievements
{
    public class EyeAchievement : ModAchievement
    {
        public CustomFlagCondition OmniEyeCondition { get; private set; }

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);
            OmniEyeCondition = AddCondition();
        }
    }
}