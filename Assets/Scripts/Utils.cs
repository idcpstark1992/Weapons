using UnityEngine;
using System.Collections.Generic;
public static class Utils
{
    private static List<Rigidbody> AffectedItemsList = new List<Rigidbody>();
    private static Camera MainCameraReference;
    public static float     AnimationValue                  { get; private set; }
    public static Vector3   CrossHairPosition               { get; private set; }
    public static float     CannonBulletInitialSpeed        { get; private set; }
    public static float     CannonBulletMass                { get; private set; }
    public static bool      GravitationaBullet              { get; private set; }
    public static bool      CustomBulletMode                { get; private set; }
    public static void      SetAnimationValue(float _animationValue)             => AnimationValue = _animationValue;
    public static void      SetMainCameraReference(Camera _mainCameraRefrence)   => MainCameraReference = _mainCameraRefrence;
    public static Ray       GetRayPointFromCenter(Vector2 _screenCoordinates)     => MainCameraReference.ScreenPointToRay(_screenCoordinates/2f);
    public static void      SetCrossHairPosition(Vector3 _crossHairPosition)     => CrossHairPosition = _crossHairPosition;
    public static void      SetInitialBulletsSpeed(float _initialSpeedValues)    => CannonBulletInitialSpeed = _initialSpeedValues;
    public static void      SetCannonBallMass(float _mass)                       => CannonBulletMass = _mass;
    public static Vector3   GetCannonBallTrayectory(Vector3 _spawnPointPosition)
    {
        Vector3 m_displacement = CrossHairPosition - _spawnPointPosition;
        float   m_distance = m_displacement.magnitude;
        Vector3 m_direction = m_displacement.normalized;
        float   m_initialSpeed = m_distance / CannonBulletInitialSpeed;
        return m_direction * m_initialSpeed;
    }
    public static void      AddRigidbodyReference(Rigidbody _args)
    {
        if (!AffectedItemsList.Contains(_args))
            AffectedItemsList.Add(_args);
    }
    public static List<Rigidbody> EffectorsReferences ()                         => AffectedItemsList;
    public static void      ChangeGravitationalBulletStatus(bool _newStatus)     => GravitationaBullet = _newStatus;
    public static void      SetCustomWeaponMode (bool _newStatus)                => CustomBulletMode = _newStatus;

}