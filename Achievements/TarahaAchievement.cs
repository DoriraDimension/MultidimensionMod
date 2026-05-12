using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Achievements;
using Terraria.Achievements;

namespace MultidimensionMod.Achievements
{
    public class TarahaAchievement : ModAchievement
    {
        public CustomFlagCondition TarahaTradeCondition { get; private set; }

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Explorer);
            TarahaTradeCondition = AddCondition();
        }
    }
}