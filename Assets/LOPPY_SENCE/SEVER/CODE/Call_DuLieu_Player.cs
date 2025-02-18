using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Extensions;
using Firebase.Firestore;
using Unity.VisualScripting;
using UnityEngine;


public class Call_DuLieu_Player : Singleton<Call_DuLieu_Player>
{
    



    [Header("Fire_Base")]
    private FirebaseUser user;
    private FirebaseFirestore db;
     FirebaseAuth auth;

    public void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        db = FirebaseFirestore.DefaultInstance;
        user = auth.CurrentUser; 
        // Tao_Thongso_Va_TienTrinh(user.UserId);
    }


    public Thong_Tin_CoBan Call_ThonTing_NguoiChoi(){
        //  FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        return new Thong_Tin_CoBan(user.DisplayName,user.Email);
    }

    // public async Task Tao_Thongso_Va_TienTrinh(string user_id){
    //     FirebaseFirestore db = FirebaseFirestore.DefaultInstance;


    //     // Truy cập đến document của người chơi trong collection "Tien_Ruby_Mau_Mana_Capdo"
    //     DocumentReference Coli_ThongSo = db.Collection("ThongSo").Document(user_id);
    //     // Lấy dữ liệu người chơi từ Firestore
    //     DocumentSnapshot documentSnapshot = await Coli_ThongSo.GetSnapshotAsync();
    //     if (!documentSnapshot.Exists){
    //         Thongso thongso = new Thongso{
    //             Tien = 60,
    //             Ruby = 0,
    //             Diem_Mau = 0,
    //             DiemMana = 0,
    //             Capdo = 0,
    //             Diem_KinhNghiem = 0
    //         };
    //         await Coli_ThongSo.SetAsync(thongso);// Lưu đối tượng mới vào Firestore
    //     }



    //     DocumentReference Coli_TienTrinh = db.Collection("TienTrinh").Document(user_id);
    //     DocumentSnapshot wait_TienTrinh = await Coli_TienTrinh.GetSnapshotAsync();
    //     if (!wait_TienTrinh.Exists)
    //     {   
    //         Debug.Log("Chưa có tiến trình, tạo mới...");
    //         TienTrinh newProgress = new TienTrinh
    //         {
    //             Map_Win = new List<int>(),
    //             Skill_Id = 0
    //         };
    //         await Coli_TienTrinh.SetAsync(newProgress);
    //     }

    // }

  
}