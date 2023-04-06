using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Malanci_Orbs.Content.Items.Weapons.Projectiles.Weapons;

namespace Malanci_Orbs.Content.Items.Weapons
{
    public class LightsOfTheBane : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lights of the Bane"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A weapon that can surpass through rangers.");
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
			//Item.shoot = ModContent.ProjectileType<LightOfTheBaneProjectiles>();
			Item.shootSpeed = 8f;
		}

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2) // right-click
            {
				// Set up the projectile
				Item.shoot = ModContent.ProjectileType<LightOfBaneProjectile>();

                return true;
            }
            return false;
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