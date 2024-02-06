using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MultidimensionMod.NPCs.Bosses.MushroomMonarch;
using Terraria.ModLoader;
using Terraria.Localization;


namespace MultidimensionMod.Items.Summons
{
    public class IntimidatingMushroom : ModItem
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Crown Cap");
            ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 13;
            // Tooltip.SetDefault(@"Summons the Mushroom Monarch");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 38;
            Item.maxStack = 20;
            Item.value = 1000;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.consumable = true;
        }

        public override bool? UseItem(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            /*if (NPC.AnyNPCs(ModContent.NPCType<MushroomMonarchSlep>()))
            {
                return true;
            }*/
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Mushroom, 10)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}