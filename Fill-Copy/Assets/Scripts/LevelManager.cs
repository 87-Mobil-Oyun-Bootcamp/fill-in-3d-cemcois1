using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance => instance;

    private static LevelManager instance;

    public List<FillableCube> fillableCubes = new List<FillableCube>();

    public List<MoveableCube> moveableCubes = new List<MoveableCube>();


    private int paintCounter;


    public System.Action LevelComplated;

    [SerializeField]
    LevelInfoAsset levelInfoAsset;
    [Space]
    [SerializeField]
    private Transform TargetTransform;
    Vector3 PixelPosition = Vector3.zero;
    public int PixelCount;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        LoadLevel(1);
        LevelComplated += DestroyAllMoveableCubes;
    }
    void DestroyAllMoveableCubes()
    {
        foreach (MoveableCube item in moveableCubes)
        {
            item.gameObject.SetActive(false);
        }

    }

    private void LoadLevel(int index)
    {
        var mySprite = levelInfoAsset.levelInfos[index - 1].sprite;
        var myBaseObject = levelInfoAsset.levelInfos[index - 1].baseObject;
        var boxsize = levelInfoAsset.levelInfos[index - 1].size;

        for (int x = 0; x < mySprite.texture.width; x++)
        {
            for (int y = 0; y < mySprite.texture.height; y++)
            {
                PixelPosition = new Vector3(TargetTransform.localPosition.x + x, TargetTransform.localPosition.y, TargetTransform.localPosition.y + y) * boxsize;
                var PixelColor = mySprite.texture.GetPixel(x, y);
                if (PixelColor.a == 0)
                {
                    continue;
                }
                PixelCount++;
                GameObject Pixel = Instantiate(myBaseObject, PixelPosition, Quaternion.identity, TargetTransform);

                Pixel.GetComponent<FillableCube>().SavingColor = PixelColor;
                Pixel.GetComponent<Renderer>().material.color = Color.white;
                Pixel.transform.localScale = Vector3.one * boxsize;
            }

        }
        print(PixelCount);
    }

    public void OnFillableCubeCreated(FillableCube fillableCube)
    {
        fillableCubes.Add(fillableCube);
        Debug.Log("Created FillableCubes  Count " + paintCounter);

    }
    public void OnMoveableCubeCreated(MoveableCube moveableCube)
    {
        moveableCubes.Add(moveableCube);
        Debug.Log("Created moveableCube  Count " + paintCounter);
    }
    public void OnBlockPainted()
    {

        paintCounter++;
        Debug.Log("Created FillableCubes  Count " + paintCounter + " Count" + fillableCubes.Count);
        if (fillableCubes.Count == paintCounter)
        {
            print("oyun bitti");
            LevelComplated?.Invoke();
        }
    }
}
