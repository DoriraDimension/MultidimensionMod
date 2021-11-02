using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class EleanoraPlushie : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dimensional Goddess Plushie");
			Tooltip.SetDefault("Cute and Cuddly, and lavaproof.\nThe magic power of this plushie makes you immune to lava, OnFire and fire blocks.\nSummons a ring of fire around you and makes you immune to ice debuffs.");
			DisplayName.AddTranslation(GameCulture.German, "Dimensionsgöttin Plüschtier");
			Tooltip.AddTranslation(GameCulture.German, "Niedlich und Kuschlig, und Lavafest. \nDie magische Kraft dieses Plüschtiers macht dich immun gegen Lava, In Brand Stehend! und Feuerblöcke. \nBeschwört eine Feuerring um dich herum und macht dich immun gegen Eis debuffs.");
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					item.overrideColor = MDRarity.Eleanora;
				}
			}
		}

		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 60;
			item.accessory = true;
			item.value = Item.sellPrice(copper: 0);
			item.rare = ItemRarityID.Red;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.lavaImmune = true;
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Burning] = true;
			player.inferno = true;
			player.resistCold = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 20);
			recipe.AddIngredient(ItemID.LavaCharm);
			recipe.AddIngredient(ItemID.Silk, 30);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}