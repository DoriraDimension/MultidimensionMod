using Microsoft.Xna.Framework;
using MultidimensionMod.Projectiles.Ranged;
using MultidimensionMod.Tiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Guns
{
	public class BoneShottie : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 32;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 64;
			Item.height = 22;
			Item.useTime = 52;
			Item.useAnimation = 52;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 0, 10, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item38;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<BoneShard>();
			Item.shootSpeed = 20f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            SoundEngine.PlaySound(SoundID.NPCHit2, player.position);
            int numberProjectiles = 4;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(12));																												
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
			}
			return false;
		}

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Bone, 25)
            .AddCondition(Language.GetOrRegister("Mods.MultidimensionMod.MiscText.NoHandgunReTier"), () => !ModContent.GetInstance<MDConfig>().ReTierHandgun)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}