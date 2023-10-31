using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace MultidimensionMod.Items.Accessories
{
	public class OmniEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 38;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.rare = ItemRarityID.LightRed;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.OmniEye.Lore"))
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

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.findTreasure = true;
			player.detectCreature = true;
			player.nightVision = true;
			player.dangerSense = true;
		}


		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<EyeoftheExplorer>())
			.AddIngredient(ModContent.ItemType<EyeoftheHunter>())
			.AddIngredient(ModContent.ItemType<EyeoftheNightwalker>())
			.AddIngredient(ModContent.ItemType<EyeofDesire>())
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 10)
			.AddOnCraftCallback(delegate (Recipe recipe, Item Item, List<Item> consumedItems, Item destinationStack) 
			 {
				 Main.LocalPlayer.AddBuff(BuffID.Obstructed, 6000);
				 SoundEngine.PlaySound(SoundID.DD2_EtherianPortalIdleLoop, Item.position);
				 SoundEngine.PlaySound(SoundID.DD2_BetsyDeath, Item.position);
			 })
			.AddTile(TileID.DemonAltar)
			.Register();
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Accessories/OmniEye_Glow").Value;
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