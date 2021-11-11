using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class LonelyWarriorsVisor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lonely Warrior's Visor");
			Tooltip.SetDefault("The Visor of a dark warrior.");
			DisplayName.AddTranslation(GameCulture.German, "Visier des einsamen Kriegers");
			Tooltip.AddTranslation(GameCulture.German, "Das Visier eines dunklen Kriegers.");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 12;
			item.value = Item.sellPrice(silver: 70);
			item.rare = ItemRarityID.LightRed;
			item.vanity = true;
		}

		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}
	}
}