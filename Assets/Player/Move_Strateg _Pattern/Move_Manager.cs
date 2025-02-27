using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Manager : MonoBehaviour
{
    
    public ThongTinCoBan ThongTinCoBan1;
    public DiChuyenCoBan diChuyenCoBan ;
 
    public Nhay nhay;

    public Luot luot ;
    public float input ;

    public Button_Mobi_Joy button_Mobi_Joy;
    private bool May_Tinh;
    
    void Start()
    {
        diChuyenCoBan = new DiChuyenCoBan(gameObject);
        nhay = new Nhay(gameObject);
        // luot = new Luot(gameObject);
        luot = gameObject.AddComponent<Luot>();
        

        May_Tinh = false;
        if ( Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer)
        {
        
            May_Tinh = true;
        }


    }

    void Update()
    {
        if (May_Tinh){

            input =0;
            if (Input.GetKey(KeyCode.A)){
                input = -1;
            }
            if (Input.GetKey(KeyCode.D)){
                input = 1;
            }
            // input = Input.GetAxis("Horizontal");
        }else{
            input = button_Mobi_Joy.joystick.Horizontal;
        }

        input = (input != 0) ? (input > 0 ? 1 : -1) : input;




        diChuyenCoBan.HanhDong_DiChuyen();
        nhay.HanhDong_DiChuyen();
        luot.HanhDong_DiChuyen();
    }
    
}
