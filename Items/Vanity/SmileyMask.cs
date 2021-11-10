using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class SmileyMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Smiley Mask");
			Tooltip.SetDefault("Maybe if you disguise as him, the Darklings wont attack you anymore.");
			DisplayName.AddTranslation(GameCulture.German, "Smiley Maske");
			Tooltip.AddTranslation(GameCulture.German, "Vielleicht wenn du dich als er verkleidest, werden dich die Dunkellings nicht mehr angreifen.");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = Item.sellPrice(silver: 70);
			item.rare = ItemRarityID.LightRed;
			item.vanity = true;
		}

		public override bool DrawHead()
		{
			return false;
		}
	}
}