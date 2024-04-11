using MultidimensionMod.Projectiles.Melee.Boomerangs;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace MultidimensionMod.Items.Weapons.Melee.Boomerangs
{
    public class RoyalFungarang : ModItem
    {
        public int Imbue = 0;

        public override void SetDefaults()
        {

            Item.damage = 48;
            Item.DamageType = DamageClass.Melee;
            Item.width = 26;
            Item.height = 44;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 0;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.shootSpeed = 17f;
            Item.shoot = ModContent.ProjectileType<Fungarang>();
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.noMelee = true;
        }

        public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot)
                {
                    return false;
                }
            }
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (Imbue == 3)
            {
                if (player.statMana <= 100)
                {
                    damage *= 2;
                }
                if (player.statMana >= 100)
                {
                    player.statMana -= 100;
                    damage *= 3;
                }
                velocity *= 1.3f;
                player.statLife -= 15;
            }
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
            return false;
        }

        public override bool? UseItem(Player player)
        {
            Imbue += 1;
            if (Imbue >= 4)
            {
                Imbue = 0;
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Musharang>())
            .AddIngredient(ModContent.ItemType<GlowingMushmatter>(), 4)
            .AddIngredient(ItemID.SoulofLight, 8)
            .AddIngredient(ModContent.ItemType<Dimensium>(), 7)
            .AddTile(ModContent.TileType<DimensionalForge>())
            .Register();
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Melee/Boomerangs/RoyalFungarang_Glow").Value;
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
