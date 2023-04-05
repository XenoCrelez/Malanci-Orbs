using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MEMO.Projectiles;

namespace MEMO.Items
{
	public class EliganticDarkBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eligantic Dark Blade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Voidful blade with a slimy feeling.");
		}

		public override void SetDefaults()
		{
			Item.damage = 82;
			Item.DamageType = DamageClass.Melee;
			Item.width = 82;
			Item.height = 82;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<LightOfTheBaneProjectiles>();
			Item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}