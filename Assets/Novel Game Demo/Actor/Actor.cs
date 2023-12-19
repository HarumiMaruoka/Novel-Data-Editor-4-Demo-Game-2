using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Actor : MonoBehaviour
{
    [SerializeField]
    private RectTransform _actorRoot;

    [SerializeField]
    private Image _foreImage;
    [SerializeField]
    private Image _backImage;

    [SerializeField]
    private Sprite[] _sprites;

    private async void Start()
    {
        var onDestroyCancellationToken = this.GetCancellationTokenOnDestroy();

        try
        {
            await ChangeTextureAsync(0, 1f, onDestroyCancellationToken);
            await ChangeTextureAsync(1, 1f, onDestroyCancellationToken);
            await ChangeTextureAsync(2, 1f, onDestroyCancellationToken);
            await ChangeTextureAsync(3, 1f, onDestroyCancellationToken);
            await ChangeTextureAsync(4, 1f, onDestroyCancellationToken);

            await HideAsync(1f, onDestroyCancellationToken);
            var showTask = ShowAsync(1f, onDestroyCancellationToken);
            var moveTask1 = MoveAsync(new Vector2(0f, 3000f), 1f, onDestroyCancellationToken);
            await UniTask.WhenAll(showTask, moveTask1);
            var rotTask = RotateAsync(new Vector3(0f, 0f, 180f), 0.2f, onDestroyCancellationToken);
            var moveTask2 = MoveAsync(new Vector2(0f, -740f), 1f, onDestroyCancellationToken);
            await UniTask.WhenAll(rotTask, moveTask2);
        }
        catch (OperationCanceledException)
        {
            return;
        }
    }

    public async UniTask ChangeTextureAsync(int index, float duration, CancellationToken cancellationToken = default)
    {
        if (_sprites == null) return;
        if (_sprites.Length == 0) return;
        if (index < 0 || index >= _sprites.Length) return;

        var sprite = _sprites[index];
        _backImage.sprite = _foreImage.sprite;
        _foreImage.sprite = sprite;

        await _backImage.FadeAsync(1f, 0f, cancellationToken);
        await _foreImage.FadeAsync(0f, 0f, cancellationToken);

        await _foreImage.FadeAsync(1f, duration, cancellationToken);
        await _backImage.FadeAsync(0f, 0f, cancellationToken);
    }

    public async UniTask RotateAsync(Vector3 rot, float duration, CancellationToken cancellationToken = default)
    {
        await _actorRoot.RotateAsync(_actorRoot.rotation.eulerAngles, rot, duration, cancellationToken);
    }

    public async UniTask MoveAsync(Vector2 to, float duration, CancellationToken cancellationToken = default)
    {
        await _actorRoot.MoveAsync(_actorRoot.anchoredPosition, to, duration, cancellationToken);
    }

    public async UniTask ShowAsync(float duration, CancellationToken cancellationToken = default)
    {
        var col = _foreImage.color;
        await _foreImage.FadeAsync(1f, duration, cancellationToken);
    }

    public async UniTask HideAsync(float duration, CancellationToken cancellationToken = default)
    {
        var col = _foreImage.color;
        await _foreImage.FadeAsync(0f, duration, cancellationToken);
    }
}