using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;


namespace MultidimensionMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class BogwoodHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Bogwood Helmet");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.value = 1000;
            Item.rare = ItemRarityID.White;
            Item.defense = 1;
        }
        

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BogwoodChestplate>() && legs.type == ModContent.ItemType<BogwoodLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "1 defense";
            player.statDefense += 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Placeables.Biomes.Mire.Bogwood>(), 20)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}