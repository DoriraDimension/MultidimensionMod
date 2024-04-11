using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Summon.Minions;
using MultidimensionMod.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace MultidimensionMod.Items.Accessories
{
	public class GlowingFungiScarf : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 46;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 80, 0);
			Item.rare = ItemRarityID.Pink;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.GetModPlayer<MDPlayer>().Symbio = true;
            if (player.GetModPlayer<MDPlayer>().Mario >= 12000)
			{
                Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.25f, 0.6f, 0.8f);
            }
			else
                Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.15f, 0.6f, 0.8f);
		}

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Accessories/GlowingFungiScarf_Glow").Value;
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
			.AddIngredient(ModContent.ItemType<GlowingMushmatter>(), 12)
            .AddIngredient(ItemID.SoulofLight, 10)
            .AddIngredient(ItemID.SoulofMight, 7)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}