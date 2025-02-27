using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MAP_TILE : MonoBehaviour
{

    public MAP_Sezabile mAP_Sezabile;

    public Text Tieude;

    public List<Image> Anh_Nen;

    public GameObject Da_Lock;
    public GameObject Da_Win;
    public List<GameObject> SoSao;


    void Start()
    {
        New();
    }

    public void New()
    {
        Tieude.text = mAP_Sezabile.Map_name;
        foreach(Image image in Anh_Nen){
            image.sprite = mAP_Sezabile.Anh_Map;
        }

        Da_Win.SetActive(mAP_Sezabile.Is_Win);
        Da_Lock.SetActive(mAP_Sezabile.Is_UnLock);



        for (int i = 0; i<=SoSao.Count-1;i++){
            if (i<=mAP_Sezabile.Num_Rank-1){
                SoSao[i].SetActive(true);
            }else{
                 SoSao[i].SetActive(false);
            }
      
        };
       





    }


}
