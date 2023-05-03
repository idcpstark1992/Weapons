using UnityEngine;

public class CannonBallItem : CannonBallBase
{
    public override void OnShooted(Vector3 _speed, Vector3 _initialPoint)
    {
        LocalRigidbody.position = _initialPoint;
        LocalRigidbody.velocity = _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out ISpecialSkill outhit))
        {
            outhit.OnHittedSkill();
        }
    }
}
