using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nhay : I_DI_Chuyen
{

    public GameObject gameObject;// nhân vật hien tai
    public Move_Manager move_Manager;
    public ThongTinCoBan thongTinCoBan;
    public Rigidbody2D rigidbody2D;
    public BoxCollider2D boxCollider;

    public bool DuocNhay;

    public Animator animator;

     public float TocDoRoiXong=3; 
     public Vector2 TocDoRoiXong_Vector;



    public Nhay(GameObject gameObject)
    {
        this.gameObject = gameObject;
        move_Manager = gameObject.GetComponent<Move_Manager>();
        thongTinCoBan = move_Manager.ThongTinCoBan1;
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        TocDoRoiXong_Vector = new Vector2(0,-Physics2D.gravity.y);
        animator = gameObject.GetComponentInChildren<Animator>();
        DuocNhay = true;
        
        PLayer_GUI.Instance.Nhay.onClick.AddListener(HD_Nhay);
      
    }
    private bool Kiem_tra_TrenMatDat(){

        

        Vector2 boxsize = new Vector2(boxCollider.size.x/3f, boxCollider.size.y);
       // Kiểm tra nếu có va chạm với "MatDat" dưới chân nhân vật
        Collider2D hit = Physics2D.OverlapBox((Vector2)gameObject.transform.position + boxCollider.offset, boxsize, 0f, LayerMask.GetMask("MatDat"));
        
        if (hit != null)
        {
            
            return true; // Đang đứng trên mặt đất
        }
        else
        {
     
           return false;   // Không đứng trên mặt đất
        }
    }


    public void BatDau_HanhDong()
    {
        throw new System.NotImplementedException();
    }

    public void HanhDong_DiChuyen()
    {
        animator.SetFloat("DoRoi",rigidbody2D.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space)){
            HD_Nhay();
        }
        if (rigidbody2D.velocity.y<0){
        
            rigidbody2D.velocity -=  TocDoRoiXong_Vector*TocDoRoiXong*Time.deltaTime;
            animator.SetBool("Nhay",false);


        }

    }



    public void HD_Nhay(){
        if (!DuocNhay){
            return;
        }
     
        if ( DieuKien() ){
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,thongTinCoBan.Nhay_Cao);
            animator.SetBool("Nhay",true);
        }
    }

    public void KetThuc_HanhDong()
    {
        throw new System.NotImplementedException();
    }

    public bool DieuKien()
    {
        return Kiem_tra_TrenMatDat();
    }
}
