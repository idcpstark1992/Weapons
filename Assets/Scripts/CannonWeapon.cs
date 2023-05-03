using UnityEngine;
using UniRx;
public abstract class CannonWeapon : MonoBehaviour ,ISelectableWeapon 
{
    [SerializeField] private Transform  TurretTransform;
    [SerializeField] protected Transform  FirePoint;
    [SerializeField] private float      timeToTravel;
    [SerializeField] private float      RotationSpeed;
    [SerializeField] private float      CannonBulletMass;
    private bool ActiveWeapon;
    private void Start()
    {
        var m_Observable = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.Space)).Subscribe(_ =>ShootABullet());
    }
    private void OnEnable()
    {
        EventsHolder.ON_SELECTED_WEAPON += OnChoosedWeapon;
    }
    private void OnDisable()
    {
        EventsHolder.ON_SELECTED_WEAPON -= OnChoosedWeapon;
    }
    private void OnChoosedWeapon()
    {
        ActiveWeapon = false;
    }
    void Update() => RotateTurret();
    private void RotateTurret()
    {
        Vector3 m_direction             = Utils.CrossHairPosition - TurretTransform.position;
        Vector3 m_perpDirection         = Vector3.Cross(m_direction, Vector3.up);
        Quaternion m_targetRotation     = Quaternion.LookRotation(m_direction, m_perpDirection);
        Quaternion m_overridedRotation  = new(0f, m_targetRotation.y, 0f, m_targetRotation.w);
        TurretTransform.rotation        = Quaternion.Slerp(TurretTransform.rotation, m_overridedRotation, RotationSpeed * Time.deltaTime);
    }
    protected  virtual void ShootABullet() 
    {
        if(ActiveWeapon)
            EventsHolder.ON_BULLET_FIRED?.Invoke(FirePoint.position);
    }

    public void OnSelected()
    {
        Debug.Log($"The active weapon is {gameObject.name}");
        Utils.SetInitialBulletsSpeed(timeToTravel);
        Utils.SetCannonBallMass(CannonBulletMass);
        ActiveWeapon = true;
    }
}
