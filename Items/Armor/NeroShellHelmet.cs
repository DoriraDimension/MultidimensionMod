using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class NeroShellHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nero Shell Helmet");
			Tooltip.SetDefault("A helmet created from old blueprints found at the shores. The ancient depictions show brave warriors defending their home.\nIncreases melee damage by 18%.");
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 18;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 25;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<NeroBreastplate>() && legs.type == ModContent.ItemType<NeroGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases max life by 40 gives the ability to swim and you can move through water freely.\nIncreases movement speed by 15% and defense by 10 when submerged in liquid.";
			player.statLifeMax2 += 40;
			player.accFlipper = true;
			player.ignoreWater = true;
			if (player.wet && !player.lavaWet && !player.honeyWet)
			{
				player.moveSpeed += 0.15f;
				player.statDefense += 10;
            }
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Melee) += 0.18f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 6)
			.AddIngredient(ItemID.HallowedBar, 7)
			.AddTile(134)
			.Register();
		}
	}
}