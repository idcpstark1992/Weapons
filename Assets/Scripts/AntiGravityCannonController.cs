using UnityEngine;
using UniRx;
public class AntiGravityCannonController : MonoBehaviour, ISelectableWeapon
{
    [SerializeField] private Transform FirePoint;
    [SerializeField] private CannonGravityBullet GravitalBulletPrefab;
    private bool ActiveWeapon;

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
    private void Start()
    {
        var m_Observable = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.Space)).Subscribe(_ => ShootABullet());
    }
    protected  void ShootABullet()
    {
        if(ActiveWeapon)
            GravitalBulletPrefab.OnShooted(Vector3.up, FirePoint.position);
    }

    public void OnSelected()
    {
        Debug.Log($"The active weapon is {gameObject.name}");
        ActiveWeapon = true;
    }
}
