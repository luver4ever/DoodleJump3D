using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Platform : MonoBehaviour
{
    [SerializeField] private float _bouncness = 10f;

    private Collider _collider;

    public float Bouncness => _bouncness;

    private void OnValidate()
    {
        if (_bouncness < 0)
            _bouncness = 0;
    }

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    public void SetTouchable()
    {
        _collider.enabled = true;
    }
}
