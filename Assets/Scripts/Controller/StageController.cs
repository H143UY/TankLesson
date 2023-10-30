using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public WaveController waveController;
    private void Awake()
    {
        this.RegisterListener(EventID.EndWave, (sender, param) =>
        {
            waveController.BonusSpawn();
            waveController.SpawmEnemy();
        });
    }

    private void Start()
    {
        waveController.SpawmEnemy();
    }
}
