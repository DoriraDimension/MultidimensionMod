using MultidimensionMod.Items.Materials;
using MultidimensionMod.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System;

namespace MultidimensionMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class SinnersVeilHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 24, 0);
            Item.rare = ItemRarityID.Green;
            Item.defense = 3;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<SinnersVeilRobe>() && legs.type == ModContent.ItemType<SinnersVeilGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = Language.GetTextValue("Mods.MultidimensionMod.SetBonuses.SinnerSet");
            player.GetModPlayer<MDPlayer>().SinnerSet = true;
            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
            player.manaRegen += 2;
            player.manaCost -= 0.2f;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 30;
            player.GetDamage(DamageClass.Magic) += 0.04f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<DevilSilk>(), 5)
            .AddTile(TileID.Loom)
            .Register();
        }
    }
}