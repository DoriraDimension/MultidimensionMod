using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class EelMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Storm Eel Mask Mask");
			Tooltip.SetDefault("You look super angry with this on.");
			DisplayName.AddTranslation(GameCulture.German, "Sturmfront Aal Maske");
			Tooltip.AddTranslation(GameCulture.German, "Du siehst super wütend aus mit dieser Maske.");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = Item.sellPrice(silver: 50);
			item.rare = ItemRarityID.Lime;
			item.vanity = true;
		}

		public override bool DrawHead()
		{
			return false;
		}
	}
}