using Entitas;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class SyncViewRotationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public SyncViewRotationSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.SyncViewRotation);
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                var view = entity.view;

                var rotation = entity.rotation;
                if (rotation != null)
                {
                    view.Value.transform.rotation = Quaternion.Euler(0, rotation.Value, 0);
                }
            }
        }
    }
}