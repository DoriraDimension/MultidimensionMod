using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class GreatToothsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Skeletal Greatsword");
			Tooltip.SetDefault("Ever thought about taking a skeleton and force it into a blade shape, well here you go.");
		}

		public override void SetDefaults()
		{
			Item.damage = 83;
			Item.DamageType = DamageClass.Melee;
			Item.width = 78;
			Item.height = 82;
			Item.useTime = 29;
			Item.useAnimation = 29;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileID.BoneGloveProj;
			Item.shootSpeed = 10f;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
			.AddIngredient(ItemID.BoneSword)
			.AddIngredient(ItemID.Bone, 150)
			.AddIngredient(ItemID.BoneFeather)
			.AddTile(300)
			.Register();
		}
	}
}