using System.Collections;
using UnityEngine;

public class DestroyEnviroment : MonoBehaviour
{
    public float tunnelAnimTime = 100f;
    public float mountainAnimTime = 200f;
    public float eliminateDistance = -210f;
    public float mountainAnimDistance = 2f;

    private bool mountainAnimStart = false;
    private bool tunnelAnimStart = false;
    Animator mountain_animator;
    Animator tunnel_animator;

    public float earth_star_HideDist = 275;
    public float starAppearDist = 45;
    public float earthAppearDist =-200;


    private Vector3 outSide_pos = new Vector3(30,0,0);
    private Vector3 inside_star_pos = new Vector3(.4f,12.5f,11f);
    private Vector3 inside_earth_pos = new Vector3(5,0,10);
    void Start()
    {
        Vector3 pos = transform.position;
        pos.x = 0;
        pos.y = 10;
      //  transform.position = pos;
      //  mountain_animator = transform.Find("mountain").GetComponent<Animator>();
    }

    void Update()
    {
       /* if (!mountainAnimStart && transform.position.z < mountainAnimDistance)
        {
         
           mountainAnimStart = true;
            StartCoroutine(animateMountain());
        }

        if (!tunnelAnimStart && transform.position.z < mountainAnimDistance)
        {
            tunnelAnimStart = true;
            //StartCoroutine(animateTunnel());
        }*/


        if (transform.position.z < eliminateDistance)
        {
            TunnelManager.isEnvExist = false;
            Destroy(this.gameObject);
        }

       // manageSpaceEnviroment();
    }

    void manageSpaceEnviroment()
    {
      
        if (transform.position.z < earthAppearDist)
        {
         
            GameObject.FindGameObjectWithTag("earth").transform.position = inside_earth_pos;
        }

       else if (transform.position.z < starAppearDist)
        {
            GameObject.FindGameObjectWithTag("star").transform.position = inside_star_pos;
        }

        else if (transform.position.z < earth_star_HideDist)
        {
            GameObject.FindGameObjectWithTag("earth").transform.position = outSide_pos;
            GameObject.FindGameObjectWithTag("star").transform.position  = outSide_pos;
        }


    }
    IEnumerator animateTunnel()
    {
        GetComponent<MoveForward>().enabled = false;
        tunnel_animator.enabled = true;
         yield return new WaitForSeconds(20f);
        tunnel_animator.enabled = false;
        GetComponent<MoveForward>().enabled = true;
    }

    IEnumerator animateMountain()
    {
        GetComponent<MoveForward>().enabled = false;
        mountain_animator.SetBool("animMountain", true);
        yield return new WaitForSeconds(20f);
        mountain_animator.SetBool("animMountain", false);
        GetComponent<MoveForward>().enabled = true;
    }
}
