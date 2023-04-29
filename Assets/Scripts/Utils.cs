using UnityEngine;
public static class Utils
{
    private static Camera MainCameraReference;
    public static float AnimationValue { get; private set; }
    public static void SetAnimationValue(float _animationValue) => AnimationValue = _animationValue;

    public static void SetMainCameraReference(Camera _mainCameraRefrence)
    {
        MainCameraReference = _mainCameraRefrence;
    }
    public static Ray GetRayPointFromCenter(Vector2 _screenCoordinates)=> MainCameraReference.ScreenPointToRay(_screenCoordinates/2f);
}