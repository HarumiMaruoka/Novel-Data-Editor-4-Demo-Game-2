// 日本語対応
using Glib.NovelGameEditor;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectableView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Text _textView;
    [SerializeField]
    private Image _background;

    public event Action<SelectableView> OnSelected;

    private BranchElement _selectable;
    public BranchElement Selectable => _selectable;

    public void Initialize(BranchElement selection)
    {
        _selectable = selection;
        _textView.text = _selectable.Text;
    }

    public void Dispose()
    {
        OnSelected = null;
        _selectable = null;
    }

    public virtual void OnShow()
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
    }

    protected virtual void Update()
    {

    }

    public virtual void OnHide()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        OnSelected?.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _background.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _background.color = Color.red;
    }
}