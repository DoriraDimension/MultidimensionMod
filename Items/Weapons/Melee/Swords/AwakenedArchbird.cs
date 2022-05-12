using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class AwakenedArchbird : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Awakened Archbird");
			Tooltip.SetDefault("A sword shaped like a legendary bird found in ancient depictions in the desert, it is full of dark flames.\nInscriptions say that one day the archbird will swoop down and bathe the earth in it's dark flames.\nShoots shadowflame tentacles when swung and slows enemies when hit for 5 seconds.");
		}

		public override void SetDefaults()
		{
			Item.damage = 98;
			Item.DamageType = DamageClass.Melee;
			Item.width = 118;
			Item.height = 118;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileID.ShadowFlame;
			Item.shootSpeed = 10f;
			Item.crit = 12;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (27));
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Slow, 320);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = ProjectileID.ShadowFlame;

			for (int i = 0; i < 3; i++)
			{
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(20));

				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}
			return false; 
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DormantKing>())
			.AddIngredient(ItemID.AncientBattleArmorMaterial, 2)
			.AddIngredient(2766, 7)
			.AddTile(134)
			.Register();
		}
	}
}