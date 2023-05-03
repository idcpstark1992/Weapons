using UnityEngine;

public class AddReferencesToMemory : MonoBehaviour
{
    [SerializeField] private Camera MainCameraRerefence;

    private void Awake()=> Utils.SetMainCameraReference(MainCameraRerefence);
}
