using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MultidimensionMod.Items.Placeables.Biomes.Mire;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using ReLogic.Content;
using MultidimensionMod.Tiles.Biomes.ShroomForest;
using MultidimensionMod.Items.Potions.Food;
using MultidimensionMod.NPCs.MushBiomes;
using Terraria.DataStructures;
using MultidimensionMod.NPCs.Mire;


namespace MultidimensionMod.Tiles.Biomes.Mire
{
    class BogwoodTree : ModTree
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
            GrowsOnTileId = new int[1] { ModContent.TileType<MireGrass>() };
        }

        public override int DropWood()
        {
            return ModContent.ItemType<Bogwood>();
        }

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<BogwoodSapling>();
        }

        public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
        {

        }

        public override Asset<Texture2D> GetTexture()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/BogwoodTree");
        }

        public override Asset<Texture2D> GetBranchTextures()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/BogwoodBranches");
        }

        public override Asset<Texture2D> GetTopTextures()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/BogwoodTreeTop");
        }

        public override int CreateDust() => ModContent.DustType<Dusts.BogwoodDust>();

        public override bool Shake(int x, int y, ref bool createLeaves)
        {
            if (Main.rand.NextBool(120))
            {
                if (Main.rand.NextBool(2))
                    Item.NewItem(new EntitySource_ShakeTree(x, y), x * 16, y * 16, 16, 16, ModContent.ItemType<MistyPear>());
                else
                Item.NewItem(new EntitySource_ShakeTree(x, y), x * 16, y * 16, 16, 16, ModContent.ItemType<Cranberry>());
            }
            if (Main.rand.NextBool(70))
            {
                Item.NewItem(new EntitySource_ShakeTree(x, y), x * 16, y * 16, 16, 16, ModContent.ItemType<Bogwood>(), Main.rand.Next(6, 8));
            }
            if (Main.rand.NextBool(100))
            {
                NPC jumpscare = Main.npc[NPC.NewNPC(new EntitySource_ShakeTree(x, y), x * 16, y * 16, ModContent.NPCType<MoonMorpho>())];
                jumpscare.velocity = Main.rand.NextVector2CircularEdge(3f, 3f);
                jumpscare.netUpdate = true;
            }
            return false;
        }
    }
}
