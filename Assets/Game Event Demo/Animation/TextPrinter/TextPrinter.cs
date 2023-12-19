using Cysharp.Threading.Tasks;
using Glib.NovelGameEditor;
using System.Text;
using UnityEngine;

public class TextPrinter : NovelAnimationBehavior
{
    [SerializeField]
    private TextViewer _textView;

    [SerializeField]
    private TextData[] _textData;

    public override void OnEneter(AnimationNode node)
    {
        _textView.Show();
    }

    public async override UniTask PlayAnimationAsync()
    {
        foreach (var data in _textData)
        {
            ChangeCcaption(data.Caption);
            string text = data.Text;
            float interval = data.Interval;

            if (data.IsClearText)
            {
                ClearText();
            }

            int index = -1;
            float elapsed = 0f;

            while (index < text.Length - 1)
            {
                elapsed += Time.deltaTime;
                if (elapsed >= interval)
                {
                    elapsed -= interval;
                    index++;
                    AppendCharacter(text[index]);
                }

                if (StepTrigger())
                {
                    await UniTask.Yield();
                    break;
                }

                await UniTask.Yield();
            }
            if (index < text.Length) AppendCharacter(text[++index..]);

            await WaitNext();

            await UniTask.Yield();
        }
    }

    public override void OnExit(AnimationNode node)
    {
        _textView.Hide();
    }

    #region Private Methods

    private StringBuilder _stringBuilder = new StringBuilder();

    private void ChangeCcaption(string caption)
    {
        _textView.CaptionView.text = caption;
    }

    public void ShowText()
    {
        _textView.TextView.text = _stringBuilder.ToString();
    }

    private void AppendCharacter(params char[] c)
    {
        _stringBuilder.Append(c);
        ShowText();
    }

    private void AppendCharacter(string str)
    {
        _stringBuilder.Append(str);
        ShowText();
    }

    public void ClearText()
    {
        _stringBuilder.Clear();
        ShowText();
    }

    private bool StepTrigger()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    private async UniTask WaitNext()
    {
        await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
    }

    #endregion
}