using Assets.Scripts.Configs.Arena;
using Client.Configs.View;
using UnityEngine;

namespace Client.Configs
{
    class ConfigsManager : MonoBehaviour
    {
        public static ConfigsManager Instance;

#pragma warning disable 649

        public ViewConfig ViewConfig;
        public ArenaConfig ArenaConfig;

#pragma warning restore 649

        private void Awake()
        {
            Instance = this;
        }
    }
}
