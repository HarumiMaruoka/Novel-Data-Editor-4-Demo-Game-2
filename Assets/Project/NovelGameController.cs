// 日本語対応
using UnityEngine;

namespace Glib.NovelGameEditor
{
    public class NovelGameController : MonoBehaviour
    {
        [SerializeField]
        private NovelNodeGraph _nodeGraph;

        private Node _current = null;

        private bool _isPaused = false;

        private void Start()
        {
            Play();
        }

        public void Play()
        {
            if (!_nodeGraph)
            {
                Debug.LogWarning("Warning: NovelNodeGraph not assigned.");
                return;
            }

            foreach (var node in _nodeGraph.Nodes)
            {
                node.Initialize(this);
            }

            _isPaused = false;

            _current = _nodeGraph.RootNode.Child;
            _current.OnEnter();
        }

        public void Pause()
        {
            _isPaused = true;
        }

        public void Resume()
        {
            _isPaused = false;
        }

        private void Update()
        {
            if (_isPaused) return;

            if (_current != null)
            {
                _current.OnUpdate();
            }
        }

        public void MoveTo(Node node)
        {
            _current.OnExit();
            _current = node;
            if (_current != null) _current.OnEnter();
        }
    }
}