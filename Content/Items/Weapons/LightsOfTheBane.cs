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
        public static int cooldown = 0;
        
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
			Item.useStyle = ItemUseStyleID.Swing;
			Item.height = 82;
			Item.useTime = 20;
			Item.useAnimation = 20;
            
            Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			//Item.shoot = ModContent.ProjectileType<LightOfTheBaneProjectiles>();
			Item.shootSpeed = 8f;
		}
        

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool? UseItem(Player player)
        {

            Vector2 mousePosition = Main.MouseWorld;

            // Calculate the direction vector from the player to the mouse
            Vector2 direction = mousePosition - player.Center;
            direction.Normalize();
			

            Vector2 newvelo = Item.velocity = direction;
			Vector2 playerPos = player.position;
			if (player.altFunctionUse == 2 && cooldown == 0)
			{
				Projectile.NewProjectile(Projectile.InheritSource(player), playerPos, newvelo, ModContent.ProjectileType<LightOfBaneProjectile>(), 10, 4f, Main.myPlayer);
				

				
		
			
			}
			return true;
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