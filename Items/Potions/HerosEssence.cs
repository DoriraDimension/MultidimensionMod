using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Potions
{
    public class HerosEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eternal's Essence");
            Tooltip.SetDefault("Grants temporary a tiny bit of weird power.\nThe weird essence inside this container is very potent and yet seems to be nothing more than just a tiny shard.");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item4;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(gold: 1);
            Item.buffType = ModContent.BuffType<ChosenOne>();
            Item.buffTime = 36000;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<MegaDemondrug>())
            .AddIngredient(ModContent.ItemType<PotionofLife>())
            .AddIngredient(ModContent.ItemType<DimensionalShieldPotion>())
            .AddIngredient(ItemID.Ectoplasm)
            .AddTile(355)
            .Register();

        }
    }
}
