using MultidimensionMod.Items.Weapons.Ranged.Guns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Common.Systems
{
    public class ReplaceHandgunWithBoneShottie : ModSystem
    {

        public override void PostWorldGen()
        {

            for (int i = 0; i < Main.maxChests; i++) 
            {
            
                Chest chest = Main.chest[i];
                if (chest == null)
                    continue;

                Tile chestTile = Main.tile[chest.x,chest.y];

                if (chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 2 * 36) 
                {

                    for (int j = 0; j < Chest.maxItems; j++)
                    {
                        if (chest.item[j].type == ItemID.Handgun)
                        {
                            chest.item[j].SetDefaults(ModContent.ItemType<BoneShottie>());
                        }
                    }
                }
            }
        }
    }
}
