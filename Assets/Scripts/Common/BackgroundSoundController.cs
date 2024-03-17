using Assets.Scripts.Save;
using System;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public class BackgroundSoundController : MonoBehaviour
    {
        private CrossSceneDataController crossSceneDataController;

        private AudioSource audioSource;

        public Action SettingsAction { get; set; } = () => { };

        public static BackgroundSoundController Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
                Destroy(this);
            else
            {
                audioSource = GetComponent<AudioSource>();
                Instance = this;
            }
        }

        private void Start()
        {
            crossSceneDataController = CrossSceneDataController.Instance;
            ApplySettings();
        }

        public void ApplySettings()
        {
            var sound = crossSceneDataController.Model.musicVolume;
            audioSource.volume = sound;
            SettingsAction();
        }
    }
}