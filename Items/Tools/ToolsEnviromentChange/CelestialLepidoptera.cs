using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Terraria.Localization;

namespace MultidimensionMod.Items.Tools.ToolsEnviromentChange
{
	public class CelestialLepidoptera : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 98;
			Item.height = 82;
			Item.rare = ItemRarityID.LightRed;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = SoundID.Item60;
			Item.consumable = false;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.CelestialLepidoptera.Lore"))
                {
                    OverrideColor = Color.LightGray
                };
                tooltips.Add(line);
            }
            else
            {
                TooltipLine line = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.SpecialTooltips.Viewer"))
                {
                    OverrideColor = Color.Gray,
                };
                tooltips.Add(line);
            }
        }

        public override bool? UseItem(Player player)
		{
			if (Main.netMode != NetmodeID.MultiplayerClient && Main.dayTime)
			{
				Main.dayTime = false;
				Main.time = 0;
			}
			else
            {
				Main.dayTime = true;
				Main.time = 0;
            }
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<SunlightButterfly>())
			.AddIngredient(ModContent.ItemType<MoonlightMoth>())
			.AddIngredient(ItemID.SoulofLight, 5)
			.AddIngredient(ItemID.SoulofNight, 5)
			.AddIngredient(ItemID.PixieDust, 12)
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 12)
			.AddIngredient(ModContent.ItemType<Dimensium>(), 6)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Tools/ToolsEnviromentChange/CelestialLepidoptera_Glow").Value;
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
					Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}
	}
}
