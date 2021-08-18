using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player: MonoBehaviour {
   
    public Text altinmiktari,mantarmiktari;
    private float speed = 10.0f;
    private Vector3 scale;
    private int jumpforce = 250;
    public int ziplamasayisi = 4;
    private float maxVelocity = 13.0f;
    private Rigidbody2D myRigidBody;
    private Animator myAnim;
    public AudioClip[] sees;
    public int can, maxcan,mantar,altin;
    public int altinsayisi;
    public int altinmikarı;
    private int toplam_altin;
    

    public GameObject[] canlar;

  
    
    
    private void Awake()
    {

        myRigidBody = GetComponent<Rigidbody2D>();
        scale = this.transform.localScale;
        myAnim = GetComponent<Animator>();
        can = maxcan;
        canSistemi(); 
        altinsayisi = PlayerPrefs.GetInt("altin");
        
        
    }

    private void FixedUpdate()
    {

         if (ziplamasayisi > 0)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                myRigidBody.AddForce(Vector2.up * jumpforce);
                myAnim.Play("Player_Jump");
                myAnim.SetBool("zemindeMi", false);


             

                

                
            }
            
        }


        if (can <= 0){
            olme();
        }


        //Debug.Log(ziplamasayisi);



        Attack();

        Kosma();
       
    }

    public void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myAnim.SetBool("isAttacking", true);
        }
        else
        {
            myAnim.SetBool("isAttacking", false);
        }

      
    }
   public void AttackAnimation()
    {
        myAnim.SetBool("isAttacking", false);
    }
   




   private void Kosma()
    {
        float force = 0.0f;
        float velocity = Mathf.Abs(myRigidBody.velocity.x);
        float h = Input.GetAxis("Horizontal");

        if (h > 0)
        {
            if (velocity < maxVelocity)
            {
                force = speed;
                scale.x = 2;
                this.transform.localScale = scale;
            }



        }
        else if (h < 0)
        {
            if (velocity < maxVelocity)
            {
                force = -speed;
                scale.x = -2;
                this.transform.localScale = scale;
            }


        }

        myRigidBody.AddForce(new Vector2(force, 0));
        myAnim.SetFloat("speed", Mathf.Abs(h));
    }




    
    

    private void OnCollisionEnter2D(Collision2D hedef)
    {
        if (hedef.gameObject.tag == "Tilemap")
        {


            myAnim.SetBool("zemindeMi", true);

            ziplamasayisi = 4;


            
        }
       




    }
    
    void OnTriggerEnter2D(Collider2D nesne)
    {
        if (nesne.gameObject.tag == "altin")
        {
            altin+=20;
            GetComponent<AudioSource>(). PlayOneShot(sees[0]);
            Destroy(nesne.gameObject);

        }

        if (nesne.gameObject.tag == "mantar")
        {
            mantar+=30;
            GetComponent<AudioSource>().PlayOneShot(sees[1]);
            Destroy(nesne.gameObject);

        }
        if (nesne.gameObject.tag == "ev")
        {
            Application.LoadLevel("anasahne");
        }


        if (nesne.gameObject.tag == "can")
        {


        }
      
        
    }

    void Update ()
    {
        altinmiktari.text = ""+altin;
        mantarmiktari.text = "" + mantar;
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    void olme()
    {
        PlayerPrefs.SetInt("altin", altinsayisi);
        Application.LoadLevel(Application.loadedLevel);

    }


    void OnCollision2D(Collision2D nesne)
    {
        if (nesne.gameObject.tag == "tuzak")
        {
            can -= Random.Range(1, 3);
            canSistemi();
        }
        
    }

    void canSistemi()
    {
        for(int i=0; i<maxcan; i++)
        {
            canlar[i].SetActive(false);
        }
        for(int i=0; i<can; i++)
        {
            canlar[i].SetActive(true);
        }
    }
    
}
