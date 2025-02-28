using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

#if UNITY_EDITOR
using UnityEditor.Callbacks;
#endif
using UnityEngine;

public class DiChuyenCoBan : I_DI_Chuyen
{

    public GameObject gameObject;// nhân vật hien tai
    public Move_Manager move_Manager;
  
    public ThongTinCoBan thongTinCoBan;
    
    public Animator animator;

    public GameObject Art;

    public Rigidbody2D rigidbody2D;

    public BoxCollider2D boxCollider2D;

    public bool DuocDiChuyen;

    public DiChuyenCoBan(GameObject gameObject)
    {
        this.gameObject = gameObject;
        move_Manager = gameObject.GetComponent<Move_Manager>();
        thongTinCoBan = move_Manager.ThongTinCoBan1;
        animator = gameObject.GetComponentInChildren<Animator>();
        Art = gameObject.transform.Find("Art")?.gameObject;
        DuocDiChuyen = true;
        rigidbody2D = gameObject.GetComponentInChildren<Rigidbody2D>();
        boxCollider2D = gameObject.GetComponentInChildren<BoxCollider2D>();
    }

    public void BatDau_HanhDong()
    {
      
    }

    public bool DieuKien()
    {
        return true;
    }

    public void HanhDong_DiChuyen()
    {
        
        if (!DuocDiChuyen){
            animator.SetBool("DiChuyen",false);
            return;
        }

        if (move_Manager.input!= 0){
            
            animator.SetBool("DiChuyen",true);
             Art.transform.rotation = move_Manager.input > 0 
            ? Quaternion.Euler(0, 0, 0) 
            : Quaternion.Euler(0, 180, 0);


       }else{
            animator.SetBool("DiChuyen",false);

            return;
       }
       
    //    gameObject.transform.Translate(Vector3.right * move_Manager.input * thongTinCoBan.TocDo  * Time.deltaTime);
    
        if (move_Manager.luot.Dang_Luot){return;}
        if(IsTouchingWall()){
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            return;
        }

        rigidbody2D.velocity = new Vector2(move_Manager.input*thongTinCoBan.TocDo,rigidbody2D.velocity.y);
        
    
    }

   bool IsTouchingWall()
    {
        float boxWidth = boxCollider2D.size.x/2;  // Độ rộng nhỏ để phát hiện va chạm
        float boxHeight = boxCollider2D.size.y/1.5f; // Điều chỉnh theo chiều cao nhân vật
        float rayLength = 0.2f; // Độ dài kiểm tra nhỏ để tránh bị hút tường

        Vector2 origin = gameObject.transform.position; // Lấy vị trí nhân vật làm gốc
        Vector2 direction = Vector2.right * Mathf.Sign(move_Manager.input);; // Hướng di chuyển
        
        RaycastHit2D hit = Physics2D.BoxCast(origin, new Vector2(boxWidth, boxHeight), 0, direction, rayLength, LayerMask.GetMask("MatDat"));
        return hit.collider != null;
    }

    
   
    public void KetThuc_HanhDong()
    {
       
    }
}
