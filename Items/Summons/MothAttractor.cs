using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Summons
{
	public class MothAttractor : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 12;
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 26;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(gold: 0);
			Item.rare = ItemRarityID.Pink;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = SoundID.NPCHit44;
			Item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return Main.eclipse && Main.hardMode && !NPC.AnyNPCs(NPCID.Mothron);
		}

		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Mothron);
			return true;
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Summons/MothAttractor_Glow").Value;
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
			.AddIngredient(ItemID.HallowedBar, 3)
			.AddIngredient(ItemID.SoulofLight, 3)
			.AddIngredient(ItemID.Ectoplasm, 2)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}