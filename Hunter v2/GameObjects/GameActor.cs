using Hunter_v2.Commands;
using Hunter_v2.Components.Interfaces;
using Hunter_v2.Components.SizeComponents;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.GameObjects
{
    class GameActor
    {
        public IGraphicsComponent graphicsComponent { get; set; }
        public IInputComponent inputComponent { get; set; }
        public ISizeComponent sizeComponent { get; set; }
        public IPositionComponent positionComponent { get; set; }
        public IMovementComponent movementComponent { get; set; }
        public IHealthComponent healthComponent { get; set; }
        public IWeaponComponent weaponComponent { get; set; }
        public Command inputCommand { get; set; }

        public GameActor(IGraphicsComponent graphicsComponent, IInputComponent inputComponent, 
                ISizeComponent sizeComponent, IPositionComponent positionComponent, 
                IMovementComponent movementComponent, IHealthComponent healthComponent, 
                IWeaponComponent weaponComponent)
        {
            this.graphicsComponent = graphicsComponent;
            this.inputComponent = inputComponent;
            this.sizeComponent = sizeComponent;
            this.positionComponent = positionComponent;
            this.movementComponent = movementComponent;
            this.healthComponent = healthComponent;
            this.weaponComponent = weaponComponent;
        }

        public void update()
        {
            inputCommand = inputComponent.processInput();
            inputCommand.execute(this);

            movementComponent.move(positionComponent);
            healthComponent.deathCheck();
        }

        public void draw()
        {
            graphicsComponent.draw(positionComponent.position());
        }

    }
}
