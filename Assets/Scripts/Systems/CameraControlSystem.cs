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

            var currentCameraPosition = cameraEntity.camera.Camera.transform.position;

            var cameraSize = cameraEntity.camera.Camera.orthographicSize;

            var verticalArenaSize = arenaEntity.arena.ArenaData.Size.y * arenaEntity.arena.CellSize + arenaEntity.arena.CellSize;
            var horizontalArenaSize = Mathf.Max(arenaEntity.arena.ArenaData.Size.x * arenaEntity.arena.CellSize + 2f, cameraSize*2f);

            var top = verticalArenaSize / 2f - arenaEntity.arena.CellSize/2f;
            var bottom = -verticalArenaSize / 2f - arenaEntity.arena.CellSize/2f;
            var left = -horizontalArenaSize / 2f - arenaEntity.arena.CellSize/2f;
            var right = horizontalArenaSize / 2f - arenaEntity.arena.CellSize/2f;

            var rightTopWorld = new Vector3(0, 0, top);
            var leftBottomWorld = new Vector3(0, 0, bottom);

            var oldZValue = cameraEntity.camera.Camera.transform.position.z;
            cameraEntity.camera.Camera.transform.position = new Vector3(
                Mathf.Clamp(playerEntity.position.Value.x, left + cameraSize + arenaEntity.arena.CellSize / 2f, right - cameraSize - arenaEntity.arena.CellSize / 2f),
                currentCameraPosition.y,
                playerEntity.position.Value.y);
            currentCameraPosition = cameraEntity.camera.Camera.transform.position;

            var rightTopViewport = cameraEntity.camera.Camera.WorldToViewportPoint(rightTopWorld);
            var leftBottomViewport = cameraEntity.camera.Camera.WorldToViewportPoint(leftBottomWorld);

            if (rightTopViewport.y < 1f || leftBottomViewport.y > 0f)
            {
                cameraEntity.camera.Camera.transform.position = new Vector3(
                    currentCameraPosition.x,
                    currentCameraPosition.y,
                    oldZValue);
            }
        }
    }
}