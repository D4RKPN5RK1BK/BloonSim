using CoreLibrary.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PauseHeaderController : MonoBehaviour
{
    private readonly int Jump = Animator.StringToHash(nameof(Jump));

    private List<Animator> _lettersAnimators;
    private CommonController _commonController;

    void Start()
    {
        _lettersAnimators = GetComponentsInChildren<Animator>().ToList();
        _commonController = CommonController.Instance;
        //_commonController.OnPauseToggle += OnPauseHandler;
        //_commonController.OnResumeToggle += OnResumeHandler;

        StartCoroutine(AnimationToggleRoutine());
    }

    void Update()
    {
        
    }

    //private void OnPauseHandler()
    //{
    //    StopCoroutine(AnimationToggleRoutine());
    //}

    //private void OnResumeHandler()
    //{
    //    StartCoroutine(AnimationToggleRoutine());
    //}

    private IEnumerator AnimationToggleRoutine()
    {
        yield return new WaitForSecondsRealtime(10);

        foreach (var animator in _lettersAnimators)
        {

            animator.SetTrigger(Jump);
            yield return new WaitForSecondsRealtime(0.04f);
        }

        StartCoroutine(AnimationToggleRoutine());
    }
}
