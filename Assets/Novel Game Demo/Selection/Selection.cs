using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace NovelGameEditor4
{
    public class Selection : MonoBehaviour
    {
        [SerializeField]
        private Transform _viewParent;
        [SerializeField]
        private SelectableView _selectableViewPrefab;

        private Stack<SelectableView> _hided = new Stack<SelectableView>();
        private Stack<SelectableView> _showed = new Stack<SelectableView>();

        [SerializeField]
        private SelectableData[] _data;

        private void Start()
        {
            Show(_data);
        }


#pragma warning disable CS1998
        public async UniTask Show(IEnumerable<SelectableData> selectableData)
#pragma warning restore CS1998
        {
            if (!_selectableViewPrefab)
            {
                Debug.LogWarning("Warning: SelectableViewPrefab is not assigned");
                return;
            }

            foreach (var data in selectableData)
            {
                SelectableView view = null;
                if (_hided.Count == 0)
                {
                    view = GameObject.Instantiate(_selectableViewPrefab, _viewParent);
                }
                else
                {
                    view = _hided.Pop();
                    view.transform.parent = _viewParent;
                }
                view.Show(data);
            }
        }

#pragma warning disable CS1998
        public async UniTask Hide()
#pragma warning restore CS1998
        {
            while (_showed.Count > 0)
            {
                var pop = _showed.Pop();
                pop.Hide();
                _hided.Push(pop);
            }
        }
    }
}