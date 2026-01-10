using DG.Tweening;
using UnityEngine;

public class RotateLoop : MonoBehaviour
{
    [SerializeField] private Vector3 euler = new Vector3(0f, 0f, -360f);
    [SerializeField] private float duration = 10f;

    private Tween t;

    void Awake()
    {
        t = transform.DOLocalRotate(euler, duration, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Restart);
        t.SetAutoKill(false);
    }

    void OnEnable()
    {
        t.Play();
    }

    void OnDisable()
    {
        t.Pause();
    }

    void OnDestroy()
    {
        t.Kill();
    }
}
