using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Utilities;
using MultidimensionMod.NPCs.MushBiomes;

namespace MultidimensionMod.Tiles.Biomes.ShroomForest
{
    public class MushroomTree : ModTree
    {
        public override TreePaintingSettings TreeShaderSettings => new()
        {
            UseSpecialGroups = true,
            SpecialGroupMinimalHueValue = 11f / 72f,
            SpecialGroupMaximumHueValue = 0.25f,
            SpecialGroupMinimumSaturationValue = 0.88f,
            SpecialGroupMaximumSaturationValue = 1f
        };

        public override void SetStaticDefaults()
        {
            GrowsOnTileId = new int[1] { ModContent.TileType<Mycelium>() };
        }
        public override Asset<Texture2D> GetTexture()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/ShroomForest/MushroomTree");
        }

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<YoungMushroom>();
        }

        public override bool Shake(int x, int y, ref bool createLeaves)
        {
            if (Main.rand.NextBool(100))
            {
                if (Main.rand.NextBool(2))
                    Item.NewItem(new EntitySource_ShakeTree(x, y), x * 16, y * 16, 16, 16, ItemID.Mushroom);
                //Item.NewItem(new EntitySource_ShakeTree(x, y), x * 16, y * 16, 16, 16, ModContent.ItemType<MycelialCantaloupe>());
                else
                    Item.NewItem(new EntitySource_ShakeTree(x, y), x * 16, y * 16, 16, 16, ItemID.Mushroom);
                //Item.NewItem(new EntitySource_ShakeTree(x, y), x * 16, y * 16, 16, 16, ModContent.ItemType<RedPersimmon>());
            }
            if (Main.rand.NextBool(50))
            {
                Item.NewItem(new EntitySource_ShakeTree(x, y), x * 16, y * 16, 16, 16, ItemID.Mushroom, Main.rand.Next(1, 2));
            }
            if (Main.rand.NextBool(80))
            {
                NPC jumpscare = Main.npc[NPC.NewNPC(new EntitySource_ShakeTree(x, y), x * 16, y * 16, ModContent.NPCType<MushSlime>())];
                jumpscare.velocity = Main.rand.NextVector2CircularEdge(3f, 3f);
                jumpscare.netUpdate = true;
            }
            if (Main.rand.NextBool(80))
            {
                for (int b = 0; b < Main.rand.Next(4, 8); b++)
                {
                    NPC theBugs = Main.npc[NPC.NewNPC(new EntitySource_ShakeTree(x, y), x * Main.rand.Next(12, 20), y * 16, ModContent.NPCType<MushbugBaby>())];
                    theBugs.velocity = Main.rand.NextVector2CircularEdge(3f, 3f);
                    theBugs.netUpdate = true;
                }
            }
            return false;
        }

        public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
        {

        }

        public override Asset<Texture2D> GetBranchTextures()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/ShroomForest/MushroomTree_Branches");
        }

        public override Asset<Texture2D> GetTopTextures()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/ShroomForest/MushroomTree_Tops");
        }
        public override int DropWood()
        {
            return ItemID.Mushroom;
        }
        public override int CreateDust() => ModContent.DustType<MushroomDust>();
    }
}