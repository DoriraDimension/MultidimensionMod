using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Typeless
{
	public class DecayGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Decay Geode");
			Tooltip.SetDefault("A geode found in the Corruption.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve Corruption minerals.");
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 20;
			Item.rare = ItemRarityID.Green;
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
				player.QuickSpawnItem(source, ItemID.DemoniteOre, 20);
			}
			else if (choice == 1)
			{
				player.QuickSpawnItem(source, ItemID.EbonstoneBlock, 50);
			}
			else if (choice == 2)
			{
				player.QuickSpawnItem(source, ModContent.ItemType<OldTaintedGun>());
			}
		}
	}
}