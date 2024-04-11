using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace MultidimensionMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
	public class MushiumShirt : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Mushium Shirt");
            //Tooltip.SetDefault("2% Increased life regeneration");
            //ArmorIDs.Head.Sets.DrawHead[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body)] = false;
        }

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 20;
			Item.value = 50;
			Item.rare = ItemRarityID.Green;
			Item.defense = 4;
            Item.value = Item.sellPrice(0, 0, 25, 0);
        }

		public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 5;
            player.statManaMax2 += 10;
            player.GetDamage(DamageClass.Generic) += 0.03f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Mushmatter>(), 5)
            .AddIngredient(ModContent.ItemType<GlowingMushmatter>(), 5)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}