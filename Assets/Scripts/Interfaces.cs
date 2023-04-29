public interface IOnRaycastHit
{
    void OnHittedRaycast();
}
public interface IOnShooted
{
     void OnShooted(UnityEngine.Vector3 _speed , UnityEngine.Vector3 _initialPoint);
}