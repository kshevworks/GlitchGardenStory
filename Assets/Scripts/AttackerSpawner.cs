using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [SerializeField] private Attacker[] attackerPrefabs;


    private float _countedMinSpawnDelay;
    private float _countedMaxSpawnDelay;

    private bool _spawn = true;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        _countedMinSpawnDelay = minSpawnDelay * 2 / PlayerPrefsController.DifficultyLevel;
        _countedMaxSpawnDelay = maxSpawnDelay * 2 / PlayerPrefsController.DifficultyLevel;
        while (_spawn)
        {
            yield return new WaitForSeconds(Random.Range(_countedMinSpawnDelay, _countedMaxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        _spawn = false;
    }

    private void SpawnAttacker()
    {
        if(attackerPrefabs.Length==0) return;
        
        var attackerIndex = Random.Range(0, attackerPrefabs.Length);
        Spawn(attackerPrefabs[attackerIndex]);

    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, transform.rotation);
        newAttacker.transform.parent = transform;
    }
}
