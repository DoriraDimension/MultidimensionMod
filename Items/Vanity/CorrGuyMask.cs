using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class CorrGuyMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infested Abomination Mask");
			Tooltip.SetDefault("Does not include flies.");
			DisplayName.AddTranslation(GameCulture.German, "Befallene Abscheuligkeit Maske");
			Tooltip.AddTranslation(GameCulture.German, "Enthält keine Fliegen.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.value = Item.sellPrice(silver: 50);
			item.rare = ItemRarityID.Green;
			item.vanity = true;
		}

		public override bool DrawHead()
		{
			return false;
		}
	}
}