using UnityEngine;
using System.Collections;
public class UnGravityBullet : CannonBallBase
{
    [SerializeField] private float speedReduction;
    private readonly WaitForSeconds wfs = new(.01f);
    public override void OnShooted(Vector3 _speed, Vector3 _initialPoint)
    {
        LocalRigidbody.position = _initialPoint;
        LocalRigidbody.velocity = _speed;
        StartCoroutine(OnSpecialSkillOneShot());
    }

    public IEnumerator OnSpecialSkillOneShot()
    {
        Vector3 m_newSpeed = Vector3.zero;
        float m_newXspeed = 0f;
        float m_newYSpeed = 0f;
        float m_newZSpeed = 0f;
        while (LocalRigidbody.velocity.magnitude > Mathf.Epsilon)
        {
            yield return wfs;
            m_newXspeed += LocalRigidbody.velocity.x - speedReduction;
            m_newYSpeed += LocalRigidbody.velocity.y - speedReduction;
            m_newZSpeed += LocalRigidbody.velocity.z - speedReduction;
            m_newSpeed.Set(m_newXspeed, m_newYSpeed, m_newZSpeed);
            LocalRigidbody.velocity = m_newSpeed;
        }
        LocalRigidbody.Sleep();
    }
}
