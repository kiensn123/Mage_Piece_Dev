using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class CHON_MAP_CODE : MonoBehaviour
{
 

    public int ThuTuMap = 0;
    public GameObject ThanhTruot;
    public float ScollPos =0;
    float []pos;

    void Start()
    {
        pos = new float[transform.childCount]; 
        float distance = 1f / (pos.Length - 1f);
        
        for (int i = 0; i < pos.Length; i++) {
            pos[i] = distance * i;
        }

        // Đặt vị trí ban đầu
        ScollPos = pos[ThuTuMap];  
        ThanhTruot.GetComponent<Scrollbar>().value = ScollPos;
    }

    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f/(pos.Length-1f);
        for(int i = 0;i<pos.Length;i++){
            pos[i] = distance*i;
        }
        if(Input.GetMouseButton(0)){
            ScollPos = ThanhTruot.GetComponent<Scrollbar>().value;
        }else{
            for (int i=0;i<pos.Length;i++){
                if (ScollPos<pos[i] +(distance/2) && ScollPos > pos[i] - distance/2){
                    ThanhTruot.GetComponent<Scrollbar>().value = Mathf.Lerp(ThanhTruot.GetComponent<Scrollbar>().value,pos[i],0.1f);
                }
                
            }
        }


        for (int i=0;i<pos.Length;i++){
            if (ScollPos<pos[i] +(distance/2) && ScollPos > pos[i] - distance/2){
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale,new Vector2(1f,1f),0.2f);
                for(int a=0;a<pos.Length;a++){
                    if (a!= i){
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(i).localScale,new Vector2(0.5f,0.5f),0.2f);
                    }
                }
            }
        }
    }
}
