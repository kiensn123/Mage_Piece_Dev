using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class HieuUng : MonoBehaviour
{

    public CinemachineVirtualCamera cinemachineVirtualCamera;

    public GameObject TanBienEffect;

    public Material material_Defaul;
    private float Camera_Zoom_Defaul;
    

    [System.Serializable]

    public class Shader_Table{
    
    public int Shader_Id;
    public string Shader_Name;
    public Material Shader_Material;

    }

    [Header("Hiệu Ứng Của Người Chơi")]

    public Texture2D player_Img;

    public List<Shader_Table> shader_Tables;



    [Header("Hiệu Ứng  UI Chuyển Cảnh")]

    public List<GameObject> UI_Tables;





    /// <summary>
    /// 
    /// </summary>
    /// <param name="player"></param>


    public void Player_Die_Fuc(GameObject player)
    {
       
        StartCoroutine(TanBien(player));
    }


    IEnumerator TanBien( GameObject player){
         float zoomInSize = 3f; // Giá trị OrthographicSize khi zoom gần
        float zoomDuration = 1.5f;
        Camera_Zoom_Defaul = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        // Zoom camera
        DOTween.To(() => cinemachineVirtualCamera.m_Lens.OrthographicSize,
                x => cinemachineVirtualCamera.m_Lens.OrthographicSize = x,
                zoomInSize,
                zoomDuration);


        yield return new  WaitForSeconds(1);

        GameObject Art = player.transform.Find("Art")?.gameObject;
        GameObject Char = Art.transform.GetChild(0).gameObject;
        SpriteRenderer spriteRenderer = Char.GetComponent<SpriteRenderer>();
        // material_Char = shader_Tables[0].Shader_Material;
        spriteRenderer.material = shader_Tables[0].Shader_Material;
        Texture2D texture = spriteRenderer.sprite.texture;

        Renderer renderer = Char.GetComponent<Renderer>();
        MaterialPropertyBlock _propertyBlock = new MaterialPropertyBlock();



        // Set initial value for _TanBien_Float
        _propertyBlock.SetTexture("_MainText", texture);  
        _propertyBlock.SetFloat("_TanBien_Float", 1f);  
        _propertyBlock.SetColor("_OutLineColor", Color.red);
        _propertyBlock.SetFloat("_OutLine", 0.128f);
        _propertyBlock.SetFloat("_DoChiTiet", 278f);
        // Apply the properties to the renderer
        renderer.SetPropertyBlock(_propertyBlock);

        // Animate _TanBien_Float value over 3 seconds (for example, from 0.5f to 0)
     



        DOTween.To(() => _propertyBlock.GetFloat("_TanBien_Float"),
                x => _propertyBlock.SetFloat("_TanBien_Float", x),
                0f, 5f).OnUpdate(() => renderer.SetPropertyBlock(_propertyBlock));

        // yield return new  WaitForSeconds(0.6f); 

        // GameObject eff = Instantiate(TanBienEffect,Art.transform);
        // ParticleSystem particleSystem = eff.GetComponent<ParticleSystem>();
        // particleSystem.Play();

        // yield return new  WaitForSeconds(1.5f); 
        // particleSystem.Stop();

        yield return new  WaitForSeconds(2f); 

        Animator animator = UI_Tables[0].GetComponent<Animator>();
        animator.Play("An");
        yield return null;
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        
        yield return new WaitForSeconds(animationLength+1f); 

        TrangThai_Manager trangThai_Manager = player.GetComponent<TrangThai_Manager>();
        trangThai_Manager.ThayDoi_TrangThai(trangThai_Manager.tT_HoiSinh);
    }

    /// <summary>
    /// cc
    /// </summary>
    /// <param name="lucSkake">Lực shake được áp dụng</param>
    /// <param name="time">Thời gian shake.</param>

    public void Player_Dash(float lucSkake,float time){
        StartCoroutine(CamraShake(lucSkake,time));
           
      
    }



    IEnumerator CamraShake(float lucSkake,float time){

        CinemachineBasicMultiChannelPerlin perlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();    
        perlin.m_AmplitudeGain = lucSkake;
        // DOTween.To(() => cinemachineVirtualCamera.m_Lens.OrthographicSize,
        // x => cinemachineVirtualCamera.m_Lens.OrthographicSize = x,
        // 10,
        // 0.2f);
        yield return new WaitForSeconds(time);

        perlin.m_AmplitudeGain = 0;
        // DOTween.To(() => cinemachineVirtualCamera.m_Lens.OrthographicSize,
        // x => cinemachineVirtualCamera.m_Lens.OrthographicSize = x,
        // 7,
        // 0.2f);


    }


    /// <summary>
    /// Hieu Ung Danh Nhau
    /// </summary>
    /// <param name="thoigian"></param>
    /// <param name="do_dam"></param>
    /// <param name="mausac"></param>
    /// <param name="character"></param>

    public void Flash_Damge_Character(float thoigian , float do_dam ,Color mausac ,GameObject character){
        StartCoroutine(Flash_Damge_Character_IEnumerator(thoigian , do_dam , mausac ,character));
    }

    IEnumerator Flash_Damge_Character_IEnumerator(float thoigian , float do_dam ,Color mausac ,GameObject character){

        SpriteRenderer spriteRenderer = character.GetComponent<SpriteRenderer>();
        Texture2D texture2D = spriteRenderer.sprite.texture;
        Renderer renderer = character.GetComponent<Renderer>();
        MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();

        spriteRenderer.material = shader_Tables[1].Shader_Material;

        
        materialPropertyBlock.SetTexture("_Main_Text",texture2D);
        materialPropertyBlock.SetFloat("_Flash_Amout",do_dam);
        materialPropertyBlock.SetColor("_Flash_Color",mausac);
        renderer.SetPropertyBlock(materialPropertyBlock);


        yield return new WaitForSeconds(thoigian);
    
        materialPropertyBlock.SetFloat("_Flash_Amout",0);
        renderer.SetPropertyBlock(materialPropertyBlock);

    }



    //HieuUngNguoiChoi Hoi Sinh
    /// <summary>
    /// 
    /// </summary>
    /// <param name="plr">Người Chơi</param>
    public void Player_HoiSinh(GameObject plr){
        StartCoroutine(Player_HoiSinh_IEnumerator(plr));
    }


    IEnumerator Player_HoiSinh_IEnumerator(GameObject plr){
        cinemachineVirtualCamera.m_Lens.OrthographicSize = Camera_Zoom_Defaul;
        Animator animator = UI_Tables[0].GetComponent<Animator>();
        animator.Play("Hien");
        yield return new WaitForSeconds(1f);

        GameObject Art = plr.transform.Find("Art")?.gameObject;
        GameObject Char = Art.transform.GetChild(0).gameObject;
        SpriteRenderer spriteRenderer = Char.GetComponent<SpriteRenderer>();
        // material_Char = shader_Tables[0].Shader_Material;
        spriteRenderer.material = shader_Tables[0].Shader_Material;
        Texture2D texture = spriteRenderer.sprite.texture;
        Renderer renderer = Char.GetComponent<Renderer>();
        MaterialPropertyBlock _propertyBlock = new MaterialPropertyBlock();



        // Set initial value for _TanBien_Float
        _propertyBlock.SetTexture("_MainText", texture);  
        _propertyBlock.SetFloat("_TanBien_Float", 0f);  
        _propertyBlock.SetColor("_OutLineColor", Color.white);
        _propertyBlock.SetFloat("_OutLine", 0.128f);
        _propertyBlock.SetFloat("_DoChiTiet", 278f);
        // Apply the properties to the renderer
        renderer.SetPropertyBlock(_propertyBlock);

        // Animate _TanBien_Float value over 3 seconds (for example, from 0.5f to 0)
     



        DOTween.To(() => _propertyBlock.GetFloat("_TanBien_Float"),
                x => _propertyBlock.SetFloat("_TanBien_Float", x),
                1f, 2f).OnUpdate(() => renderer.SetPropertyBlock(_propertyBlock));

        
    }


    /// <summary>
    /// 
    /// </summary>


    private void OnEnable() {
        Observer_Pattern_Sever.Instance.Player_Die  += Player_Die_Fuc;
        Observer_Pattern_Sever.Instance.Player_Dash += Player_Dash;
        Observer_Pattern_Sever.Instance.Flash_Damge += Flash_Damge_Character;
        Observer_Pattern_Sever.Instance.Player_HoiSinh += Player_HoiSinh;
    }

    private void OnDisable() {
        Observer_Pattern_Sever.Instance.Player_Die -= Player_Die_Fuc;
        Observer_Pattern_Sever.Instance.Player_Dash -= Player_Dash;
        Observer_Pattern_Sever.Instance.Flash_Damge -= Flash_Damge_Character;
        Observer_Pattern_Sever.Instance.Player_HoiSinh -= Player_HoiSinh;
    }   
}
