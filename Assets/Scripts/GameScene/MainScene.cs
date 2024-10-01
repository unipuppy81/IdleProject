using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    #region Fields

    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private Transform[] enemySpwanPoint;
    private bool isLoadCompleted = false;

    #endregion

    #region Unity Flow
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        Manager.Asset.LoadAllAsync((count, totalCount) =>
        {
            if(count >= totalCount)
            {
                isLoadCompleted = true;
            }
        });
    }

    #endregion

    #region ∞‘¿” æ¿

    public void SceneStart()
    {
        Manager.Game.PlayerInit(playerSpawnPoint.position);
    }

    private Transform BossSpawnPointAdd()
    {
        var spawnPointTransform = this.transform.Find("Enemy Spawn Point");
        var bossSpawnPoint = Instantiate(new GameObject("Boss Spawn Point"), spawnPointTransform.position, Quaternion.identity);
        bossSpawnPoint.transform.position = new Vector2(3.5f, 2.0f);
        bossSpawnPoint.transform.parent = spawnPointTransform;

        return bossSpawnPoint.transform;
    }
    #endregion
}
