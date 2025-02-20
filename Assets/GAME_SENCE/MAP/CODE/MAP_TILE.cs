using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MAP_TILE : MonoBehaviour
{

    public MAP_Sezabile mAP_Sezabile;

    public Text Tieude;

    public List<Image> Anh_Nen;


    void Start()
    {
        Tieude.text = mAP_Sezabile.Map_name;
        foreach(Image image in Anh_Nen){
            image.sprite = mAP_Sezabile.Anh_Map;
        }
    }

   
}
