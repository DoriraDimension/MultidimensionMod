using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class MuddyGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Muddy Geode");
			Tooltip.SetDefault("A geode found in the Jungle.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve Jungle minerals.");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 24;
			Item.rare = ItemRarityID.Lime;
			Item.maxStack = 99;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			var source = player.GetSource_OpenItem(Type);
			int choice = Main.rand.Next(2);
			if (choice == 0)
			{
				player.QuickSpawnItem(source, ItemID.ChlorophyteOre, 30);
			}
			else if (choice == 1)
			{
				player.QuickSpawnItem(source, ItemID.MudBlock, 50);
			}
		}
	}
}