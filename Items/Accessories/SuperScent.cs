using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;

namespace MultidimensionMod.Items.Accessories
{
	public class SuperScent : ModItem
	{
		public static readonly SoundStyle Stink = new SoundStyle("MultidimensionMod/Sounds/Custom/Stinky");
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.UseSound = Stink;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Orange;
			Item.buffType = (BuffID.Stinky);
			Item.buffTime = 28800;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Summon) += 0.06f;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<StinkyPaste>())
			.AddIngredient(ModContent.ItemType<BaitLeaf>())
			.AddIngredient(ItemID.JungleSpores, 5)
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 3)
			.AddTile(TileID.WorkBenches)
			.Register();
		}
	}
}