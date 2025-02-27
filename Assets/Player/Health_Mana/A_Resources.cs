using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class A_Resources :MonoBehaviour 
{
    public float Toi_Da;
    public float Toi_Thieu;
    public float Hien_Tai;
    public float So_Luong_Cong;
    public float Thoi_Gian_Cong;
    private float thoigian;


    public void Tang_Dan(){
        if (Hien_Tai<Toi_Da){
            if (Time.time-thoigian>Thoi_Gian_Cong){
                thoigian = Time.time;
                Them(So_Luong_Cong);
            }
        }
    }

    public void Them(float SoLuong){
        if (Hien_Tai+SoLuong>=Toi_Da){
            Hien_Tai = Toi_Da;
            Dat_Moc();
        }else{
            Hien_Tai += SoLuong;
        }
        DangCong();

    }

    public void Giam(float SoLuong){
         if (Hien_Tai-SoLuong<=Toi_Thieu){
            Hien_Tai = Toi_Thieu;
            Het();
        }else{
            Hien_Tai -= SoLuong;
     
        }
        DangTru();
    }




    public abstract void Het();
    public abstract void Dat_Moc();

    public abstract void DangCong();
    public abstract void DangTru();
    

}
