using UnityEngine;

namespace Assets.Scripts.Gui
{
    public class HudManager : MonoBehaviour
    {
        public static HudManager Instance;

        private void Awake()
        {
            Instance = this;
        }
    }
}