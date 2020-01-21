using System.Data;
using Entitas;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class CameraControlSystem : IExecuteSystem
    {

        private readonly IGroup<GameEntity> _cameraGroup;
        private readonly IGroup<GameEntity> _playerGroup;
        private readonly IGroup<GameEntity> _arenaGroup;
        public CameraControlSystem(Contexts contexts)
        {
            _cameraGroup = contexts.game.GetGroup(GameMatcher.Camera);
            _playerGroup = contexts.game.GetGroup(GameMatcher.Player);
            _arenaGroup = contexts.game.GetGroup(GameMatcher.Arena);
        }

        public void Execute()
        {
            GameEntity cameraEntity = _cameraGroup.GetSingleEntity();
            GameEntity playerEntity = _playerGroup.GetSingleEntity();
            GameEntity arenaEntity = _arenaGroup.GetSingleEntity();

            var camera = cameraEntity.camera.Camera;
            var currentCameraPosition = camera.transform.position;

            var horizontalArenaSize = arenaEntity.arena.ArenaData.Size.x * arenaEntity.arena.CellSize + arenaEntity.arena.CellSize;
            var aspectRatio = (float) Screen.width / Screen.height;
            camera.orthographicSize = (horizontalArenaSize / 2f) / aspectRatio;

            camera.transform.position = new Vector3(
                currentCameraPosition.x,
                currentCameraPosition.y,
                playerEntity.position.Value.y);
        }
    }
}