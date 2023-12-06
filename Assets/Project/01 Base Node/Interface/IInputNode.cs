// 日本語対応
using UnityEditor.Experimental.GraphView;

namespace Glib.NovelGameEditor
{
    /// <summary> Inputポートが存在するノードであることを表現する。 </summary>
    public interface IInputNode
    {
        Node Node { get; }
        void InputConnect(Node parent);
        void InputDisconnect(Node parent);
    }
}