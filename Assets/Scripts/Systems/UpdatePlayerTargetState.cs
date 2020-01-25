using System.Collections.Generic;
using Client.Configs.View;
using Entitas;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class UpdatePlayerTargetSystem : ReactiveSystem<GameEntity>
    {
        private readonly IContext<GameEntity> _game;
        private readonly IGroup<GameEntity> _group;

        public UpdatePlayerTargetSystem(IContext<GameEntity> context) : base(context)
        {
            _game = context;
            _group = _game.GetGroup(GameMatcher.TargetMarker);
        }

        public UpdatePlayerTargetSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Target);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                GameEntity targetEntity;
                var currentTarget = gameEntity.target.Value;
                if (_group.count == 0)
                {
                    targetEntity = _game.CreateEntity();
                    targetEntity.AddTargetMarker(null);
                    targetEntity.AddViewSource(ViewType.TargetMarker);
                    targetEntity.AddPosition(Vector2.zero);
                    targetEntity.isSyncViewPosition = true;
                }
                else
                {
                    targetEntity = _group.GetSingleEntity();
                }

                targetEntity.targetMarker.Target = currentTarget;
            }
        }
    }
}