using MultidimensionMod.NPCs.Bosses.Grips;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;

namespace MultidimensionMod.Common.ItemDropRules.DropConditions
{
    public class MissingGripCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public MissingGripCondition()
        {
            Description ??= Language.GetOrRegister("Mods.MultidimensionMod.DropConditions.MissingGripCondition");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            int type = ModContent.NPCType<GripOfChaosRed>();
            if (info.npc.type == ModContent.NPCType<GripOfChaosRed>())
            {
                type = ModContent.NPCType<GripOfChaosBlue>();
            }

            return !NPC.AnyNPCs(type);
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return null;
        }
    }
}