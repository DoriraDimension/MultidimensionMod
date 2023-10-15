using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;

namespace MultidimensionMod.Common.ItemDropRules.DropConditions
{
    public class HardmodeCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public HardmodeCondition()
        {
            Description ??= Language.GetOrRegister("Mods.MultidimensionMod.DropConditions.HardmodeCondition");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            return Main.hardMode;
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