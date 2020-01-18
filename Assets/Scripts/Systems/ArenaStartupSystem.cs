using Client.Configs.View;
using Entitas;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class ArenaStartupSystem : IInitializeSystem
    {
        private readonly GameContext _context;
        public ArenaStartupSystem(Contexts contexts)
        {
            _context = contexts.game;
        }

        public void Initialize()
        {
            var player = _context.CreateEntity();
            player.AddViewSource(ViewType.Player);
            player.AddPosition(Vector2.zero);
            player.AddRotation(0);
            player.isSyncView = true;
            player.AddMovement(0.07f, false);
            player.AddDirection(Vector2.zero);
            player.isPlayer = true;
        }
    }
}