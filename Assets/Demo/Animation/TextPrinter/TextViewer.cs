using UnityEngine;
using UnityEngine.UI;

public class TextViewer : MonoBehaviour
{
    [SerializeField]
    private Text _captionView;
    [SerializeField]
    private Text _textView;

    public Text CaptionView => _captionView;
    public Text TextView => _textView;

    public void Show()
    {

    }

    public void Hide()
    {

    }
}