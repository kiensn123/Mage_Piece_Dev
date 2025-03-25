using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ab_Enemy_1 : MonoBehaviour
{

    [Header("Compoment")]
    private BoxCollider2D boxCollider2D;
    private float tia_Box;

    [SerializeField]
    public float DoDai;
    public int ChiaDoDai;

    private float KhoangCachtungDiem;

    private Vector3 posthap;


    [Header("Vẽ Tia")]
    private Vector3 Huong_Ckeck;
    private Vector3 ToaDo_HienTai;


    private Vector3 pos1;
    private Vector3 pos2;

    [SerializeField] private LayerMask groundLayer;

    public void KhoiTao_Start()
    {
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        tia_Box = boxCollider2D.size.y;
        KhoangCachtungDiem = DoDai/ChiaDoDai;
    }


    public void TimToaDo(){

        StartCoroutine(TimĐuongDi(Vector2.left));
        StartCoroutine(TimĐuongDi(Vector2.right));

    }
        


    public IEnumerator TimĐuongDi(Vector2 Huong){
        Huong_Ckeck = Huong;
        Vector3 taodocuoivec3 = transform.position + new Vector3(Huong.x, Huong.y, 0) * DoDai; // Tìm tạo độ điểm cuối
        Vector2 taodocuoivec2 =  new Vector2(taodocuoivec3.x,taodocuoivec3.y);
        for (int i=0;i< ChiaDoDai;i++){
            float t = (float)i / (ChiaDoDai - 1); 
            Vector2 toado =   Vector2.Lerp(new Vector2 (transform.position.x ,transform.position.y),taodocuoivec2,t);
            ToaDo_HienTai = toado;
            RaycastHit2D  raycastHit2D = Physics2D.Raycast(toado,Vector2.down,tia_Box,groundLayer);

            RaycastHit2D  raycastHit2D1 = Physics2D.Raycast(toado,Huong,KhoangCachtungDiem,groundLayer);

            if (raycastHit2D.collider == null || raycastHit2D1.collider != null)
            {
                if (Huong == Vector2.right)
                {
                    pos2 = toado;
                }
                else
                {
                    pos1 = toado;
                }
                break;
            }

            
            yield return new WaitForSeconds(0.05f);
        }


       
        
    }


    public IEnumerator KiemTra_TrenMatDat(){
        while (true){
            RaycastHit2D  raycastHit2D = Physics2D.Raycast(transform.position,Vector2.down,tia_Box,groundLayer); 
            // Debug.Log(raycastHit2D.collider);
            if (raycastHit2D.collider!=null){
                posthap = raycastHit2D.point;
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        TimToaDo();
       
       
    }


 

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position,transform.position+Vector3.right*DoDai);
        Gizmos.DrawLine(transform.position,transform.position+Vector3.left*DoDai);
        // Gizmos.DrawLine(transform.position,transform.position+Vector3.down*tia_Box);

        // Gizmos.DrawLine(Huong_Trai,Huong_Trai+Vector3.down*tia_Box);
        // Gizmos.DrawLine(Huong_Trai,Huong_Trai+Vector3.down*tia_Box);
        // Gizmos.DrawSphere(Huong_Trai,0.1f);

        // Gizmos.DrawLine(ToaDo_HienTai,ToaDo_HienTai+Huong_Ckeck*KhoangCachtungDiem);
        // Gizmos.DrawLine(ToaDo_HienTai,ToaDo_HienTai+Vector3.down*tia_Box);


        Gizmos.DrawSphere(pos2,0.1f);
        Gizmos.DrawSphere(pos1,0.1f);
   
 
    }

}
