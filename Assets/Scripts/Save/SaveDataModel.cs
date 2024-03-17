using CoreLibrary.Save;
using System;

namespace Assets.Scripts.Save
{
    [Serializable]
    internal class SaveDataModel : ISaveModel
    {
        public string FileName => name;

        public string name;

        public bool screamerTriggered;

        public float musicVolume;

        public float soundVolume;
    }
}
