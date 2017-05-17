using Hunter_v2.Components.HealthComponents;
using Hunter_v2.Components.InputComponents;
using Hunter_v2.Components.Interfaces;
using Hunter_v2.Components.MovementComponents;
using Hunter_v2.Components.SizeComponents;
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
    class RangedWeaponComponent : IWeaponComponent, IObservable<GameActor>
    {
        IGraphicsComponent graphicsComponent;
        IObserver<GameActor> observer;

        public RangedWeaponComponent()
        {
            graphicsComponent = new GraphicsComponent(null, null);
        }

        public GameActor Fire(GameActor gameObject)
        {
            //needs some proper allocation here - purely standin for now
            GameActor projectile = new GameActor(graphicsComponent, new NullInputComponent(), new SizeComponent(10,10), gameObject.positionComponent, new MovementComponent(), new NullHealthComponent(), new NullWeaponComponent());

            observer.OnNext(projectile);

            return projectile;
        }

        public IDisposable Subscribe(IObserver<GameActor> observer)
        {
            if (observer==null)
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
