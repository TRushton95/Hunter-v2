using Hunter_v2.Commands;
using Hunter_v2.Components.CollisionComponents;
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
        public IDirectionComponent directionComponent { get; set; }
        public ICollisionComponent collisionComponet { get; set; }
        public List<Command> inputCommands { get; set; }
        public IGameActorControlState controlState { get; set; }
        public IGameActorRecoveryState recoveryState { get; set; }
        public IGameActorControlState newControlState { get; set; }
        public IGameActorRecoveryState newRecoveryState { get; set; }

        public GameActor(IGraphicsComponent graphicsComponent, IInputComponent inputComponent, 
                ISizeComponent sizeComponent, IPositionComponent positionComponent, 
                IMovementComponent movementComponent, IHealthComponent healthComponent, 
                IWeaponComponent weaponComponent, IDirectionComponent directionComponent,
                ICollisionComponent collisionComponet)
        {
            this.graphicsComponent = graphicsComponent;
            this.inputComponent = inputComponent;
            this.sizeComponent = sizeComponent;
            this.positionComponent = positionComponent;
            this.movementComponent = movementComponent;
            this.healthComponent = healthComponent;
            this.weaponComponent = weaponComponent;
            this.directionComponent = directionComponent;
            this.collisionComponet = collisionComponet;

            this.controlState = new WalkingState();
            this.recoveryState = new UnharmedState();
        }

        public void update()
        {

            inputCommands = inputComponent.processInput();

            foreach (Command c in inputCommands)
            {
                newControlState = controlState.processInput(this, c);
                if (newControlState != null)
                {
                    controlState.exit(this);
                    controlState = newControlState;
                    controlState.enter(this);
                }
            }

            controlState.update(this);
            recoveryState.update(this);

            movementComponent.move(positionComponent);

            healthComponent.deathCheck();
        }

        public void draw(Vector2 offset)
        {
            string namePlate = "";
            if (healthComponent.maxHealth >= 0)
            {
                namePlate = healthComponent.currentHealth + "/" + healthComponent.maxHealth;
            }

            graphicsComponent.draw(positionComponent.position() - offset, namePlate);
        }

    }
}
