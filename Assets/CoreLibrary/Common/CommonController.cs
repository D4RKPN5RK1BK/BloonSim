using System;
using UnityEngine;

namespace CoreLibrary.Common
{
    /// <summary>
    /// Отвечает за обработку логики самой сцены а не конкретного персонажа
    /// </summary>
    public class CommonController : MonoBehaviour
    {
        public bool disableCursor;

        public Action<bool> OnPauseToggle { get; set; } = _ => { };
        public Action<bool> OnCompleteToggle { get; set; } = _ => { };

        public bool inPause { get;  private set; }
        public bool isCompleted { get; private set; }

        public static CommonController Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
                Destroy(this);
            else
                Instance = this;

        }

        private void Start()
        {
            Time.timeScale = 1.0f;
        }

        public void Pause()
        {
            inPause = !inPause;
            Cursor.visible = disableCursor && inPause;

            if (inPause)
                Time.timeScale = 0.0f;
            else
                Time.timeScale = 1.0f;

            OnPauseToggle(inPause);
        }

        public void Complete()
        {
            isCompleted = true;
            Cursor.visible = disableCursor && isCompleted;
            OnCompleteToggle(isCompleted);
        }
    }
}