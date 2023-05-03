using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransitionsManager : MonoBehaviour
{
    private void Start()
    {
        EventsHolder.ON_CHANGE_SCENE += ChangeScene;
    }
    private void OnDisable()
    {
        EventsHolder.ON_CHANGE_SCENE -= ChangeScene;
    }
    public void ChangeScene (int _index)
    {
        SceneManager.LoadSceneAsync(_index, LoadSceneMode.Additive);
    }
    public void ResetTheScene(int _index)
    {
        SceneManager.LoadScene(_index);
    }

}
public class UIChangeScene : MonoBehaviour
{
    [SerializeField] private int NewSceneIndex;
    private UnityEngine.UI.Button ButtonReference;
    private void Start()
    {
        ButtonReference.onClick.AddListener(OnChangedScene);
    }
    private void OnChangedScene()
    {
        EventsHolder.ON_CHANGE_SCENE?.Invoke(NewSceneIndex);
    }

}
