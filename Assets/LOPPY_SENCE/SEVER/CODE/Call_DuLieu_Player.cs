using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using Firebase.Firestore;
using Unity.VisualScripting;
using UnityEngine;


public class Call_DuLieu_Player : MonoBehaviour
{
    private static Call_DuLieu_Player instance;
    public static Call_DuLieu_Player Instance
        {
            get{
                if (instance == null){
                    instance = FindObjectOfType<Call_DuLieu_Player>();
                    if (instance == null){
                        GameObject singletonObject = new GameObject(typeof(Call_DuLieu_Player).Name);
                        instance = singletonObject.AddComponent<Call_DuLieu_Player>();
                    }
                }
                return instance;
            }



        }


    [Header("Người Chơi")]
    public Player_Mage player_Mage;


    [Header("Fire_Base")]
    private FirebaseUser user;
    private FirebaseFirestore db;
    private DatabaseReference dbReference;
    FirebaseAuth auth;


    private void Awake() {
      
        if (instance != null && instance!= this){
            Destroy(gameObject);
            return;
        }
        transform.parent = null;
        DontDestroyOnLoad(gameObject);

        instance = this;      
    }



    public void Start()
    {
       
        auth = FirebaseAuth.DefaultInstance;
        user = auth.CurrentUser;
        db = FirebaseFirestore.DefaultInstance;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        player_Mage = new Player_Mage();
      
        
    }
    
    public async Task CallDuLieu(){
        user = FirebaseAuth.DefaultInstance.CurrentUser;
        Call_ThonTing_NguoiChoi();
        await KiemTra(user.UserId);
    }


    public void Call_ThonTing_NguoiChoi(){
        //  FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
    
        Thong_Tin_CoBan thong_Tin_CoBan = new Thong_Tin_CoBan(user.DisplayName,user.Email);
        player_Mage.Thong_Tin_Co_Ban = thong_Tin_CoBan;
  
      
    }



    public async Task KiemTra(string User_id){
        ///
        bool userTonTai = await Ktra_UserId_(User_id);
        if (userTonTai){ await Lay_Toan_BoDu_Lieu_Nguoi_Choi(User_id); return;}
        ///
        wite_DataBase_UserId_New(User_id);

        await Lay_Toan_BoDu_Lieu_Nguoi_Choi(User_id);


    }
    

    public void wite_DataBase_UserId_New(string User_id){
        dbReference.Child("Users").Child(User_id).RunTransaction(mutableData =>
        {
            // Tạo dữ liệu mới cho ThongSo
            Thongso thongso_new = new Thongso(60, 0, 0, 0, 0, 0);
            Dictionary<string, object> thongso = new Dictionary<string, object> {
                {"Tien", thongso_new.Tien},
                {"Ruby", thongso_new.Ruby},
                {"Diem_Mau", thongso_new.Diem_Mau},
                {"DiemMana", thongso_new.DiemMana},
                {"Capdo", thongso_new.Capdo},
                {"Diem_KinhNghiem", thongso_new.Diem_KinhNghiem}
            };

            // Tạo dữ liệu mới cho TienTrinh
            TienTrinh tienTrinh_new = new TienTrinh(new List<int>(){0}, 0);
            Dictionary<string, object> tientrinh = new Dictionary<string, object> {
                {"Map_Win", tienTrinh_new.Map_Win},
                {"Skill_Id", tienTrinh_new.Skill_Id}
            };

            // Gộp tất cả dữ liệu vào 1 Dictionary chung
            Dictionary<string, object> newUserData = new Dictionary<string, object>
            {
                {"ThongSo", thongso},
                {"TienTrinh", tientrinh}
            };

            // Ghi đè dữ liệu trong transaction
            mutableData.Value = newUserData;
            return TransactionResult.Success(mutableData);

        }).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted && !task.IsFaulted && !task.IsCanceled)
            {
                Debug.Log("Đã thêm dữ liệu với transaction thành công!");
            }
            else
            {
                Debug.LogError("Lỗi! Không thể thêm dữ liệu.");
            }
        });


    }


    public async Task<bool> Ktra_UserId_(string User_id){
        DatabaseReference userRef = dbReference.Child("Users").Child(User_id);
        DataSnapshot snapshot = await userRef.GetValueAsync();

        if (snapshot.Exists)
        {
            Debug.Log("User " + User_id + " đã tồn tại.");
            return true;
        }
        else
        {
            Debug.Log("User " + User_id + " chưa có trong database.");
            return false;
        }


               
    } 



    public Task Lay_Toan_BoDu_Lieu_Nguoi_Choi(string User_id) {
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

        dbReference.Child("Users").Child(User_id).GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsCompleted) {
                DataSnapshot snapshot = task.Result;
                if (snapshot.Exists) {
                    if (snapshot.Child("ThongSo").Exists) {
                        Thongso thongso = JsonUtility.FromJson<Thongso>(snapshot.Child("ThongSo").GetRawJsonValue());
                        player_Mage.Thong_So = thongso;
                        Debug.Log($"📌 Tien: {thongso.Tien}, Ruby: {thongso.Ruby}, Capdo: {thongso.Capdo}");
                    } else {
                        Debug.LogWarning("Không tìm thấy dữ liệu ThongSo!");
                    }

                    if (snapshot.Child("TienTrinh").Exists) {
                        TienTrinh tienTrinh = JsonUtility.FromJson<TienTrinh>(snapshot.Child("TienTrinh").GetRawJsonValue());
                        player_Mage.Tien_Trinh = tienTrinh;
                        Debug.Log($"📌 Skill_Id: {tienTrinh.Skill_Id}, Map_Win: {string.Join(", ", tienTrinh.Map_Win)}");
                    } else {
                        Debug.LogWarning("Không tìm thấy dữ liệu TienTrinh!");
                    }

                    Debug.Log("Da Call Xong");
                    tcs.SetResult(true); // Báo hiệu hoàn thành
                } else {
                    Debug.LogError("❌ Không tìm thấy dữ liệu người dùng!");
                    tcs.SetResult(false);
                }
            } else {
                Debug.LogError("❌ Lỗi khi đọc dữ liệu từ Firebase!");
                tcs.SetException(task.Exception);
            }
        });

        return tcs.Task;
    }

    

    
}