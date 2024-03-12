using Assets.Scripts.Character.ActionHandlers;
using CoreLibrary.Common;
using UnityEngine;

public class UseTipController : MonoBehaviour
{
    private readonly int Select = Animator.StringToHash(nameof(Select));
    private readonly int Deselect = Animator.StringToHash(nameof(Deselect));

    public BloonSpawnHandler source;
    private Animator animator;
    private BloonCounter sourceBloons;

    private bool active;
    private bool pauseHide;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        var commonController = CommonController.Instance;

        source.Trigger += SpawnHandler;
        source.GetComponent<PickupHandler>().Trigger += SpawnHandler;
        animator.SetTrigger(Select);
        active = true;
        sourceBloons = source.GetComponent<BloonCounter>();

        commonController.OnPauseToggle += () => 
        { 
            if (active) 
            { 
                animator.SetTrigger(Deselect);  
                pauseHide = true;
            } 
        };
        commonController.OnResumeToggle += () =>
        {
            if (pauseHide)
            {
                animator.SetTrigger(Select);
                pauseHide = false;
            }
        };

    }

    private void SpawnHandler()
    {
        if (sourceBloons.BloonCount == 0 && active)
        {
            active = false;
            animator.SetTrigger(Deselect);
        }

        if (!active && sourceBloons.BloonCount > 0)
        {
            active = true;
            animator.SetTrigger(Select);
        }
    }
}
