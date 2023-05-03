using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransitionsManager : MonoBehaviour
{
    private static SceneTransitionsManager Instance = null;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(Instance);
    }
    private void Start()                    => EventsHolder.ON_CHANGE_SCENE += ChangeScene;
    private void OnDisable()                => EventsHolder.ON_CHANGE_SCENE -= ChangeScene;
    public void ChangeScene (int _index)    => SceneManager.LoadSceneAsync(_index, LoadSceneMode.Additive);
    public void ResetTheScene(int _index)   => SceneManager.LoadScene(_index);

}
