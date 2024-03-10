using Assets.Scripts.Character.ActionHandlers;
using CoreLibrary.Character;
using CoreLibrary.Common;
using CoreLibrary.Input;
using UnityEngine;

namespace Assets.Scripts.Input
{
    public class CharacterInputController : InputControler<PlayerInput>
    {
        private POVHandler rotateHandler;
        private WalkHandler walkHandler;
        private PickupHandler pickupHandler;
        private BloonSpawnHandler bloonSpawnHandler;
        private JumpHandler jumpHandler;

        protected override void Awake()
        {
            base.Awake();
            pickupHandler = GetComponent<PickupHandler>();
            rotateHandler = GetComponent<POVHandler>();
            walkHandler = GetComponent<WalkHandler>();
            jumpHandler = GetComponent<JumpHandler>();
            bloonSpawnHandler = GetComponent<BloonSpawnHandler>();

            ActionSet.InGame.Jump.performed += _ => { jumpHandler.Jump(); };
        }

        private void Start()
        {
            var common = CommonController.Instance;

            ActionSet.InGame.Spawn.performed += _ => { bloonSpawnHandler.SpawnBloon(); };
            ActionSet.InGame.Pickup.performed += _ => { pickupHandler.ActivatePickup(); };

            common.OnPauseToggle += () => { ActionSet.InGame.Disable(); };
            common.OnResumeToggle += () => { ActionSet.InGame.Enable(); };
        }

        private void Update()
        {
            rotateHandler.Rotate(ActionSet.InGame.Rotate.ReadValue<Vector2>());
            walkHandler.Walk(ActionSet.InGame.Move.ReadValue<Vector2>());
        }
    }
}