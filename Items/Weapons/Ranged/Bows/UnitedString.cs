using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Ranged;
using MultidimensionMod.Tiles;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
    public class UnitedString : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 60;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 30;
            Item.height = 58;
            Item.useTime = 28;
            Item.useAnimation = 28;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 0, 4, 70);
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 14f;
            Item.useAmmo = AmmoID.Arrow;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                type = ModContent.ProjectileType<LightshroomArrow>();
            }
            else
                type = ModContent.ProjectileType<BloodshroomArrow>();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                player.statMana -= 40;
            }
            else
                player.statLife -= 10;
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.damage = 30;
                Item.shootSpeed = 18f;
                Item.useTime = 14;
                Item.useAnimation = 14;
                if (player.statMana <= 20)
                {
                    return false;
                }
            }
            else
            {
                SetDefaults();
                if (player.statLife <= 10)
                {
                    return false;
                }
            }
            return base.CanUseItem(player);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Mushbow>())
            .AddIngredient(ModContent.ItemType<GlowingMushmatter>(), 5)
            .AddIngredient(ItemID.SoulofLight, 8)
            .AddIngredient(ModContent.ItemType<Dimensium>(), 7)
            .AddTile(ModContent.TileType<DimensionalForge>())
            .Register();
        }
    }
}