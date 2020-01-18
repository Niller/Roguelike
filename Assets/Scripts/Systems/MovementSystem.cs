using System.Numerics;
using Entitas;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Assets.Scripts.Systems
{
    public class MovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public MovementSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.Movement);
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                if (!entity.movement.Move)
                {
                    entity.view.Value.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    continue;
                }

                if (!entity.hasDirection)
                {
                    continue;
                }

                var offset = entity.direction.Value * entity.movement.Speed;
                var newPosition = entity.position.Value + offset;
                if (!entity.isSyncModelPosition)
                {
                    entity.position.Value = newPosition;
                }
                else
                {
                    //entity.view.Value.GetComponent<Rigidbody>().AddForce(new Vector3(newPosition.x, 0, newPosition.y));
                    entity.view.Value.GetComponent<Rigidbody>().velocity = new Vector3(offset.x, 0, offset.y);
                }

            }
        }
    }
}