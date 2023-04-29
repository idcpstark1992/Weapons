using UnityEngine;

public class CrossHairRayCast : MonoBehaviour
{
    [SerializeField] private Transform TurretTransform;
    [SerializeField] private Transform CrosshairReference;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private LayerMask LayertoDetect;
    [SerializeField] private float RaycastLenght;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private GameObject CannonBall;
    public float timeToTravel;
    private Vector2 ScreenReferences;




    
    private void Start()=> ScreenReferences = new Vector2(Screen.width, Screen.height);
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Utils.GetRayPointFromCenter(ScreenReferences), out RaycastHit hit, RaycastLenght, LayertoDetect))
        {
            CrosshairReference.position = hit.point;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootABullet();
        }
        Vector3 m_direction = CrosshairReference.position - TurretTransform.position;
        Vector3 m_perpDirection = Vector3.Cross(m_direction, Vector3.up);
        Quaternion m_targetRotation = Quaternion.LookRotation(m_direction, m_perpDirection);
        Quaternion m_overridedRotation = new(0f, m_targetRotation.y, 0f, m_targetRotation.w);
        TurretTransform.rotation = Quaternion.Slerp(TurretTransform.rotation, m_overridedRotation, RotationSpeed * Time.deltaTime);
    }
    private void ShootABullet()
    {
        Vector3 displacement = CrosshairReference.position - TurretTransform.position;
        float distance = displacement.magnitude;
        Vector3 direction = displacement.normalized;
        float initialSpeed = distance / timeToTravel;

    

        GameObject m_ToInstantiate = Instantiate(CannonBall);
        m_ToInstantiate.transform.position = FirePoint.position;
        m_ToInstantiate.gameObject.GetComponent<Rigidbody>().velocity = direction * initialSpeed;
    }
}