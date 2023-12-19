using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

namespace NovelGameEditor4
{
    public class SelectableView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        protected Image _backGround;
        [SerializeField]
        protected TMPro.TextMeshProUGUI _textView;

        [SerializeField]
        protected Color _normalColor = Color.white;
        [SerializeField]
        protected Color _hoveredColor = Color.red;

        protected SelectableData _data;

        public virtual void OnEnable()
        {
            _backGround.color = _normalColor;
        }

        public virtual void Select()
        {
            _data.SelectedCommand?.RunCommandAsync().Forget();
        }

        public virtual void Show(SelectableData data)
        {
            _data = data;

            _textView.text = _data.Text;
            _backGround.sprite = data.Background;

            this.gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            this.gameObject.SetActive(false);
        }

        #region Interface Implementation
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            Select();
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            _backGround.color = _hoveredColor;
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            _backGround.color = _normalColor;
        }
        #endregion
    }
}