using MultidimensionMod.Tiles.Ores;
using MultidimensionMod.Items.Placeables.Biomes.Inferno;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics; 
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
    public class IncineriteBar : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Gilded Dragonbreath Ingot");
            //Tooltip.SetDefault("An ingot forged from molten Cinerite Gold, it shines and flickers like a dragon's flame dancing across a scorched wasteland.");
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
			Item.maxStack = 9999;
			Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.value = 16000;
            Item.rare = ItemRarityID.Green;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<IncineriteBarPlaced>();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Materials/IncineriteBar").Value;
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

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Incinerite>(), 3)
            .AddTile(TileID.Furnaces)
            .Register();
        }
    }
}
