using UnityEngine;

public abstract class CannonBallBase : MonoBehaviour, IOnShooted
{
    protected Rigidbody LocalRigidbody;
    private Vector3 InitialPosition;
    private Quaternion InitialRotation;
    private void Awake()
    {
        LocalRigidbody = GetComponent<Rigidbody>();
        LocalRigidbody.mass = Utils.CannonBulletMass;
        InitialRotation = LocalRigidbody.rotation;
        InitialPosition = Vector3.up * 2;
    }
    private void Start()
    {
        InitialPosition = LocalRigidbody.position;
    }
    private void Update()
    {
    
        if (LocalRigidbody.position.y <= -23)
            RestartPosition();
    }
    private void RestartPosition()
    {
        LocalRigidbody.Sleep();
        LocalRigidbody.rotation = InitialRotation;
        LocalRigidbody.transform.position = InitialPosition;
        LocalRigidbody.WakeUp();
    }
    public virtual void OnShooted(Vector3 _speed, Vector3 _initialPoint)
    {
        
        throw new System.NotImplementedException();
    }
}
