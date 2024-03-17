using Assets.Scripts.Common;
using Assets.Scripts.Save;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class MusicApplayer : MonoBehaviour
    {
        private CrossSceneDataController crossSceneDataController;
        private BackgroundSoundController backgroundSoundController;

        private Slider slider;

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        private void Start()
        {
            crossSceneDataController = CrossSceneDataController.Instance;
            backgroundSoundController = BackgroundSoundController.Instance;

            Debug.Log($"background value = {crossSceneDataController.Model.musicVolume}");

            slider.value = crossSceneDataController.Model.musicVolume;
        }

        public void UpdateMusicVolume()
        {
            crossSceneDataController.Model.musicVolume = slider.value;
            backgroundSoundController.ApplySettings();
        }
    }
}