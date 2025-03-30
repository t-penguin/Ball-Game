using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Vector2 _min;
    [SerializeField] private Vector2 _max;
    
    private Timer _spawnTimer;
    [SerializeField] private float _minTime;
    [SerializeField] private float _maxTime;

    private void Awake()
    {
        _spawnTimer = gameObject.AddComponent<Timer>();
        SetTimerDuration();
    }

    private void Start()
    {
        _spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_spawnTimer.Finished)
            return;

        SpawnBall();
        SetTimerDuration();
        _spawnTimer.Restart();
    }

    private void SpawnBall()
    {
        Vector2 pos;
        pos.x = Random.Range(_min.x, _max.x);
        pos.y = Random.Range(_min.y, _max.y);
        Instantiate(ball, pos, Quaternion.identity);
    }

    private void SetTimerDuration() => _spawnTimer.Duration = Random.Range(_minTime, _maxTime);
}