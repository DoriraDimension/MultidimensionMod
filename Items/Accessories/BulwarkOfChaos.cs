using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class BulwarkOfChaos : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ItemRarityID.Green;
            Item.expert = true; 
            Item.expertOnly = true;
            Item.accessory = true;
            Item.defense = 3;
        }
        public override void SetStaticDefaults()
        {            //DisplayName.SetDefault("Bulwark Of Chaos");
            /*Tooltip.SetDefault(
@"For every hit you land on an enemy, 5 true damage (damage unassigned to any class) is dealt
Allows you to dash into enemies, damaging them");*/
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.GetModPlayer<MDPlayer>().chaosClaw = true;
            player.dash = 2;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ClawOfChaos>())
            .AddIngredient(ItemID.EoCShield, 1)
            .AddIngredient(ModContent.ItemType<PaleMatter>(), 4)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            if (slot < 10)
            {
                int maxAccessoryIndex = 5 + player.extraAccessorySlots;
                for (int i = 3; i < 3 + maxAccessoryIndex; i++)
                {
                    if (slot != i && player.armor[i].type == ModContent.ItemType<ClawOfChaos>())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}