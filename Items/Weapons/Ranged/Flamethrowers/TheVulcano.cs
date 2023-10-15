using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Weapons.Ranged.Flamethrowers
{
    public class TheVulcano : ModItem
    {
        
        public override void SetDefaults()
        {
            Item.damage = 35;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 58;
            Item.height = 24;
            Item.useTime = 65;
            Item.useAnimation = 65;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ModContent.ProjectileType<Vulcan>();
            Item.knockBack = 4;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shootSpeed = 10f;
            Item.value = Item.sellPrice(0, 0, 0, 80);
            Item.useAmmo = AmmoID.Gel;
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("The Vulcan");
            //Tooltip.SetDefault("Turns Gel into an explosive lob of magma");
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 15f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Obsidian, 40)
			.AddIngredient(ItemID.HellstoneBar, 20)
            .AddIngredient(ItemID.IllegalGunParts, 1)
            .AddTile(TileID.Anvils)
            .Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }
    }
}
