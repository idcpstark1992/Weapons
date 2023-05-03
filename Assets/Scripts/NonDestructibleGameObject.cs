using UnityEngine;

public class NonDestructibleGameObject : MonoBehaviour
{
    void Start() => DontDestroyOnLoad(this);
}
