using Cysharp.Threading.Tasks;
using Glib.NovelGameEditor;
using UnityEngine;

public class CameraAnimation : NovelAnimationBehavior
{
    [SerializeField]
    private Vector3 _endPosition;
    [SerializeField]
    private float _duration;
    [SerializeField]
    private Transform _lookAt;

    [SerializeField]
    public override async UniTask PlayAnimationAsync()
    {
        var cameraTransform = Camera.main.transform;
        var startPos = cameraTransform.position;
        var startRotation = cameraTransform.rotation;

        for (float t = 0f; t < _duration; t += Time.deltaTime)
        {
            cameraTransform.transform.position = Vector3.Lerp(startPos, _endPosition, t / _duration);

            var targetRotation = Quaternion.LookRotation(_lookAt.transform.position - cameraTransform.position);
            cameraTransform.rotation = Quaternion.Lerp(startRotation, targetRotation, t / _duration);
            await UniTask.Yield(this.GetCancellationTokenOnDestroy());
        }
        cameraTransform.transform.position = _endPosition;
        cameraTransform.transform.rotation = Quaternion.LookRotation(_lookAt.transform.position - cameraTransform.position);
    }
}