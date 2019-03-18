using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject winLabel;
    [SerializeField] private GameObject looseLabel;
    [SerializeField] private float timeToWin = 4f;
    
    private int _numberOfAttackers = 0;
    private bool _isLevelTimerFinished = false;
    private AudioSource _audioSource;
    private LevelLoader _levelLoader;
    

    private void Start()
    {
        winLabel.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
        _levelLoader = FindObjectOfType<LevelLoader>();
    }


    public void AttackerSpawned() => _numberOfAttackers++;

    public void AttackerKilled()
    {
        _numberOfAttackers--;

        if (_numberOfAttackers <= 0 && _isLevelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        _audioSource.Play();
        yield return new WaitForSeconds(timeToWin);
        _levelLoader.LoadNextScene();
        
    }

    public void LevelTimerFinished()
    {
        _isLevelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (var spawner in attackerSpawners)
        {
            spawner.StopSpawning();
        }
        
    }

}
