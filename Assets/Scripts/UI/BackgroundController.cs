using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public const int Main = 0;
    public const int Settings = 1;

    private RectTransform closeBubbles;
    private RectTransform farBubbles;

    private Vector3 initialposition;
    private Vector3 targetPosition;
    private float currentValue;

    private void Start()
    {
        farBubbles = transform.Find("FarBubbles").GetComponent<RectTransform>();
        farBubbles = transform.Find("CloseBubbles").GetComponent<RectTransform>();
    }

    public void SwitchPosition(int positionCode)
    {
        switch(positionCode)
        {
            case Main: break;
        }

        currentValue = 0;
        //initialValue = transform.position;
        
    }

    private void Update()
    {
        currentValue += Time.deltaTime;
        //var position = Vector3.Lerp()
    }
}
