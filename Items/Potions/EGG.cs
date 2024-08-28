using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using System;
using MultidimensionMod.Rarities;

namespace MultidimensionMod.Items.Potions
{
    public class EGG : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 42;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item2;
            Item.maxStack = 1;
            Item.consumable = true;
            Item.rare = ModContent.RarityType<DeepGreen>();
            Item.value = Item.sellPrice(0, 0, 0, 0);
        }
    }
}
