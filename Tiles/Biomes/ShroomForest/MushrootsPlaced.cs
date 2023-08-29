using Microsoft.Xna.Framework;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.ShroomForest
{
    public class MushrootsPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlendAll[Type] = false;
            Main.tileBlockLight[Type] = true;
            RegisterItemDrop(ModContent.ItemType<MushroomBlock>());
            AddMapEntry(new Color(120, 90, 0));
        }
    }
}