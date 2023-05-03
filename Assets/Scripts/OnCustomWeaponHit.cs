using UnityEngine;

public class OnCustomWeaponHit : MonoBehaviour, ISpecialSkill
{
    private bool Active;
    [SerializeField] private Transform ObjectTransform;
    [SerializeField] private Vector3 OffsetTransform;
    [SerializeField] private float MaxRadious;
    Vector3 m_newPosition;
    private void OnEnable()     => EventsHolder.ON_CUSTOM_WEAPON_MODE += SetCustomMode;
    private void OnDisable()    => EventsHolder.ON_CUSTOM_WEAPON_MODE -= SetCustomMode;
    private void SetCustomMode (bool _mode) => Active = _mode;
    private void Start()
    {
        ObjectTransform = GetComponent<Transform>();
        OffsetTransform = gameObject.transform.localPosition;
        m_newPosition = Vector3.zero;
    }
    void Update()
    {
        if (Active && Utils.CustomBulletMode)
        {
            Vector3 m_RandomPosition = Random.insideUnitSphere * MaxRadious;
            m_newPosition.x = m_RandomPosition.x + OffsetTransform.x;
            m_newPosition.y = m_RandomPosition.y + OffsetTransform.y;
            m_newPosition.z = m_RandomPosition.z + OffsetTransform.z;
            ObjectTransform.localPosition = m_newPosition;
        }
    }
    public void OnHittedSkill()
    {
        if (Utils.CustomBulletMode)
        {
            Active = true;
            GetComponent<Rigidbody>().useGravity = false;
        }
    }
}