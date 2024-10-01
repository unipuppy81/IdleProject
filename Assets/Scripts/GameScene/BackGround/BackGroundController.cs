using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [Header("Background")]
    public int backgroundNum;
    public Sprite[] layer_Sprites;
    private GameObject[] layer_Object = new GameObject[6];
    private int max_backgroundNum = 19;


    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        for(int i = 0;i < layer_Object.Length;i++)
        {
            layer_Object[i] = GetComponent<ParallaxController>().Layer_Objects[i];
        }

        ChangeSprite();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) NextBG();
        if (Input.GetKeyDown(KeyCode.LeftArrow)) BackBG();
    }

    public void ChangeSprite()
    {
        //backgroundNum = Manager.Stage.Chapter % max_backgroundNum;
        layer_Object[0].GetComponent<SpriteRenderer>().sprite = layer_Sprites[backgroundNum * 6];
        for (int i = 1; i < layer_Object.Length; i++)
        {
            Sprite changeSprite = layer_Sprites[backgroundNum * 6 + i];
            layer_Object[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = changeSprite;
            layer_Object[i].transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = changeSprite;
        }
    }

    public void NextBG()
    {
        backgroundNum = backgroundNum + 1;
        if (backgroundNum > max_backgroundNum) backgroundNum = 0;
        ChangeSprite();
    }

    public void BackBG()
    {
        backgroundNum = backgroundNum - 1;
        if (backgroundNum < 0) backgroundNum = max_backgroundNum;
        ChangeSprite();
    }
}
