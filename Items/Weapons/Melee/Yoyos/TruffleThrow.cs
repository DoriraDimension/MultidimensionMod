using Microsoft.Xna.Framework;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Potions.Food;
using MultidimensionMod.Projectiles.Melee.Yoyos;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Yoyos
{
    public class TruffleThrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true; // Used to increase the gamepad range when using Strings.
            ItemID.Sets.GamepadExtraRange[Item.type] = 15; // Increases the gamepad range. Some vanilla values: 4 (Wood), 10 (Valor), 13 (Yelets), 18 (The Eye of Cthulhu), 21 (Terrarian).
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true; // Unused, but weapons that require aiming on the screen are in this set.
        }

        public override void SetDefaults()
        {
            Item.damage = 19;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.width = 26;
            Item.height = 40;
            Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.rare = ItemRarityID.Green;
            Item.knockBack = 1;
            Item.channel = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item1;
            Item.channel = true;
            Item.shoot = ModContent.ProjectileType<TruffleThrowProj>();
            Item.shootSpeed = 16f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<GourmetTruffle>())
            .AddIngredient(ModContent.ItemType<Mushmatter>(), 2)
            .AddIngredient(ItemID.WhiteString)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}