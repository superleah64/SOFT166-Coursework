using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EnemySpawnedEvent : UnityEvent<Transform> { }

public class Enemy : MonoBehaviour
{
    public EnemySpawnedEvent onSpawn;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        onSpawn.Invoke(player.transform);
    }

    public void OnDie()
    {
        transform.parent.SendMessage("OnEnemyKilled");
    }
}
