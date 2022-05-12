using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class CreationMedaillon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Creation Medaillon");
			Tooltip.SetDefault("A replica of the creation medaillon, not as powerful as the original but often used as a talisman for good fortune.\nThe medaillon resembles the deity circle, a group of powerful beings where every triangle stands for one deity while the eye resembles the creation titan.\nIncreases all damage by 10% and crit chance by 10%.\nDecreases the duration of the Potion Sickness debuff to 45 seconds and increases life regen by 2.\nIncreases invincibility time and rains down stars after getting hit. \nGives a variety of additional stat bonuses.");
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