// 日本語対応
using System.Collections.Generic;
using UnityEngine;

namespace Glib.NovelGameEditor
{
    [GraphViewContextMenu]
    public class AnimationNode : Node, ISingleChild, IMultiParent
    {
#if Novel_Game_Editor_4_Development
        [SerializeField]
#else
        [SerializeField]
        [HideInInspector]
#endif
        private Node _child = null;
#if Novel_Game_Editor_4_Development
        [SerializeField]
#else
        [SerializeField]
        [HideInInspector]
#endif
        private List<Node> _parents = new List<Node>();
        [SerializeField]
        private NovelAnimationController _novelAnimationController;

        public Node Node => this;
        public Node Child { get => _child; set => _child = value; }
        public List<Node> Parents => _parents;

        public void InputConnect(Node parent)
        {
            _parents.Add(parent);
        }

        public void InputDisconnect(Node parent)
        {
            _parents.Remove(parent);
        }

        public void OutputConnect(Node child)
        {
            _child = child;
        }

        public void OutputDisconnect(Node child)
        {
            _child = null;
        }

        public override async void OnEnter()
        {
            _novelAnimationController.OnEnter(this);
            // 演出の再生が完了したら子ノードに遷移する。
            await _novelAnimationController.Play();
            _controller.MoveTo(_child);
        }

        public override void OnExit()
        {
            _novelAnimationController.OnExit(this);
        }
    }
}