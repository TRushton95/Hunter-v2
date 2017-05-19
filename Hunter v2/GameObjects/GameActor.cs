using Hunter_v2.Commands;
using Hunter_v2.Components.GameActorStates;
using Hunter_v2.Components.GameActorStates.ControlStates;
using Hunter_v2.Components.GameActorStates.RecoveryStates;
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
        public List<ICommand> inputCommands { get; set; }
        public IGameActorState controlState { get; set; }
        public IGameActorState recoveryState { get; set; }
        public IGameActorState newState { get; set; }

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

            this.controlState = new WalkingState();
            this.recoveryState = new UnharmedState();
        }

        public void update()
        {
            //TO BE REPLACED BY STATES (BELOW)
            inputCommands = inputComponent.processInput();

            foreach (ICommand c in inputCommands)
            {
                newState = controlState.processInput(this, c);
                if (newState != null)
                {
                    controlState = newState;
                }
            }

            movementComponent.move(positionComponent);
            healthComponent.deathCheck();
        }

        public void draw()
        {
            graphicsComponent.draw(positionComponent.position());
        }

    }
}
