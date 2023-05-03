using UnityEngine;

public class GravitySimulatorAffectedItem : MonoBehaviour
{
    private void Awake()
    {

        Rigidbody m_thisRigidbody = GetComponent<Rigidbody>();
        Utils.AddRigidbodyReference(m_thisRigidbody);
    }
    private void Start()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
    private void OnEnable()
    {
        EventsHolder.USE_GRAVITY += OnSelectedCustomWeapon;   
    }
    private void OnDisable()
    {
        EventsHolder.USE_GRAVITY -= OnSelectedCustomWeapon;
    }
    private void OnSelectedCustomWeapon(bool _newStatus)
    {
        GetComponent<Rigidbody>().useGravity = _newStatus;
    }

    private void ResetScene()
    {
        
    }
}
