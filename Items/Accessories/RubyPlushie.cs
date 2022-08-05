using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class RubyPlushie : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ruby Plushie");
			Tooltip.SetDefault("Cute and Cuddly, and lavaproof.\nThe fiery magical power of this plushie makes you immune to lava, OnFire and fire blocks.\nSummons a ring of fire around you and makes you immune to ice debuffs.");
		}

		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 60;
			Item.accessory = true;
			Item.value = Item.sellPrice(copper: 0);
			Item.rare = ItemRarityID.Red;
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
			CreateRecipe()
			.AddIngredient(ItemID.FragmentSolar, 20)
			.AddIngredient(ItemID.LavaCharm)
			.AddIngredient(ItemID.Silk, 30)
			.AddIngredient(ItemID.SoulofLight, 10)
			.AddTile(134)
			.Register();
		}
	}
}