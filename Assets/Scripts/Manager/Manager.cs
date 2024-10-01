using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    #region �̱���

    private static Manager _instance;
    private static bool initialized;
    public static Manager instance
    {
        get
        {
            if (!initialized)
            {
                initialized = true;

                GameObject obj = GameObject.Find("@Manager");
                if (obj == null)
                {
                    obj = new() { name = "@Manager" };
                    obj.AddComponent<Manager>();
                    DontDestroyOnLoad(obj);
                    _instance = obj.GetComponent<Manager>();
                }
            }
            return _instance;
        }
    }

    #endregion

    #region Manage
    private readonly AssetManager asset = new();
    private readonly GameManager game = new();





    public static AssetManager Asset => instance != null ? instance.asset : null;

    public static GameManager Game => instance != null ? instance.game : null;
    #endregion
}
