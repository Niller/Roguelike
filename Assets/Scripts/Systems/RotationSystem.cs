using Entitas;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class RotationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public RotationSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.Direction);
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                if (entity.hasRotation)
                {
                    //var offset = new Vector2(Screen.width / 2f, Screen.height / 2f);
                    
                    var angle = -Vector2.SignedAngle(Vector2.up, entity.direction.Value);
                    angle = angle < 0 ? 360 + angle : angle;
                    entity.rotation.Value = angle;
                    //_rotateEventEntity.Get<RotateEventComponent>().Value = angle;
                }
            }
        }
    }
}