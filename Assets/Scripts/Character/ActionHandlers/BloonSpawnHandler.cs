using Assets.Scripts.Common;
using CoreLibrary.Character;
using CoreLibrary.Common;
using UnityEngine;

namespace Assets.Scripts.Character.ActionHandlers
{
    [RequireComponent(typeof(BloonCounter))]
    public class BloonSpawnHandler : BaseActionHandler
    {
        private GameObject spawner;
        private BloonCounter bloonCounter;
        private PoolController poolController;

        private void Awake()
        {
            bloonCounter = GetComponent<BloonCounter>();
        }

        private void Start()
        {
            poolController = PoolController.Instance;
            spawner = transform.Find("Character").Find("Spawner").gameObject;
        }

        public void SpawnBloon()
        {
            if (bloonCounter.BloonCount > 0)
            {
                bloonCounter.BloonCount--;
                var bloon = poolController.Take(PoolTags.Bloons);
                bloon.transform.position = spawner.transform.position;
                bloon.GetComponent<BloonReseter>().Reset();
                bloon.transform.up = spawner.transform.forward;

            }

            Trigger();
        }
    }
}