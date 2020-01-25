using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gui
{
    public class HealthBarController : MonoBehaviour
    {
        public Slider Slider;
        public Text Text;
        private Vector2 uiOffset;

        private void Start()
        {
            var canvas = HudManager.Instance.GetComponent<RectTransform>();
            this.uiOffset = new Vector2((float)canvas.sizeDelta.x / 2f, (float)canvas.sizeDelta.y / 2f);
        }

        public void UpdateValues(HealthComponent healthComponent)
        {
            Text.text = healthComponent.CurrentHealth.ToString();
            Slider.maxValue = healthComponent.MaxHealth;
            Slider.value = healthComponent.CurrentHealth;
        }

        public void UpdatePosition(Transform target)
        {
            Vector2 viewportPosition = Camera.main.WorldToViewportPoint(target.position + Vector3.forward*0.5f);
            var canvas = HudManager.Instance.GetComponent<RectTransform>();
            Vector2 proportionalPosition = new Vector2(viewportPosition.x * canvas.sizeDelta.x, viewportPosition.y * canvas.sizeDelta.y);
            GetComponent<RectTransform>().localPosition = proportionalPosition - uiOffset;
        }
    }
}
