using MultidimensionMod.Items.Accessories;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Typeless
{
	public class FairyGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fairy Geode");
			Tooltip.SetDefault("A geode found in the Hallow.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve Hallow minerals.");
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 28;
			Item.rare = ItemRarityID.LightRed;
			Item.maxStack = 99;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			var source = player.GetSource_OpenItem(Type);
			int choice = Main.rand.Next(3);
			if (choice == 0)
			{
				player.QuickSpawnItem(source, ItemID.CrystalShard, 15);
			}
			else if (choice == 1)
			{
				player.QuickSpawnItem(source, ItemID.PearlstoneBlock, 50);
			}
			else if (choice == 2)
			{
				player.QuickSpawnItem(source, ModContent.ItemType<MysticStone>());
			}
		}
	}
}