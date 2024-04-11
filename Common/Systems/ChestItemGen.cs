using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Weapons.Ranged.Bows;
using MultidimensionMod.Items.Weapons.Melee.Spears;
using MultidimensionMod.Items.Tools;
using MultidimensionMod.Items.Placeables;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace MultidimensionMod.Common.Systems
{
    // This class showcases adding additional items to vanilla chests.
    // This example simply adds additional items. More complex logic would likely be required for other scenarios.
    // If this code is confusing, please learn about "for loops" and the "continue" and "break" keywords: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/jump-statements
    public class FrozenChestItemGen : ModSystem
    {
        public override void PostWorldGen()
        {
            // Place some additional items in Frozen Chests:
            // These are the 3 new items we will place.
            int[] itemsToPlaceInFrozenChests = { ModContent.ItemType<VikingBattleaxe>(), ModContent.ItemType<BorealGreatbow>(), ModContent.ItemType<VikingPolearm>() };
            // This variable will help cycle through the items so that different Frozen Chests get different items
            int itemsToPlaceInFrozenChestsChoice = 0;
            // Rather than place items in each chest, we'll place up to 6 items (2 of each). 
            int itemsPlaced = 0;
            int maxItems = 20;
            int weaponsPlaced = 0;
            int maxWeapons = 3;
            // Loop over all the chests
            for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest == null)
                {
                    continue;
                }
                Tile chestTile = Main.tile[chest.x, chest.y];
                // We need to check if the current chest is the Frozen Chest. We need to check that it exists and has the TileType and TileFrameX values corresponding to the Frozen Chest.
                // If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Frozen Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. An alternate approach is to check the wiki and looking for the "Internal Tile ID" section in the infobox: https://terraria.wiki.gg/wiki/Frozen_Chest
                if (chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 11 * 36)
                {
                    // Next we need to find the first empty slot for our item
                    for (int inventoryIndex = 0; inventoryIndex < Chest.maxItems; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            // Place the item
                            chest.item[inventoryIndex].SetDefaults(ModContent.ItemType<VikingRelic>());
                            chest.item[inventoryIndex].stack = WorldGen.genRand.Next(1, 4);
                            itemsPlaced++;
                            break;
                        }
                    }
                    for (int inventoryIndexW = 0; inventoryIndexW < Chest.maxItems; inventoryIndexW++)
                    {
                        if (chest.item[inventoryIndexW].type == ItemID.None && weaponsPlaced <= maxWeapons)
                        {
                            // Place the item
                            chest.item[inventoryIndexW].SetDefaults(itemsToPlaceInFrozenChests[itemsToPlaceInFrozenChestsChoice]);
                            // Decide on the next item that will be placed.
                            itemsToPlaceInFrozenChestsChoice = (itemsToPlaceInFrozenChestsChoice + 1) % itemsToPlaceInFrozenChests.Length;
                            weaponsPlaced++;
                            break;
                        }
                    }
                }
                // Once we've placed as many items as we wanted, break out of the loop
                if (itemsPlaced >= maxItems && weaponsPlaced >= maxWeapons)
                {
                    break;
                }
            }
        }
    }

    public class SandstoneChestItemGen : ModSystem
    {
        public override void PostWorldGen()
        {
            int itemsPlaced = 0;
            int maxItems = 4;
            bool flamescarPlaced = false;
            // Loop over all the chests
            for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest == null)
                {
                    continue;
                }
                Tile chestTile = Main.tile[chest.x, chest.y];
                // We need to check if the current chest is the Frozen Chest. We need to check that it exists and has the TileType and TileFrameX values corresponding to the Frozen Chest.
                // If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Frozen Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. An alternate approach is to check the wiki and looking for the "Internal Tile ID" section in the infobox: https://terraria.wiki.gg/wiki/Frozen_Chest
                if (chestTile.TileType == TileID.Containers2 && chestTile.TileFrameX == 10 * 36)
                {
                    // Next we need to find the first empty slot for our item
                    for (int inventoryIndex = 0; inventoryIndex < Chest.maxItems; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            // Place the item
                            chest.item[inventoryIndex].SetDefaults(ModContent.ItemType<BrokenAncientDepictionItem>());
                            itemsPlaced++;
                            break;
                        }
                    }
                }
                // Once we've placed as many items as we wanted, break out of the loop
                if (itemsPlaced >= maxItems)
                {
                    break;
                }
            }
            for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest == null)
                {
                    continue;
                }
                Tile chestTile = Main.tile[chest.x, chest.y];
                if (chestTile.TileType == TileID.Containers2 && chestTile.TileFrameX == 10 * 36)
                {
                    // Next we need to find the first empty slot for our item
                    for (int inventoryIndex = 0; inventoryIndex < Chest.maxItems; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            if (!flamescarPlaced)
                            {
                                chest.item[inventoryIndex].SetDefaults(ModContent.ItemType<AwakenedArchbird>());
                                flamescarPlaced = true;
                            }
                        }
                    }
                }
            }
        }
    }
}