using UnityEngine;

public class UIChangeScene : MonoBehaviour
{
    [SerializeField] private int    NewSceneIndex;
    private UnityEngine.UI.Button   ButtonReference;
    private void Awake()            => ButtonReference = GetComponent<UnityEngine.UI.Button>();
    private void Start()            => ButtonReference.onClick.AddListener(OnChangedScene);
    private void OnChangedScene()   => EventsHolder.ON_CHANGE_SCENE?.Invoke(NewSceneIndex);

}
