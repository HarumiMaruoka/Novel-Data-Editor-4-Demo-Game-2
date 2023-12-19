using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public static class ImageExtensions
{
    public static async UniTask FadeAsync(this Image image, Color from, Color to, float duration, CancellationToken cancellationToken = default)
    {
        for (var t = 0f; t < duration; t += Time.deltaTime)
        {
            image.color = Color.Lerp(from, to, t / duration);
            await UniTask.Yield(cancellationToken);
        }
        image.color = to;
    }

    public static async UniTask FadeAsync(this Image image, float to, float duration, CancellationToken cancellationToken = default)
    {
        var col = image.color;
        var fromCol = col;
        col.a = to;
        var toCol = col;

        for (var t = 0f; t < duration; t += Time.deltaTime)
        {
            image.color = Color.Lerp(fromCol, toCol, t / duration);
            await UniTask.Yield(cancellationToken);
        }
        image.color = toCol;
    }

    public static async UniTask MoveAsync(this RectTransform transform, Vector2 from, Vector2 to, float duration, CancellationToken cancellationToken = default)
    {
        for (var t = 0f; t < duration; t += Time.deltaTime)
        {
            transform.anchoredPosition = Vector3.Lerp(from, to, t / duration);
            await UniTask.Yield(cancellationToken);
        }
        transform.anchoredPosition = to;
    }

    public static async UniTask RotateAsync(this RectTransform transform, Vector3 from, Vector3 to, float duration, CancellationToken cancellationToken = default)
    {
        var fromRot = Quaternion.Euler(from);
        var toRot = Quaternion.Euler(to);

        for (var t = 0f; t < duration; t += Time.deltaTime)
        {
            transform.rotation = Quaternion.Lerp(fromRot, toRot, t / duration);
            await UniTask.Yield(cancellationToken);
        }
        transform.rotation = toRot;
    }
}