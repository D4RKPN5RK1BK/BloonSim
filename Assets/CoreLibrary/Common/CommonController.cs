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

        public Action OnPauseToggle { get; set; } = () => { };
        public Action OnResumeToggle { get; set; } = () => { };
        public Action OnCompleteToggle { get; set; } = () => { };

        public bool InPause { get;  private set; }
        public bool IsCompleted { get; private set; }

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
            Cursor.visible = !disableCursor || InPause;
        }

        public void Pause()
        {
            InPause = !InPause;
            Cursor.visible = disableCursor && InPause;

            if (InPause)
            {
                Time.timeScale = 0.0f;
                OnPauseToggle();
            }
            else
            {
                OnResumeToggle();
                Time.timeScale = 1.0f;
            }
        }

        public void Complete()
        {
            IsCompleted = true;
            Cursor.visible = disableCursor && IsCompleted;
            OnCompleteToggle();
        }
    }
}