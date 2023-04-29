using UnityEngine;
using UnityEngine.UI;

public class UIAnimationSelectionButton : MonoBehaviour
{
    [SerializeField] private float IndexAnimation;
    private Button LocalButtonReference;
    private void Awake()
    {
        LocalButtonReference = GetComponent<Button>();
        LocalButtonReference.onClick.AddListener(OnButtonClicked);
    }
    private void OnButtonClicked()=> EventsHolder.ON_ANIMATION_BUTTON_CLICKED?.Invoke(IndexAnimation);

}
