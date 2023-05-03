public static  class EventsHolder 
{
    public delegate void DELEGATE_ON_ANIMATION_SELECTION(float _animationIndex);
    public delegate void DELETATE_ON_TRIGGERED_WEAPON( UnityEngine.Vector3 _initialPoint);
    public delegate void DELEGATE_ON_SPECIAL_BULLET<T>(T _args);
    public delegate void DELEGATE_ON_SELECTED_WEAPON();
    public delegate void DELEGATE_ON_RESET_SCENE();
    public delegate void DELEGATE_ON_SCENE_CHANGED(int _args);

    public static DELEGATE_ON_ANIMATION_SELECTION   ON_ANIMATION_BUTTON_CLICKED;
    public static DELETATE_ON_TRIGGERED_WEAPON      ON_BULLET_FIRED;
    public static DELEGATE_ON_SPECIAL_BULLET<UnityEngine.Rigidbody> ON_GRAVITY_BULLET_EFFECTOR;
    public static DELEGATE_ON_SELECTED_WEAPON ON_SELECTED_WEAPON;
    public static DELEGATE_ON_SPECIAL_BULLET<bool>  USE_GRAVITY;
    public static DELEGATE_ON_SPECIAL_BULLET<bool>  ON_CUSTOM_WEAPON_MODE;
    public static DELEGATE_ON_RESET_SCENE RESET;
    public static DELEGATE_ON_SCENE_CHANGED ON_CHANGE_SCENE;
}
