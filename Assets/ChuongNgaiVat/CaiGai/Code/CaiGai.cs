using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.Callbacks;
#endif
using UnityEngine;

public class CaiGai : MonoBehaviour
{

    public float Damage;
    public float LucBat;
    public float ThoiGianStunde;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag =="Player"){
            Mau mau = other.gameObject.GetComponent<Mau>();
            if (mau.Hien_Tai<=0){
                return;
            }
            mau.Giam(Damage);

            ThayDoiTrangThai_Time thayDoiTrangThai_Time =   other.gameObject.GetComponent<ThayDoiTrangThai_Time>();
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.zero,ForceMode2D.Impulse);
            thayDoiTrangThai_Time.ThemThoiGianChoang(ThoiGianStunde);

   
            Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
            Debug.Log($"Knockback Direction: {knockbackDirection}, Force: {knockbackDirection * LucBat}");
            rb.AddForce(knockbackDirection * LucBat, ForceMode2D.Impulse);

            
        }
    }
}
