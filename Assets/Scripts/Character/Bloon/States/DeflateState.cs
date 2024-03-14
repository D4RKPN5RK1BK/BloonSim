using CoreLibrary.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Character.Bloon.States
{
    public class DeflateState : CharacterState<BloonStateFactory>
    {
        private GameObject deflateModel;
        private GameObject normalModel;
        private Renderer[] normalRederers;
        private Renderer[] deflateRederers;


        private float duration = 3.0f;
        private readonly Rigidbody rigitbody;
        private readonly AudioSource audioSource;

        private float endOfState;

        private float force;

        private readonly Color[] colors =
        {
            Color.blue, Color.green, Color.red, Color.clear, Color.black, Color.magenta
        };

        public DeflateState(GameObject model, IStateContext<BloonStateFactory> handler, BloonStateFactory factory) : base(model, handler, factory)
        {
            rigitbody = model.GetComponent<Rigidbody>();
            audioSource = model.GetComponent<AudioSource>();
            deflateModel = model.transform.Find("DeflateModel").gameObject;
            normalModel = model.transform.Find("Model").gameObject;
            normalRederers = normalModel.GetComponentsInChildren<Renderer>();
            deflateRederers = deflateModel.GetComponentsInChildren<Renderer>();
        }

        public override void CheckSwitchState()
        {
            if (Time.time > endOfState)
            {
                SwitchState(Factory.Drop);
            }
        }

        public override void EnterState()
        {
            normalModel.SetActive(true);
            deflateModel.SetActive(false);

            audioSource.Play();

            var color = colors[Random.Range(0, colors.Length)];

            foreach (var material in normalRederers)
                material.material.color = new Color(color.r, color.g, color.b, 0.7f);

            foreach (var material in deflateRederers)
                material.material.color = new Color(color.r, color.g, color.b, 1);

            normalModel.transform.localScale = Vector3.one;

            endOfState = Time.time + duration;
            force = 0.2f;
        }

        public override void ExitState()
        {
            
        }

        public override void HandleState()
        {
            var k = 1 -  ((endOfState - Time.time) / duration);
            var scaleK = 0.4f + (1 - k) * 0.6f;

            normalModel.transform.localScale = Vector3.one * scaleK;

            force = 0.2f + (k / 3);
            var random = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
            rigitbody.AddForce((Model.transform.up + random) * force);
        }
    }
}
