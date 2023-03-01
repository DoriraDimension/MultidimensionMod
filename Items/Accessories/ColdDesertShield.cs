using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class ColdDesertShield : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 24;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 34);
			Item.rare = ItemRarityID.Green;
			Item.defense = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.buffImmune[BuffID.Chilled] = true;
			player.buffImmune[BuffID.Frozen] = true;
			if (player.ZoneSnow || player.ZoneDesert)
			{
				player.GetDamage(DamageClass.Generic) += 0.4f;
				player.GetCritChance(DamageClass.Generic) += 4;
				player.statDefense += 6;
				player.endurance += 0.04f;
			}
			if (player.statLife <= player.statLifeMax2 * 0.5)
			{
				player.statDefense += 4;
            }

		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DrakescaleShield>())
			.AddIngredient(ModContent.ItemType<DesertNecklace>())
			.AddTile(114)
			.Register();
		}
	}
}