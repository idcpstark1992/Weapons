using UnityEngine;

public class CannonBallsPool : MonoBehaviour
{
    [SerializeField] private GameObject     CannonBall;
    [SerializeField] private IOnShooted[]   CannonBalls;
    [SerializeField] private int CannonBallsAmount;
    private int CurrentCannonBallCounter;
    private void OnEnable()     => EventsHolder.ON_BULLET_FIRED += OnShootedBulled;
    private void OnDisable()    => EventsHolder.ON_BULLET_FIRED -= OnShootedBulled;
    private void Start()
    {
        CannonBalls = new IOnShooted[CannonBallsAmount];
        GenerateCannonBallPool();
    }
    private void GenerateCannonBallPool()
    {
        for (int i = 0; i < CannonBallsAmount; i++)
        {
            IOnShooted m_toAddPool = Instantiate(CannonBall).GetComponent<IOnShooted>();
            CannonBalls[i] = m_toAddPool;
        }
    }
    private void OnShootedBulled( Vector3 _initialPosition)
    {
        Vector3 m_ShootDirection = Utils.GetCannonBallTrayectory(_initialPosition);
        CannonBalls[CurrentCannonBallCounter].OnShooted(m_ShootDirection,_initialPosition);


        CurrentCannonBallCounter++;
        if (CurrentCannonBallCounter >= CannonBallsAmount)
            CurrentCannonBallCounter = 0;
    }
}
