using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Firebase.Auth;
using Firebase.Extensions;
using Firebase.Firestore;
using UnityEngine;
using UnityEngine.UI;

public class Dang_Ki : MonoBehaviour, Form_InterFace
{

    [Header("Form")]
    public InputField Ten_Nguoi_Choi;

    public InputField Gmail;
    public InputField Mat_Khau;
    public InputField Nhap_Lai_Mat_Khau;

    [Header("Buuton")]
    public Button Dang_Ki_But;

    [Header("Game_OBj")]

    public GameObject DangNhap_OBJ;

    [Header("Custom")]
    private FirebaseAuth firebaseAuth;


    private void Start() {
        firebaseAuth = FirebaseAuth.DefaultInstance;    
        Dang_Ki_But.onClick.AddListener(Gui_DuLieu_Sever);
    }

    public  void Gui_DuLieu_Sever()
    {

        if (!Ckeck_DieuKien()){return;}
        
        string email = Gmail.text;
        string password = Mat_Khau.text;
        string ussername = Ten_Nguoi_Choi.text;
        firebaseAuth.CreateUserWithEmailAndPasswordAsync(email,password).ContinueWithOnMainThread(task=>{
            if (task.IsCanceled || task.IsFaulted){
                Debug.LogError("Đang Kí Bị Lỗi");
                return;
            }
            FirebaseUser user = task.Result.User;
            UserProfile profile = new UserProfile
            {
                DisplayName = Ten_Nguoi_Choi.text
            };

            user.UpdateUserProfileAsync(profile).ContinueWithOnMainThread(updateTask =>
            {
                if (updateTask.IsCompleted)
                {
                    Debug.Log("Cập nhật tên người chơi thành công: " + user.DisplayName);

              
                    DangNhap_OBJ.SetActive(false);

                }
                else
                {
                    Debug.LogError("Lỗi khi cập nhật tên người chơi.");
                }
            });
        });


    }


    
    public void Reset_Plahor(){
        Gmail.text= "";
        Ten_Nguoi_Choi.text ="";
        Mat_Khau.text ="";
        Nhap_Lai_Mat_Khau.text ="";
    }

    public void Nhan_DuLieu_Server()
    {
        // FirebaseFirestore firebaseFirestore = FirebaseFirestore.DefaultInstance;
        // string userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId; // Lấy ID của người dùng hiện tại

        // firebaseFirestore.Collection("DL_CoBan").Document(userId).GetSnapshotAsync().ContinueWithOnMainThread(task =>
        // {
        //     if (task.IsCompleted)
        //     {
        //         DocumentSnapshot snapshot = task.Result;
        //         if (snapshot.Exists)
        //         {
        //             // Lấy dữ liệu từ document
        //             Dictionary<string, object> data = snapshot.ToDictionary();
        //             int nangLuong = data.ContainsKey("Nang_Luong") ? System.Convert.ToInt32(data["Nang_Luong"]) : 0;
        //             int mau = data.ContainsKey("Mau") ? System.Convert.ToInt32(data["Mau"]) : 0;
        //             int tien = data.ContainsKey("Tien") ? System.Convert.ToInt32(data["Tien"]) : 0;

        //             Debug.Log($"Năng Lượng: {nangLuong}, Máu: {mau}, Tiền: {tien}");
        //         }
        //         else
        //         {
        //             Debug.LogWarning("Không tìm thấy dữ liệu người chơi!");
        //         }
        //     }
        //     else
        //     {
        //         Debug.LogError("Lỗi khi lấy dữ liệu từ Firestore!");
        //     }
        // });
}

    public bool Ckeck_DieuKien()
    {
        if (string.IsNullOrWhiteSpace(Ten_Nguoi_Choi.text))
        {
            Debug.Log( "Tên người chơi không được để trống!");
            return false;
        }

        if (string.IsNullOrWhiteSpace(Gmail.text))
        {
            Debug.Log("Gmail không được trống");
            return false;
        }

        if (Mat_Khau.text.Length < 6)
        {
            Debug.Log("Mật khẩu phải có ít nhất 6 ký tự!");
            return false;
        }

        if (Mat_Khau.text != Nhap_Lai_Mat_Khau.text)
        {
            Debug.Log("Mật khẩu nhập lại không khớp!");
            return false;
        }

        
        return true;
    }

    public void Nhan_DuLieu_Sever()
    {
       
    }

   
}
