using UnityEngine;

public class CrossHairRayCast : MonoBehaviour
{
    [SerializeField] private LayerMask LayertoDetect;
    [SerializeField] private float RaycastLenght;
    public float timeToTravel;
    private Vector2 ScreenReferences;
    
    private void Start()=> ScreenReferences = new Vector2(Screen.width, Screen.height);
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Utils.GetRayPointFromCenter(ScreenReferences), out RaycastHit hit, RaycastLenght, LayertoDetect))
            Utils.SetCrossHairPosition(hit.point);
    }
}