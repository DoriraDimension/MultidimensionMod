using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;

namespace MultidimensionMod.Common.ItemDropRules.DropConditions
{
    public class DimensiumCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public DimensiumCondition()
        {
            Description ??= Language.GetOrRegister("Mods.MultidimensionMod.DropConditions.DimensiumCondition");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            return true;
        }

        public bool CanShowItemDropInUI()
        {
            return false;
        }

        public string GetConditionDescription()
        {
            return Description.Value;
        }
    }
}