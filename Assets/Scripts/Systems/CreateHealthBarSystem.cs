using System.Collections.Generic;
using Assets.Scripts.Gui;
using Client.Configs;
using Client.Configs.View;
using Entitas;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class CreateHealthBarSystem : ReactiveSystem<GameEntity>
    {
        public CreateHealthBarSystem(IContext<GameEntity> context) : base(context)
        {
        }

        public CreateHealthBarSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Health);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                if (ConfigsManager.Instance.ViewConfig.GetValue(ViewType.HealthBar, out var gameObject))
                {
                    var healthBar = Object.Instantiate(gameObject, HudManager.Instance.transform).GetComponent<HealthBarController>();
                    gameEntity.AddHealthBar(healthBar);
                }
            }
        }
    }
}