using Assets.Scripts.Common;
using CoreLibrary.Character;
using CoreLibrary.Common;
using UnityEngine;

namespace Assets.Scripts.Character.ActionHandlers
{
    public class BloonSpawnHandler : BaseActionHandler
    {
        private GameObject spawner;

        private PoolController poolController;

        private void Start()
        {
            poolController = PoolController.Instance;
            spawner = transform.Find("Character").Find("Spawner").gameObject;
        }

        public void SpawnBloon()
        {
            var bloon = poolController.Take(PoolTags.Bloons);
            bloon.transform.position = spawner.transform.position;
            bloon.GetComponent<BloonReseter>().Reset();
            Trigger();
        }
    }
}