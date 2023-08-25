using MultidimensionMod.Items.Materials;
using MultidimensionMod.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class NeroPredatorHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<NeroHammerheadMask>();
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 28;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 15;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<NeroBreastplate>() && legs.type == ModContent.ItemType<NeroGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = Language.GetTextValue("Mods.MultidimensionMod.SetBonuses.NeroSet");
			player.maxMinions += 2;
			player.accDivingHelm = true;
			player.whipRangeMultiplier += 0.4f;
			player.GetModPlayer<MDPlayer>().NeroSet = true;
			ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
			if (player.wet && !player.lavaWet && !player.honeyWet)
			{
				player.moveSpeed += 0.20f;
				player.statDefense += 15;
                player.ignoreWater = true;
            }
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.12f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 6)
			.AddIngredient(ItemID.HallowedBar, 7)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}