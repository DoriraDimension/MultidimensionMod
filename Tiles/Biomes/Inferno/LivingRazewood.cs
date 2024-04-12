using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Inferno
{
    public class LivingRazewood : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlendAll[Type] = false;
            Main.tileMerge[TileID.Mud][Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = false;
            DustType = ModContent.DustType<Dusts.RazewoodDust>();
            RegisterItemDrop(ModContent.ItemType<Items.Placeables.Biomes.Inferno.Razewood>());   
            AddMapEntry(new Color(40, 40, 40));
        }
    }
}