using Assets.Scripts.Utils;
using Entitas;

namespace Assets.Scripts.Systems
{
    public class UpdatePlayerTargetViewSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public UpdatePlayerTargetViewSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.TargetMarker);
        }

        public void Execute()
        {
            foreach (var gameEntity in _group.GetEntities())
            {
                if (!gameEntity.hasView)
                {
                    continue;
                }

                if (gameEntity.targetMarker.Target == null)
                {
                    gameEntity.view.Value.SetActive(false);
                    continue;
                }

                gameEntity.view.Value.transform.position = gameEntity.targetMarker.Target.position.Value.xz();
            }
        }
    }
}