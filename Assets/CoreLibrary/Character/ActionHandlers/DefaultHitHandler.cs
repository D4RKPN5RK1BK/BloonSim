using CoreLibrary.Damage;
using UnityEngine;

namespace CoreLibrary.Character
{
    [DisallowMultipleComponent]
    public class DefaultHitHandler : MonoBehaviour, IHitable
    {
        public HitModel hitModel;

        public virtual void OnDamageDeal(HurtModel model)
        {
            Debug.Log($"[Enemy] '{gameObject.name}' deal damage. ({Time.time})");
        }
    }
}