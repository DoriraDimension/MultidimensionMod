using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;

namespace MultidimensionMod.Common.ItemDropRules.DropConditions
{
    public class DownedSkeletronCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public DownedSkeletronCondition()
        {
            Description ??= Language.GetOrRegister("Mods.MultidimensionMod.DropConditions.DownedSkeletronCondition");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            return NPC.downedBoss3;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return Description.Value;
        }
    }
}