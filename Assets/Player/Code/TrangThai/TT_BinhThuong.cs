using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TT_BinhThuong : A_TrangThai
{
    private Mau mau;
    public  void BatDau_TrangThai(TrangThai_Manager trangThai_Manager)
    {
        trangThai_Manager.HienThi_TrangThai = "BinhThuong";
        mau = trangThai_Manager.gameObject.GetComponent<Mau>();
        trangThai_Manager.gameObject.GetComponent<Move_Manager>().diChuyenCoBan.DuocDiChuyen = true;
        trangThai_Manager.gameObject.GetComponent<Move_Manager>().luot.DuocLuot = true;
        trangThai_Manager.gameObject.GetComponent<Move_Manager>().nhay.DuocNhay = true;
    }

    public  void CapNhat_TrangThai(TrangThai_Manager trangThai_Manager)
    {
       if (mau.Hien_Tai<0.1){
            trangThai_Manager.ThayDoi_TrangThai(trangThai_Manager.tT_Chet);
       }else{
           trangThai_Manager.ThayDoi_TrangThai(trangThai_Manager.tT_BinhThuong);
       }
    }

    public  void Ketthuc_TrangThai(TrangThai_Manager trangThai_Manager)
    {
       
    }
}
