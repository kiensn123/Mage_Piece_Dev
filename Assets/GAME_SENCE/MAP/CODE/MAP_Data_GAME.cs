    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MAP_Data_GAME : Singleton<MAP_Data_GAME>
    {
    public List<MAP_STAGE> All_Map;

        void OnValidate()
        {
            if (All_Map.Count<=0){return;}

            foreach (MAP_STAGE mAP_STAGE in All_Map){
                mAP_STAGE?.KhoiTao();
                mAP_STAGE?.Set_ID(All_Map);//lấy thứ tự của map rồi truyền vào
            }
        }
    }
