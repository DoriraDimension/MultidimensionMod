using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Back)]
	public class SidanesQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 48;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.rare = ItemRarityID.Yellow;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Ranged) += 0.10f;
			player.magicQuiver = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.MagicQuiver)
			.AddIngredient(ItemID.RangerEmblem)
			.AddIngredient(ModContent.ItemType<Prismatine>(), 3)
			//.AddIngredient(ModContent.ItemType<CelestialPlating>(), 3)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}