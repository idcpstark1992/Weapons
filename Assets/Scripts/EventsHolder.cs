public static  class EventsHolder 
{
    public delegate void DELEGATE_ON_ANIMATION_SELECTION(float _animationIndex);
    public delegate void DELETATE_ON_TRIGGERED_WEAPON( UnityEngine.Vector3 _initialPoint);
    public static DELEGATE_ON_ANIMATION_SELECTION ON_ANIMATION_BUTTON_CLICKED;

    public static DELETATE_ON_TRIGGERED_WEAPON ON_BULLET_FIRED;
}
