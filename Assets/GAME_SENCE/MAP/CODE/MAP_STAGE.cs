using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class MAP_STAGE 
{


    public int STAGE_ID ;

    [Header("Ảnh Nền")]
    public float Nen_OffSet;
    

    [SerializeField] 
    private List<Sprite> Anh_Nen1 = new List<Sprite>(new Sprite[5]);
    public List<Sprite> Anh_Nen =>  Anh_Nen1;


    


    public void Set_ID(List<MAP_STAGE> mAP_STAGEs){
        if (STAGE_ID != 0){  
            return;
        }
        // this.STAGE_ID = mAP_STAGEs.IndexOf(this);
        // KiemTra_NeuTrung(mAP_STAGEs);'
        KiemTra_NeuTrung(mAP_STAGEs);
    }
  

    // public void KiemTra_NeuTrung(List<MAP_STAGE> mAP_STAGEs){
    //     bool trung = false;
    //     foreach (MAP_STAGE mAP_STAGE in mAP_STAGEs){
    //         if (mAP_STAGE.STAGE_ID == this.STAGE_ID){
    //             trung = true;
    //         }
    //     }
    //     if (trung == false ){return;}

    //     int SoLon = 0;
    //     foreach (MAP_STAGE mAP_STAGE in mAP_STAGEs){
    //         if (mAP_STAGE.STAGE_ID > SoLon){
    //            SoLon = mAP_STAGE.STAGE_ID;
    //         }
    //     }
    //     this.STAGE_ID = SoLon+1;


    // }


    public void KiemTra_NeuTrung(List<MAP_STAGE> mAP_STAGEs)
    {
   
        HashSet<int> usedIDs = new HashSet<int>(mAP_STAGEs.Select(m => m.STAGE_ID)); // Tập hợp ID đã có
        if (!usedIDs.Contains(STAGE_ID)) return; // Nếu không trùng thì thoát
        // Tìm số lớn nhất trong danh sách ID và tăng thêm 1
        this.STAGE_ID = usedIDs.Max() + 1;
    }

    public void KhoiTao()
    {
        if (Anh_Nen1 == null || Anh_Nen1.Count == 0 ||  Anh_Nen1.Count != 5) 
        {   

            Anh_Nen1 = new List<Sprite> { null, null, null, null, null };

        }
       
    }
}
