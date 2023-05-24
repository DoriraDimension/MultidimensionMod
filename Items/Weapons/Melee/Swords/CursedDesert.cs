using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class CursedDesert : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 23;
			Item.DamageType = DamageClass.Melee;
			Item.width = 46;
			Item.height = 46;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(0, 0, 40, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.crit = 1;
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.Slow, 120);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Amber, 5)
			.AddIngredient(ItemID.Deathweed, 2)
			.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 4)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}