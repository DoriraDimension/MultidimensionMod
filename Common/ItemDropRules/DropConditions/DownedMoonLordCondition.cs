using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;

namespace MultidimensionMod.Common.ItemDropRules.DropConditions
{
    public class DownedMoonLordCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public DownedMoonLordCondition()
        {
            Description ??= Language.GetOrRegister("Mods.MultidimensionMod.DropConditions.DownedMoonLordCondition");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            return NPC.downedMoonlord;
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