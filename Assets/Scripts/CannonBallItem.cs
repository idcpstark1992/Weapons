using UnityEngine;

public class CannonBallItem : MonoBehaviour, IOnShooted
{
    private Rigidbody LocalRigidbody;
    private Vector3 InitialPosition;
    [SerializeField] private int BulletDuration;
    private void Awake()
    {
        LocalRigidbody = GetComponent<Rigidbody>();
        LocalRigidbody.mass = Utils.CannonBulletMass;
    }
    private void Start()
    {
        InitialPosition = LocalRigidbody.position;
    }

    private void Update()
    {
        if (LocalRigidbody.position.y < -25)
            RestartPosition();
    }
    private void RestartPosition()
    {
        LocalRigidbody.position = InitialPosition;
    }
    public void OnShooted(Vector3 _speed, Vector3 _initialPoint)
    {
        LocalRigidbody.position = _initialPoint;
        LocalRigidbody.velocity = _speed;
    }
}
