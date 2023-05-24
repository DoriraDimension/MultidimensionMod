using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
    public class MasterMagePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.buffType = ModContent.BuffType<MasterMage>();
            Item.buffTime = 26000;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.MagicPowerPotion)
                .AddIngredient(ItemID.ManaRegenerationPotion)
                .AddIngredient(ItemID.Prismite)
                .AddTile(TileID.AlchemyTable)
                .Register();
        }
    }
}
