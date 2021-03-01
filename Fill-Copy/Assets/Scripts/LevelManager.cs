using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    LevelInfoAsset levelInfoAsset;
    public Transform TargetTransform;
    Vector3 PixelPosition = Vector3.zero;
    public int PixelCount;
    void Start()
    {
        LoadLevel(1);
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

    void Update()
    {

    }
}
