using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class EnergyFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Energy Fish");
			Tooltip.SetDefault("A fish charged with the lowest tier of Dimensional Energy.\nRight click to extract its energy.");
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.rare = ItemRarityID.Blue;
			Item.maxStack = 99;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			var source = player.GetSource_OpenItem(Type);
			player.QuickSpawnItem(source, ModContent.ItemType<Dimensium>(), Main.rand.Next(8, 10));
		}
	}
}
