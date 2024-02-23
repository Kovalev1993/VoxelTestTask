using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private RectTransform _rectTransfrom;
    [SerializeField] private float _maxDeltaPosition;

    private Vector2 _startAnchoredPosition;

    public void OnDrag(PointerEventData eventData)
    {
        var scaledDelta = eventData.delta / _canvas.scaleFactor;
        var futurePosition = _rectTransfrom.anchoredPosition + scaledDelta;
        if(Vector2.Distance(_startAnchoredPosition, futurePosition) < _maxDeltaPosition)
            _rectTransfrom.anchoredPosition += scaledDelta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _rectTransfrom.anchoredPosition = _startAnchoredPosition;
    }

    private void Awake()
    {
        _startAnchoredPosition = _rectTransfrom.anchoredPosition;
    }
}