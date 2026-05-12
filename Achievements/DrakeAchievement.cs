using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Achievements;
using Terraria.Achievements;

namespace MultidimensionMod.Achievements
{
    public class DrakeAchievement : ModAchievement
    {
        public CustomFlagCondition DrakeFedCondition { get; private set; }

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Explorer);
            DrakeFedCondition = AddCondition();
        }
    }
}