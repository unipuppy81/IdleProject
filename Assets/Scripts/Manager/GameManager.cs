using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Properties

    public Player Player { get; private set; }
    public MainScene Main { get; private set; }

    public float screenRatio { get; private set; } = Screen.height / Screen.width * 0.1f;

    #endregion

    #region Init

    /// <summary>
    /// 데이터 동기화 후 => 게임 세팅
    /// </summary>
    public void Initialize()
    {
        var playerClone = Manager.Asset.InstantiatePrefab("PlayerFrame");
        Player = playerClone.GetComponent<Player>();

        Main = GameObject.FindObjectOfType<MainScene>();
        Main.SceneStart();

    }

    public void PlayerInit(Vector2 position)
    {
        Vector2 positionRatio = new Vector2(screenRatio, -screenRatio);
        Vector2 scaleRatio = new Vector2(screenRatio, screenRatio);

        Player.transform.position = position + positionRatio;
        Player.transform.localScale = Vector2.one - scaleRatio;
        Player.Initialize();
    }
    #endregion

}
