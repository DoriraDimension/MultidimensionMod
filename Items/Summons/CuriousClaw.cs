using MultidimensionMod.NPCs.Bosses.Grips;
using MultidimensionMod.NPCs.Bosses;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Audio;

namespace MultidimensionMod.Items.Summons
{
    //imported from my tAPI mod because I'm lazy
    public class CuriousClaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("The Grabber");
            ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 13; // This helps sort inventory know this is a boss summoning Item.
            /*Tooltip.SetDefault(@"A pair of claws crafted from Hydra and Dragon Claws
Can only be used at night
Summons the Grips of Chaos");*/
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 0, 0);
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item44;
            Item.consumable = true;
        }

        public override void AddRecipes()
        {
            /*CreateRecipe()
            .AddIngredient(ModContent.ItemType<DragonScale>(), 12)
            .AddIngredient(ModContent.ItemType<MirePod>(), 12)
            .AddIngredient(null, "HydraClaw", 3)
            .AddTile(TileID.DemonAltar)
            .Register();*/
        }

        public override bool CanUseItem(Player player)
        {
            if (Main.dayTime || NPC.AnyNPCs(ModContent.NPCType<GripOfChaosBlue>()) || NPC.AnyNPCs(ModContent.NPCType<GripOfChaosRed>()))
            {
                return false;
            }
            return true;
        }

        public override bool? UseItem(Player player)
        {
            //MDWorld.spawnGrips = false; //Grips natural spawn
            //BossSpawning.SpawnBoss(player, ModContent.NPCType<GripOfChaosBlue>(), 1, 0);
            //BossSpawning.SpawnBoss(player, ModContent.NPCType<GripOfChaosRed>(), -1, 0);
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<GripOfChaosRed>());
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<GripOfChaosBlue>());
            SoundEngine.PlaySound(SoundID.Roar, player.position);
            return true;
        }
    }
}