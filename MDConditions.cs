using MultidimensionMod.Common.Systems;
using Terraria.GameContent.ItemDropRules;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod
{
	public class SlimeCondition : IItemDropRuleCondition
	{
		public bool CanDrop(DropAttemptInfo info)
		{
			if (!info.IsInSimulation)
				return !NPC.downedSlimeKing;
			return false;
		}
		public bool CanShowItemDropInUI() => true;
		public string GetConditionDescription() => "Dropped once per world";
	}
}