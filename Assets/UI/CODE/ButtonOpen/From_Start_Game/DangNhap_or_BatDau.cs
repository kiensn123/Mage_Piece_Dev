using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.UI;

public class DangNhap_or_BatDau : MonoBehaviour

{


    [Header("Button")]

    public Button Log_out;


    [Header("Obj")]
    public GameObject NutStart;

    public GameObject NutDangNhapDangKi;

    [Header("FireBase")]
    private FirebaseAuth firebaseAuth;
    private FirebaseUser currentUser;



    void Start()
    {
        firebaseAuth = FirebaseAuth.DefaultInstance; 
        firebaseAuth.StateChanged += OnAuthStateChanged;
        Log_out.onClick.AddListener(DangXuat);
    }
    private void OnAuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        currentUser = firebaseAuth.CurrentUser;

        if (currentUser != null)
        {
            Debug.Log("Người dùng đã đăng nhập: " + currentUser.Email);
 
            NutStart.SetActive(true); // Hiện nút vào game
            NutDangNhapDangKi.SetActive(false);
        }
        else
        {
            Debug.Log("Chưa có ai đăng nhập.");
            NutStart.SetActive(false); // Hiện nút vào game
            NutDangNhapDangKi.SetActive(true);
        }
    }

    private void DangXuat(){
        firebaseAuth.SignOut();
    }
}
