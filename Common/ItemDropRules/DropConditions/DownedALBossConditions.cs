using MultidimensionMod.Common.Systems;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;

namespace MultidimensionMod.Common.ItemDropRules.DropConditions
{
    public class DownedMushroomMonarchCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public DownedMushroomMonarchCondition()
        {
            Description ??= Language.GetOrRegister("Mods.MultidimensionMod.DropConditions.DownedMushroomMonarchCondition");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            return DownedSystem.downedMonarch;
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

    public class DownedFeudalFungusCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public DownedFeudalFungusCondition()
        {
            Description ??= Language.GetOrRegister("Mods.MultidimensionMod.DropConditions.DownedFeudalFungusCondition");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            return DownedSystem.downedFungus;
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

    public class DownedSmileyCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public DownedSmileyCondition()
        {
            Description ??= Language.GetOrRegister("Mods.MultidimensionMod.DropConditions.DownedSmileyCondition");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            return DownedSystem.downedSmiley;
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