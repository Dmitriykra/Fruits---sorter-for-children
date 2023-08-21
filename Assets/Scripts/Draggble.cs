using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Draggble : MonoBehaviour
{
    public Vector3 LastPosition;
    public bool IsDragging, ba, an, ch, li, me, pe, ma, wi;
    private Collider2D collider2D;
    private DragControl dragControl;
    private float movementTime = 15f;
    private System.Nullable<Vector3> movementDestination;
    private Rigidbody2D m_Rigidbody;
    private GameObject fruits, shadow, banana, ananas,
    malina, limon, cherry, melon, pear, win_img;
    private float mouveSpeed = 0.4f;
    AudioSource correctPathSound, crowd, mainSound;
    float winUp = 9f;
    public LoadNewLevel loadNewLevel;
    float defaultVolume =  1;


    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        dragControl = FindObjectOfType<DragControl>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        correctPathSound = GetComponent<AudioSource>();
        crowd = GetComponent<AudioSource>();
        mainSound = GameObject.Find("Fruits").GetComponent<AudioSource>();

        banana = GameObject.Find("banana");
        ananas = GameObject.Find("anana");
        malina = GameObject.Find("malina");
        limon = GameObject.Find("limon");
        cherry = GameObject.Find("cherry");
        melon = GameObject.Find("melon");
        pear = GameObject.Find("pear");
        win_img = GameObject.Find("win_img");
        shadow = GameObject.Find("Shadow");
        fruits = GameObject.Find("Fruits");

        ba = true;
    }
    void Update()
    {
        if(wi){StartCoroutine(WinCorutine());}
        if(ba){StartCoroutine(BananaCorutine());}
        if(an){StartCoroutine(AnanasCorutine());}
        if(ma){StartCoroutine(MalinaCorutine());}
        if(li){StartCoroutine(LimonCorutine());}
        if(ch){StartCoroutine(CherryCorutine());}
        if(me){StartCoroutine(MelonCorutine());}
        if(pe){StartCoroutine(PearCorutine());}
    }
    IEnumerator WinCorutine()
    { 
        win_img.GetComponent<Transform>().Translate(new Vector2(0, 1) * winUp * Time.deltaTime);
        yield return new WaitForSeconds(2f);
        winUp = 0f;
        wi = false;
        Invoke("LoadSceneManager", 1f);
    }

    IEnumerator BananaCorutine()
    {
        
        banana.GetComponent<Transform>().Translate(new Vector2(0, -1) * mouveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(1.5f);
        mouveSpeed = 0f;
        ba = false;
    }

    IEnumerator AnanasCorutine()
    {
        mouveSpeed = 3f;
        ananas.GetComponent<Transform>().Translate(new Vector2(0, -1) * mouveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(1.5f);
        mouveSpeed = 0f;
        an = false;
    }

     IEnumerator MalinaCorutine()
    {
        mouveSpeed = 3f;
        malina.GetComponent<Transform>().Translate(new Vector2(0, -1) * mouveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(1.5f);
        mouveSpeed = 0f;
        ma = false;
    }

    IEnumerator LimonCorutine()
    {
        mouveSpeed = 3f;
        limon.GetComponent<Transform>().Translate(new Vector2(0, -1) * mouveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(1.5f);
        mouveSpeed = 0f;
        li = false;
    }

    IEnumerator CherryCorutine()
    {
        mouveSpeed = 3f;
        cherry.GetComponent<Transform>().Translate(new Vector2(0, -1) * mouveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(1.5f);
        mouveSpeed = 0f;
        ch = false;
    }

    IEnumerator MelonCorutine()
    {
        mouveSpeed = 3f;
        melon.GetComponent<Transform>().Translate(new Vector2(0, -1) * mouveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(1.5f);
        mouveSpeed = 0f;
        me = false;
    }

    IEnumerator PearCorutine()
    {
        mouveSpeed = 3f;
        pear.GetComponent<Transform>().Translate(new Vector2(0, -1) * mouveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(1.5f);
        mouveSpeed = 0f;
        pe = false;
    }
    
    private void FixedUpdate() 
    {
       
        if(movementDestination.HasValue)
        {
            if(IsDragging)
            {
                movementDestination = null;
                return;
            }
            if (transform.position == movementDestination)
            {
                gameObject.layer = Layer.Default;
                movementDestination = null;
            }
            else 
            {
                transform.position = Vector3.Lerp(transform.position,
                movementDestination.Value, movementTime * Time.fixedDeltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Draggble colliderDraggable = other.GetComponent<Draggble>();
        
        if(colliderDraggable != null && dragControl.LastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = other.Distance(collider2D);
            
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
        } 
       

        if(gameObject.tag == "banana")
        {   
            if(other.CompareTag("bananab"))
            {
                movementDestination = other.transform.position;
                gameObject.GetComponent<Collider2D>().enabled = false;
                an = true;
                if(!correctPathSound.isPlaying)
                {correctPathSound.Play();}
                
            }
            if(other.CompareTag("button")){
                return;
            }
            else
            {
                if(!an)
                {
                    movementDestination = LastPosition;
                    if(!correctPathSound.isPlaying){
                    shadow.GetComponent<AudioSource>().Play();}
                }   
            }    
        }

        if(gameObject.tag == "anana")
        {
            if(other.CompareTag("ananab"))
            {
                movementDestination = other.transform.position;
                gameObject.GetComponent<Collider2D>().enabled = false;
                ch = true;

                if(!correctPathSound.isPlaying)
                {correctPathSound.Play();}
            } 
            if(other.CompareTag("button")){
                return;
            }
            else
            {
                if(!ch)
                {
                    if(!correctPathSound.isPlaying)
                    {
                    shadow.GetComponent<AudioSource>().Play();
                    }
                    movementDestination = LastPosition;}   
            }    
        }

        if(gameObject.tag == "cherry")
        {
            if(other.CompareTag("cherryb"))
            {
                movementDestination = other.transform.position;
                gameObject.GetComponent<Collider2D>().enabled = false;
                li = true;

                if(!correctPathSound.isPlaying)
                {correctPathSound.Play();}
            }

            if(other.CompareTag("button")){return;}

            else
            {
                if(!li)
                {
                    if(!correctPathSound.isPlaying)
                    {
                    shadow.GetComponent<AudioSource>().Play();
                    }
                    movementDestination = LastPosition;}   
            }    
        }

        if(gameObject.tag == "limon")
        {
            if(other.CompareTag("limonb"))
            {
                movementDestination = other.transform.position;
                gameObject.GetComponent<Collider2D>().enabled = false;
                ma = true;

                if(!correctPathSound.isPlaying)
                {correctPathSound.Play();}
            }

            if(other.CompareTag("button")){return;}

            else
            {
                if(!ma){
                    if(!correctPathSound.isPlaying)
                    {
                        shadow.GetComponent<AudioSource>().Play();
                    }
                    movementDestination = LastPosition;}   
            }    
        }

        if(gameObject.tag == "malina")
        {
            if(other.CompareTag("malinab"))
            {
                movementDestination = other.transform.position;
                gameObject.GetComponent<Collider2D>().enabled = false;
                me = true;

                if(!correctPathSound.isPlaying)
                {correctPathSound.Play();}
            }
            if(other.CompareTag("button")){return;}

            else
            {
                if(!me){
                     if(!correctPathSound.isPlaying)
                     {
                        shadow.GetComponent<AudioSource>().Play();
                     }
                    movementDestination = LastPosition;}   
            }    
        }

        if(gameObject.tag == "melon")
        {
            if(other.CompareTag("melonb"))
            {
                movementDestination = other.transform.position;
                gameObject.GetComponent<Collider2D>().enabled = false;
                pe = true;

                if(!correctPathSound.isPlaying)
                {correctPathSound.Play();}

            }

            if(other.CompareTag("button")){return;}

            else
            {
                if(!pe){
                    if(!correctPathSound.isPlaying)
                     {
                        shadow.GetComponent<AudioSource>().Play();
                     }
                    movementDestination = LastPosition;}   
            }    
        }

        if(gameObject.tag == "pear")
        {
            if(other.CompareTag("pearb"))
            {
                movementDestination = other.transform.position;
                gameObject.GetComponent<Collider2D>().enabled = false;
                
                win_img.GetComponent<AudioSource>().Play();

                if(!correctPathSound.isPlaying)
                {correctPathSound.Play();}

                wi = true;

                SmootheMainMusic();
                
            }

            if(other.CompareTag("button")){return;}

            else
            {
                if(!wi)
                {
                    movementDestination = LastPosition;
                    if(!correctPathSound.isPlaying)
                     {
                        shadow.GetComponent<AudioSource>().Play();
                     }
                }   
            }    
        }
    }

    public void LoadSceneManager()
    {
        loadNewLevel.LoadLevel();
    }

    private void SmootheMainMusic()
    {
        StartCoroutine(SmootheMusic());
    }
    IEnumerator SmootheMusic()
    {
        float procentage = 0;
        while (mainSound.volume > 0)
        {
            mainSound.volume = Mathf.Lerp(defaultVolume, 0, procentage);
            procentage += Time.deltaTime / 2;
            yield return null;
        } 
        mainSound.Stop();
    }
}
