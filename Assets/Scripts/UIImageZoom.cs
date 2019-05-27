using UnityEngine;
using UnityEngine.EventSystems;

public class UIImageZoom : MonoBehaviour, IScrollHandler
{
    private Vector3 initialScale;

    private RectTransform rectTransform
    {
        get { return transform as RectTransform; }
    }

    [SerializeField]
    private float zoomSpeed = 0.1f;
    [SerializeField]
    private float maxZoom = 10f;

    private void Awake()
    {
        initialScale = transform.localScale;
    }

    public void OnScroll(PointerEventData eventData)
    {
        var delta = Vector3.one * (eventData.scrollDelta.y * zoomSpeed);
        var desiredScale = transform.localScale + delta;

        Vector2 localpoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, GetComponentInParent<Canvas>().worldCamera, out localpoint);
        Vector2 normalizedPoint = Rect.PointToNormalized(rectTransform.rect, localpoint);
        // Debug.Log(normalizedPoint);

        // Debug.Log(Input.mousePosition);
        // Debug.Log(rectTransform.pivot);

        // rectTransform.pivot = normalizedPoint;
        // rectTransform.pivot = Vector2.LerpUnclamped(rectTransform.pivot, normalizedPoint, Time.deltaTime);
        rectTransform.pivot = Vector2.Lerp(rectTransform.pivot, normalizedPoint, Time.deltaTime);

        // transform.position = Vector2.Lerp(Time.deltaTime);

        desiredScale = ClampDesiredScale(desiredScale);
        transform.localScale = desiredScale;
    }

    private Vector3 ClampDesiredScale(Vector3 desiredScale)
    {
        desiredScale = Vector3.Max(initialScale, desiredScale);
        desiredScale = Vector3.Min(initialScale * maxZoom, desiredScale);
        return desiredScale;
    }
}