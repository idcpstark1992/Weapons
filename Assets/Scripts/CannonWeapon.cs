using UnityEngine;
using UniRx;
public class CannonWeapon : MonoBehaviour
{
    [SerializeField] private Transform  TurretTransform;
    [SerializeField] private Transform  FirePoint;
    [SerializeField] private float      timeToTravel;
    [SerializeField] private float      RotationSpeed;
    [SerializeField] private float      CannonBulletMass;
    private void Start()
    {
        Utils.SetInitialBulletsSpeed(timeToTravel);
        Utils.SetCannonBallMass(CannonBulletMass);
        var m_Observable = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.Space)).Subscribe(x =>ShootABullet());
    }
    void Update() => RotateTurret();
    private void RotateTurret()
    {
        Vector3 m_direction = Utils.CrossHairPosition - TurretTransform.position;
        Vector3 m_perpDirection = Vector3.Cross(m_direction, Vector3.up);
        Quaternion m_targetRotation = Quaternion.LookRotation(m_direction, m_perpDirection);
        Quaternion m_overridedRotation = new(0f, m_targetRotation.y, 0f, m_targetRotation.w);
        TurretTransform.rotation = Quaternion.Slerp(TurretTransform.rotation, m_overridedRotation, RotationSpeed * Time.deltaTime);
    }
    private void ShootABullet()
    {
        EventsHolder.ON_BULLET_FIRED?.Invoke(FirePoint.position);
    }
}
