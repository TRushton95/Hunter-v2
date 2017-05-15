using Hunter_v2.Components.HealthComponents;
using Hunter_v2.Components.InputComponents;
using Hunter_v2.Components.Interfaces;
using Hunter_v2.Components.MovementComponents;
using Hunter_v2.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.WeaponComponents
{
    class RangedWeaponComponent : IWeaponComponent
    {
        IGraphicsComponent graphicsComponent;

        public RangedWeaponComponent()
        {
            graphicsComponent = new GraphicsComponent(null, null);
        }

        public GameActor Fire(GameActor gameObject)
        {
            //needs some proper allocation here - purely standin for now
            GameActor projectile = new GameActor(graphicsComponent, new NullInputComponent(), gameObject.positionComponent, new MovementComponent(), new NullHealthComponent(), new NullWeaponComponent());

            return projectile;
        }
    }
}
