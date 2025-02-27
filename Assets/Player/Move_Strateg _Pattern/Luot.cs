using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

    public class Luot : MonoBehaviour, I_DI_Chuyen 
    {

    public GameObject mygameObject;// nhân vật hien tai
    public Move_Manager move_Manager;
    public ThongTinCoBan thongTinCoBan;
    public Rigidbody2D myrigidbody2D;
    public BoxCollider2D boxCollider;
    public GameObject Art;
    public bool DuocLuot;
    public bool Dang_Luot;
    private float ThoiGian_Cd  = 1;
    private float Bo_Dem;

    public Nang_Luong nang_Luong;
    public float Soluong_DungMana = 10;



    public void Creat_Luot(GameObject gameObject)
    {
        this.mygameObject = gameObject;
        move_Manager = this.gameObject.GetComponent<Move_Manager>();
        thongTinCoBan = move_Manager.ThongTinCoBan1;
        myrigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
        myrigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        Art = gameObject.transform.Find("Art")?.gameObject;
        DuocLuot = true;
        nang_Luong = gameObject.GetComponent<Nang_Luong>();
        Bo_Dem = Time.time;


        PLayer_GUI.Instance.Luot_Button.onClick.AddListener(Luot_Fucition);
    
    }

    void Start()
    {
        Creat_Luot(this.gameObject);
    }

      

    public void HanhDong_DiChuyen()
    {
            
        if (Input.GetKeyDown(KeyCode.Q) ) {
            Luot_Fucition();
            return;
        }

        // Luot_Fucition();

    
    }


    public bool DieuKien(){
        if ( move_Manager.input !=0 && Time.time - Bo_Dem>ThoiGian_Cd && !Dang_Luot && DuocLuot && nang_Luong.Hien_Tai>=Soluong_DungMana){
            return true;
        }
        return false;
    }



    public async void Luot_Fucition(){
    
            if (!DieuKien()){return;}
            Bo_Dem = Time.time;
            nang_Luong.Giam(Soluong_DungMana);
            // await LuotDenPhiTruoc();
            Task task1 = Luoi_RigBody(); 
            Task task2 = HieuUngLuot();
            // Đợi cho đến khi cả hai phương thức hoàn tất
            await Task.WhenAll(task1, task2);
    }
    

    private async Task Luoi_RigBody(){
            float dashDirection = move_Manager.input; 
            if (dashDirection<0 && dashDirection>-1){
                dashDirection =  -1;
            }else if(dashDirection>0 && dashDirection<1){
                dashDirection =  1;
            }
            Observer_Pattern_Sever.Instance.DKSK_Player_Dash(2,0.1f);
            Vector2 dashVelocity = new Vector2(dashDirection * thongTinCoBan.TocDoLuot,0);
            float LuuGarvity =  myrigidbody2D.gravityScale;
            myrigidbody2D.gravityScale = 0;
            myrigidbody2D.velocity = dashVelocity;
            Dang_Luot = true;
            await Task.Delay(300);
    
            myrigidbody2D.velocity = Vector2.zero;
            myrigidbody2D.gravityScale = LuuGarvity; 
            Dang_Luot = false;
            

    }
     
    private async Task LuotDenPhiTruoc()
    {
        float luu = thongTinCoBan.TocDo;
        thongTinCoBan.TocDo = thongTinCoBan.TocDoLuot;
        Dang_Luot = true;
        
        await Task.Delay(300); // 300ms (tương đương 0.3 giây)
        Dang_Luot = false;
        thongTinCoBan.TocDo = luu;
    }

    private async Task  HieuUngLuot(){
        while (Dang_Luot == true){
            GameObject Char = Art.transform.GetChild(0).gameObject;
            GameObject New = Instantiate(Char);
            New.transform.SetParent(Art.transform);
            Vector3 positon_new = new Vector3(Char.transform.position.x ,Char.transform.position.y,Char.transform.position.z+0.2f);
            New.transform.position =positon_new;
            New.transform.rotation = Char.transform.rotation;
            New.transform.localScale = Char.transform.localScale;
            Animator animator = New.GetComponent<Animator>();
            animator.enabled = false;   
            SpriteRenderer spriteRenderer = New.GetComponent<SpriteRenderer>();
            Color currentColor = spriteRenderer.color;
            // Thay đổi giá trị alpha
            currentColor.a = 0.5f;  // Điều chỉnh độ mờ
            // Gán lại giá trị color cho spriteRenderer
            spriteRenderer.color = currentColor;
            spriteRenderer.material = thongTinCoBan.DashGhost;       
            New.transform.SetParent(null);
            Destroy(New,0.3f);
            await Task.Delay(50);
        }

        
    }

    public void KetThuc_HanhDong()
    {

    }

    public void BatDau_HanhDong()
    {
        
    }
}
