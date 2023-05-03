
public interface IOnShooted
{
     abstract void  OnShooted(UnityEngine.Vector3 _speed , UnityEngine.Vector3 _initialPoint);
}
public interface ISpecialSkill
{
    abstract void OnHittedSkill();
}
public interface ISelectableWeapon
{
    abstract void OnSelected();
}