using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Map_Set_Manager : Singleton<Map_Set_Manager>
{
    [Header("Nền")]
    public  List<GameObject> HinhNen;

    void Start()
    {
        // Set_Map(MAP_Data_GAME.Instance.All_Map[0]);
    }


    public void Set_Map(MAP_STAGE mAP_STAGE){
        // foreach(GameObject HinhNen1 in HinhNen){
        //     for (int i=0;i< HinhNen1.transform.childCount;i++){
        //         HinhNen1.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = mAP_STAGE.Anh_Nen[i];
        //     }
        // }
        // gameObject.transform.position.y = mAP_STAGE.Nen_OffSet;
        for (int j=0;j<HinhNen.Count;j++){
            for (int i=0;i< HinhNen[j].transform.childCount;i++){
                HinhNen[j].transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = mAP_STAGE.Anh_Nen[j];
            }
        }
   }
}
