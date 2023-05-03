using UnityEngine;
public class CannonGravityBullet : MonoBehaviour, IOnShooted
{
    private Rigidbody LocalRigidbody;

    private void Start()
    {
        LocalRigidbody = GetComponent<Rigidbody>();
        DisableBullet();
    }
    private void OnEnable()=> EventsHolder.ON_SELECTED_WEAPON += DisableBullet;
    private void OnDisable()=> EventsHolder.ON_SELECTED_WEAPON -= DisableBullet;
    private void DisableBullet()
    {
        Utils.ChangeGravitationalBulletStatus(false);
        LocalRigidbody.Sleep();
        gameObject.transform.localScale = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (Utils.GravitationaBullet)
        {
            for (int i = 0; i < Utils.EffectorsReferences().Count; i++)
            {
                var m_object = Utils.EffectorsReferences()[i];
                Vector3 m_gravityDirection = (LocalRigidbody.position - m_object.position).normalized;
                float m_gravityMagnitude = Physics.gravity.magnitude * LocalRigidbody.mass * m_object.mass / (LocalRigidbody.position - m_object.position).sqrMagnitude;
                Vector3 m_gravity = m_gravityDirection * m_gravityMagnitude;
                m_object.AddForce(m_gravity);
                m_object.transform.LookAt(LocalRigidbody.transform);
                float m_distance = Vector3.Distance(LocalRigidbody.position, m_object.position);
                float m_orbitalVelocity = Mathf.Sqrt((Physics.gravity.magnitude * LocalRigidbody.mass) / m_distance);
                m_object.transform.RotateAround(LocalRigidbody.position, Vector3.up, m_orbitalVelocity * Time.deltaTime);
            }
        }
        
    }
    public  void OnShooted(Vector3 _speed, Vector3 _initialPoint)
    {
        gameObject.transform.localScale = Vector3.one;
        LocalRigidbody.WakeUp();
        Utils.ChangeGravitationalBulletStatus(true);
        LocalRigidbody.position = _initialPoint;
        LocalRigidbody.velocity = _speed;
    }
}
