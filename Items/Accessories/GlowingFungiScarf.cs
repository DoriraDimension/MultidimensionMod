using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Accessories
{
	public class GlowingFungiScarf : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 48;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 80, 0);
			Item.rare = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
		    if (player.ZoneGlowshroom && Main.hardMode)
			{
				player.statLifeMax2 += 25;
				player.endurance += 0.05f;
			}
			else if (player.ZoneGlowshroom)
            {
				player.statLifeMax2 += 10;
            }
			player.GetDamage(DamageClass.Ranged) += 0.05f;
		    Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.15f, 0.6f, 0.8f);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<Mushmatter>(), 6)
			.AddIngredient(ItemID.GlowingMushroom, 25)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}