using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class CreationMedaillon : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 38;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 8);
			Item.rare = ItemRarityID.Yellow;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
		    player.pStone = true;
			player.starCloakItem = Item;
			player.longInvince = true;
		    player.lifeRegen += 2;
			player.GetDamage(DamageClass.Generic) += 0.10f;
		    player.GetCritChance(DamageClass.Generic) += 10;
			player.GetAttackSpeed(DamageClass.Melee) += 0.10f;
			player.statDefense += 7;
			player.pickSpeed += 0.15f;
			player.moveSpeed += 0.10f;
			player.GetKnockback(DamageClass.Summon) += 0.005f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<AstralTitansEyeJewel>())
			.AddIngredient(ItemID.EyeoftheGolem)
			.AddIngredient(ItemID.CelestialStone)
			.AddTile(134)
			.Register();
		}
	}
}