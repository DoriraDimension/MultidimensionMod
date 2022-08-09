using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Typeless
{
	public class MoonGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moon Geode");
			Tooltip.SetDefault("A geode found in the space layer after the lord of the moon fell.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve Luminite.");
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 22;
			Item.rare = ItemRarityID.Red;
			Item.maxStack = 99;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			var source = player.GetSource_OpenItem(Type);
			int choice = Main.rand.Next(1);
			if (choice == 0)
			{
				player.QuickSpawnItem(source, ItemID.LunarOre, 40);
			}
		}
	}
}