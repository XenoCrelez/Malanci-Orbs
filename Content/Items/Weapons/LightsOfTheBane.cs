using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Malanci_Orbs.Content.Items.Weapons.Projectiles.Weapons;
using System;
using System.Threading;



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
			Item.useStyle = ItemUseStyleID.Swing;
			Item.height = 82;
			Item.useTime = 15;
			Item.useAnimation = 15;
            
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
		private int lastSpawnTime = -1000;
        
        public override bool? UseItem(Player player)
        {

            Vector2 mousePosition = Main.MouseWorld;
			int currentTime = (int)Main.GameUpdateCount;
            int cooldown = 5 * 60; //defaults: 5 * 60
            // Calculate the direction vector from the player to the mouse
            Vector2 direction = mousePosition - player.Center;
            direction.Normalize();

			//projectiles
			Vector2 projtwo = new Vector2(player.position.X + 10f, player.position.Y + 15);
            Vector2 projthree = new Vector2(player.position.X + 10f, player.position.Y - 15);

            Vector2 newvelo = Item.velocity = direction;
			Vector2 playerPos = player.position;

			
            if (currentTime > lastSpawnTime + cooldown) //cool down is 5 seconds, lastSpawnTime is set to the current time, and then currentime
														 //is checked to have passed 5 seconds, then we spawn new instances of projectiles.
            {
                // Spawn projectile code here
				if (player.altFunctionUse == 2)
				{
					Projectile.NewProjectile(Projectile.InheritSource(player), playerPos, newvelo, ModContent.ProjectileType<LightOfBaneProjectile>(), 30, 4f, Main.myPlayer);
                    Thread.Sleep(100);
                    Projectile.NewProjectile(Projectile.InheritSource(player), playerPos, newvelo, ModContent.ProjectileType<LightOfBaneProjectile>(), 30, 4f, Main.myPlayer);
                    Thread.Sleep(100);
                    Projectile.NewProjectile(Projectile.InheritSource(player), playerPos, newvelo, ModContent.ProjectileType<LightOfBaneProjectile>(), 30, 4f, Main.myPlayer);
                    lastSpawnTime = currentTime;
				}
							
                
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