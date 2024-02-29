using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public float waveOffset = 0;

    public float horizontalOffset = 5;

    public float verticalOffset = 5;

    private Vector3 initialPosition;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.localPosition;
    }

    private void Update()
    {
        var offset = Mathf.Sin(Time.time + rectTransform.localPosition.x + waveOffset) * verticalOffset;
        rectTransform.localPosition = initialPosition + new Vector3(0, offset, 0);
    }
}
