using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MultidimensionMod.Common.Players;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class ColdDesertShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 24;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 1, 20, 50);
			Item.rare = ItemRarityID.Green;
			Item.defense = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneSnow || player.ZoneDesert)
			{
				player.GetDamage(DamageClass.Generic) += 0.04f;
				player.GetCritChance(DamageClass.Generic) += 4;
				player.statDefense += 3;
				player.endurance += 0.04f;
            }
			if (player.statLife <= player.statLifeMax2 * 0.5)
			{
				player.statDefense += 4;
            }
            player.GetModPlayer<MDPlayer>().DrakeShield = true;
            player.GetModPlayer<MDPlayer>().DesertNeck = true;

        }

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DrakescaleShield>())
			.AddIngredient(ModContent.ItemType<DesertNecklace>())
			.AddTile(TileID.TinkerersWorkbench)
			.Register();
		}
	}
}