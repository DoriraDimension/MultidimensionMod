using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Typeless
{
	public class FrozenGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frozen Geode");
			Tooltip.SetDefault("A geode found in the ice caves\nA blacksmith can break this open for you, sadly, there is none\nRight click to recieve ice cave minerals.");
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
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
			int choice = Main.rand.Next(7);
			if (choice == 0)
			{
				player.QuickSpawnItem(source, ItemID.IceBlock, 35);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(source, ItemID.FrostCore);
					}
				}
			}
			else if (choice == 1)
			{
				if (Main.hardMode)
				{
					player.QuickSpawnItem(source, ItemID.PinkIceBlock, 35);
				}
				else if (Main.hardMode == false)
                {
					player.QuickSpawnItem(source, ItemID.IceBlock, 35);
                }

			}
			else if (choice == 2)
            {
				player.QuickSpawnItem(source, ItemID.RedIceBlock, 35);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(source, ItemID.FrostCore);
					}
				}
			}
			else if (choice == 3)
            {
				player.QuickSpawnItem(source, ItemID.PurpleIceBlock, 35);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(source, ItemID.FrostCore);
					}
				}
			}
			else if (choice == 4)
            {
				player.QuickSpawnItem(source, ItemID.VikingHelmet);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(source, ItemID.FrostCore);
					}
				}
			}
			else if (choice == 5)
            {
				player.QuickSpawnItem(source, ItemID.SlushBlock, 35);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(source, ItemID.FrostCore);
					}
				}
			}
			else if (choice == 6)
			{
				player.QuickSpawnItem(source, ModContent.ItemType<OldFrozenStaff>());
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(source, ItemID.FrostCore);
					}
				}
			}
		}
	}
}