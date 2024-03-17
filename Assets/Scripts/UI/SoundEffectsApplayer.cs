using Assets.Scripts.Save;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    internal class SoundEffectsApplayer : MonoBehaviour
    {
        private CrossSceneDataController crossSceneDataController;

        private Slider slider;

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        private void Start()
        {
            crossSceneDataController = CrossSceneDataController.Instance;
            slider.value = crossSceneDataController.Model.soundVolume;
        }

        public void UpdateEffectsVolume()
        {
            crossSceneDataController.Model.soundVolume = slider.value;
        }
    }
}
