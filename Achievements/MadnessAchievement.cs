using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Achievements;
using Terraria.Achievements;

namespace MultidimensionMod.Achievements
{
    public class MadnessAchievement : ModAchievement
    {
        public CustomFlagCondition MadnessCondition { get; private set; }

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Explorer);
            MadnessCondition = AddCondition();
        }
    }
}