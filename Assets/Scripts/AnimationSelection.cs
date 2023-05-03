using UnityEngine;

public class AnimationSelection : MonoBehaviour
{
    [SerializeField] private    Animator PlayerAnimator;
    private void OnEnable()     =>   EventsHolder.ON_ANIMATION_BUTTON_CLICKED += OnAnimationSelected;
    private void OnDisable()    =>  EventsHolder.ON_ANIMATION_BUTTON_CLICKED -= OnAnimationSelected;
    private void OnAnimationSelected(float _indexAnimation) 
    {
        PlayerAnimator.SetFloat("AnimationIndex", _indexAnimation);
        Utils.SetAnimationValue(_indexAnimation);
    }

}
