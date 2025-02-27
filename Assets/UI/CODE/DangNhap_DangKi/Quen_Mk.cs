using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class Quen_Mk : MonoBehaviour, Form_InterFace
{
    [Header("Form")]
    public InputField Gmail;

    [Header("Buuton")]
    public Button DoiMk;

    [Header("OBJ")]
    public GameObject OutNhom;

    [Header("FireBase")]
    private FirebaseAuth firebaseAuth;



    void Start()
    {
        firebaseAuth = FirebaseAuth.DefaultInstance;    
        DoiMk.onClick.AddListener(Gui_DuLieu_Sever);
    }






    public bool Ckeck_DieuKien()
    {
        if (string.IsNullOrWhiteSpace(Gmail.text)){ ///kiểm tra xem có bỏ trống ko
            Debug.LogError("Gmail Không được bỏ trống");
            ThongBao_Sever.Instance.ThongBaoCoBan("Gmail Không được bỏ trống");
            return false;
        }
       return true;
    }

    public void Gui_DuLieu_Sever()
    {
        if (!Ckeck_DieuKien()){return;}
        firebaseAuth.SendPasswordResetEmailAsync(Gmail.text).ContinueWithOnMainThread(task=>{
            if(task.IsCanceled){
                Debug.LogError("Yêu cầu đặt lại mật khẩu bị hủy.");
                ThongBao_Sever.Instance.ThongBaoCoBan("Yêu cầu đặt lại mật khẩu bị hủy.");
            }
            if (task.IsFaulted)
            {
                Debug.LogError("Không thể gửi email đặt lại mật khẩu. Kiểm tra lại email.");
                ThongBao_Sever.Instance.ThongBaoCoBan("Không thể gửi email đặt lại mật khẩu. Kiểm tra lại email.");
                return;
            }
            Debug.Log("Email đặt lại mật khẩu đã được gửi.");
            ThongBao_Sever.Instance.ThongBaoCoBan("Email đặt lại mật khẩu đã được gửi.");
            gameObject.SetActive(false);
            OutNhom.SetActive(true);
        });
  
    }

    public void Nhan_DuLieu_Sever()
    {
        
    }
}
    