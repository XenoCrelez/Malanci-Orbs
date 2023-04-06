using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;

namespace Malanci_Orbs.Content.Items.Weapons.Projectiles.Weapons
{
    public class LightOfBaneProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lights of the Bane's Slash");
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 600;
            Projectile.light = 0.25f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.damage = 10;
        }
        
        public override void AI()
        {
            float cooldown = LightsOfTheBane.cooldown;

            cooldown = Projectile.ai[0];

            Projectile.ai[0]++;
            Vector2 mousePosition = Main.MouseWorld;

            // Calculate the direction vector from the player to the mouse
            float veloX = Projectile.velocity.X;
            float veloY = Projectile.velocity.Y;

            float rotation = MathHelper.ToRadians(90f) + (float)Math.Atan2((double)veloY, (double)veloX);
            
            Projectile.rotation = rotation;
            if (Projectile.ai[0] < 25f) 
            {
                Projectile.velocity *= 1.1f;
                

            }
            else
            {
                Projectile.velocity.Y += 0.2f; // add a constant Y velocity component
                Projectile.rotation += MathHelper.ToRadians(2f); // rotate the projectile downwards
                Projectile.alpha++;
            }
            if (Projectile.ai[0] >= 180 || cooldown != 0)
            {
                Projectile.Kill();
            }


            int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.MagicMirror, 0f, 0f, 0, default, 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0.3f;
            Main.dust[dust].scale = Main.rand.Next(100, 135) * 0.013f;

            int dust2 = Dust.NewDust(Projectile.Center, 1, 1, DustID.Shadowflame, 0f, 0f, 0, default, 1f);
            Main.dust[dust2].noGravity = true;
            Main.dust[dust2].velocity *= 0.3f;
            Main.dust[dust2].scale = Main.rand.Next(100, 135) * 0.013f;
        }


    }
}
