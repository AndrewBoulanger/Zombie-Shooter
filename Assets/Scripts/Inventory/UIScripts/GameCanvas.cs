using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : GameHUDWidget
{

    [SerializeField] TMPro.TextMeshProUGUI roundCount;
    [SerializeField] TMPro.TextMeshProUGUI enemiesCount;
    [SerializeField] EnemyManager enemyManager;

    private void Update()
    {
        enemiesCount.text = enemyManager.GetNumSlimes.ToString();
    }
    void OnRoundChanged(int round)
    {
        roundCount.text = round.ToString();
    }

    void OnEnemiesChanged(int numEnemies)
    {
        enemiesCount.text = numEnemies.ToString();
    }


    private void OnEnable()
    {
        EnemyManager.OnWaveCompleted += OnRoundChanged;
    }

    private void OnDisable()
    {
        EnemyManager.OnWaveCompleted -= OnRoundChanged;
    }

    public override void EnableWidget()
    {
        base.EnableWidget();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public override void DisableWidget()
    {
        base.DisableWidget();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
