using CoreLibrary.Damage;
using UnityEngine;

namespace CoreLibrary.Character
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(DefaultDestructHandler))]
    public class DefaultHurtHandler : MonoBehaviour, IHurtable
    {
        public HurtModel hurtModel;

        DefaultDestructHandler _destructHandler;

        private float invicibilityEndTime;
        
        private void Awake()
        {
            _destructHandler = GetComponent<DefaultDestructHandler>();
        }

        public virtual void OnDamageReceive(HitModel model)
        {
            if (Time.time > invicibilityEndTime)
            {
                invicibilityEndTime = hurtModel.invicibilityTime + Time.time;
                _destructHandler.Destroy();
            }   
        }
    }
}