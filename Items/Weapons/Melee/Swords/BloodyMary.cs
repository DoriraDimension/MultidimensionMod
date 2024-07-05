using MultidimensionMod.Buffs.Debuffs;
using MultidimensionMod.Projectiles.Melee.Swords;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
    public class BloodyMary : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Bloody Mary");
            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Item.type] = true;
        }

		public override void SetDefaults()
		{
			Item.damage = 16;
            Item.DamageType = DamageClass.Melee;
            Item.width = 64;
			Item.height = 64;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.autoReuse = true;
		    Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<MaryStab>();
            Item.shootSpeed = 3.50f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Blood);
			}
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(ModContent.BuffType<MarysWrath>(), 600);
		}

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

		public int summon = 0;
        public override bool? UseItem(Player player)
        {
			summon++;
			if (summon == 30)
			{
                Projectile.NewProjectile(player.GetSource_ItemUse(player.HeldItem), player.Center.X, player.Center.Y, 0f, -15f, ModContent.ProjectileType<Mary>(), 100, 0f, Main.myPlayer);
                summon = 0;
            }
            if (player.altFunctionUse == 2)
            {

            }
            return true;
        }

        public override bool CanUseItem(Player player)
        {
			if (player.altFunctionUse == 2)
			{
                SetDefaults();
                Item.damage = 14;
                Item.DamageType = DamageClass.Melee;
                Item.width = 64;
                Item.height = 64;
                Item.useTime = 19;
                Item.useAnimation = 19;
                Item.autoReuse = true;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.knockBack = 2;
                Item.shoot = ProjectileID.None;
                Item.noMelee = false;
                Item.noUseGraphic = false;
            }
			else
			{
                SetDefaults();
            }
			return true;
        }

        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Melee/Swords/BloodyMaryBlood").Value;
            spriteBatch.Draw(texture, position, null, drawColor, 0f, origin, scale, SpriteEffects.None, 0f);
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Melee/Swords/BloodyMaryBlood").Value;
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
                Item.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally,
                0f
            );
        }
    }
}