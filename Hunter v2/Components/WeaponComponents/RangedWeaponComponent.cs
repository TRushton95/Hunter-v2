using Hunter_v2.Components.HealthComponents;
using Hunter_v2.Components.InputComponents;
using Hunter_v2.Components.Interfaces;
using Hunter_v2.Components.MovementComponents;
using Hunter_v2.Components.SizeComponents;
using Hunter_v2.Components.PositionComponents;
using Hunter_v2.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunter_v2.Components.DirectionComponents;

namespace Hunter_v2.Components.WeaponComponents
{
    class RangedWeaponComponent : IWeaponComponent, IObservable<GameActor>
    {
        public IGraphicsComponent graphicsComponent { get; set; }
        public IObserver<GameActor> observer { get; set; }

        //MISSING - proper logic for initialisation projectile graphics
        public RangedWeaponComponent(IGraphicsComponent graphicsComponent)
        {
            this.graphicsComponent = graphicsComponent;
        }

        public void Fire(GameActor gameObject)
        {
            //UNSURE - this will certainly work when tied together with states, in this how we want to approach it though? needs thouught
            float velX = 0;
            float velY = 0;

            if (gameObject.directionComponent.currentDirection == 0) {
                velY = -10;
            }
            else if (gameObject.directionComponent.currentDirection == 1)
            {
                velX = -10;
            }
            else if (gameObject.directionComponent.currentDirection == 2)
            {
                velY = 10;
            }
            else if (gameObject.directionComponent.currentDirection == 3)
            {
                velX = 10;
            }

            // UNSURE - it seems that a new position must be created as using gameObjects passes the value byreference rather than byvalue, needs more investigation
            PositionComponent positionComponent = new PositionComponent(gameObject.positionComponent.posX, gameObject.positionComponent.posY);
            //needs some proper allocation here - purely standin for now
            GameActor projectile = new GameActor(graphicsComponent, new NullInputComponent(), new SizeComponent(50,50),
                positionComponent, new MovementComponent(), new NullHealthComponent(), new NullWeaponComponent(),
                new DirectionComponent(gameObject.directionComponent.currentDirection));
            // REMOVE - requires logic to fire in current facing direction - hopefully implemented with states?
            projectile.movementComponent.velY = velY;
            projectile.movementComponent.velX = velX;

            observer.OnNext(projectile);
        }

        public IDisposable Subscribe(IObserver<GameActor> observer)
        {
            if (this.observer==null)
            {
                this.observer = observer;
            }

            return new Unsubscriber<GameActor>(observer);
        }
    }

    //UNSURE
    internal class Unsubscriber<GameActor> : IDisposable
    {
        private IObserver<GameActor> observer;

        internal Unsubscriber(IObserver<GameActor> observer)
        {
            this.observer = observer;
        }

        public void Dispose()
        {
            if (observer != null)
                observer = null;
        }
    }

}
