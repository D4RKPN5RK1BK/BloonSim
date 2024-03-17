using Assets.Scripts.Save;
using UnityEngine;

namespace Assets.Scripts.Common
{
    internal class SoundEffectController : MonoBehaviour
    {
        private AudioSource source;
        private CrossSceneDataController crossSceneDataController;
        private BackgroundSoundController backgroundSoundController;

        private void Awake()
        {
            source = GetComponent<AudioSource>();
        }

        private void Start()
        {
            crossSceneDataController = CrossSceneDataController.Instance;
            backgroundSoundController = BackgroundSoundController.Instance;
            backgroundSoundController.SettingsAction += UpdateValue;
            UpdateValue();
        }

        private void UpdateValue()
        {
            source.volume = crossSceneDataController.Model.soundVolume;
        }
    }
}
