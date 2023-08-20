using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using System;

namespace MultidimensionMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class SinnersVeilGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 14;
            Item.value = Item.sellPrice(0, 0, 24, 0);
            Item.rare = ItemRarityID.Green;
            Item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 30;
            player.GetDamage(DamageClass.Magic) += 0.04f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<DevilSilk>(), 6)
            .AddTile(TileID.Loom)
            .Register();
        }
    }
}