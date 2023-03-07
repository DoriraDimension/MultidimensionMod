using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.FrozenUnderworld
{
	public class FrigidAshTree : ModTree
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
			GrowsOnTileId = new int[1] { ModContent.TileType<ColdAshGrass>() };
		}
		public override Asset<Texture2D> GetTexture()
		{
			return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/FrozenUnderworld/FrigidAshTree");
		}

		public override int SaplingGrowthType(ref int style)
		{
			style = 0;
			return ModContent.TileType<FrigidAshSapling>();
		}

		public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
		{

		}

		public override Asset<Texture2D> GetBranchTextures()
		{
			return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/FrozenUnderworld/FrigidAshTree_branches");
		}

		public override Asset<Texture2D> GetTopTextures()
		{
			return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/FrozenUnderworld/FrigidAshTree_Tops");
		}
		public override int DropWood()
		{
			return ItemID.AshWood;
		}
		public override int CreateDust() => DustID.Smoke;
	}
}
