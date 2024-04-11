using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace MultidimensionMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
	public class MushiumPants : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Mushium Pants");
            //Tooltip.SetDefault("1% Increased life regeneration");
            //ArmorIDs.Head.Sets.DrawHead[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs)] = false;

        }

		public override void SetDefaults()
		{
            Item.width = 22;
			Item.height = 18;
			Item.value = 50;
			Item.rare = ItemRarityID.Green;
			Item.defense = 3;
            Item.value = Item.sellPrice(0, 0, 25, 0);
        }

        public override void Load()
        {
            // The code below runs only if we're not loading on a server
            if (Main.netMode == NetmodeID.Server)
                return;

            // Add equip textures
            //EquipLoader.AddEquipTexture(Mod, $"MultidimensionMod/Items/Armor/MushiumHatIndigo_{EquipType.Head}", EquipType.Head, this);
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
            .AddIngredient(ModContent.ItemType<Mushmatter>(), 3)
            .AddIngredient(ModContent.ItemType<GlowingMushmatter>(), 3)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}