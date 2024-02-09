using CoreLibrary.Common;
using System.Collections;
using UnityEngine;

public class ResumeApplayer : MonoBehaviour
{
    public void Resume()
    {
        StartCoroutine(ResumeCoroutine());
    }

    private IEnumerator ResumeCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.06f);
        CommonController.Instance.Pause();
    }
}
