using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ship : MonoBehaviour
{
    Gun[] guns;

    public GameObject Explosion;

    bool shoot;
    bool ulti;
    int powerUpGunLevel = 0;
    public static int ScoreUlt = 0;

    public SpriteRenderer playerShip;

    public AudioClip[] HitClip;
    private AudioSource source;
    public AudioClip deadSound;
    public AudioClip triggerSound;
    public AudioSource triggerSource;


    SoundManager soundManager;

    int hits = 3;
    bool invincible = false;
    float invincibleTimer = 0;
    float invincibletime = 2;
    GameObject shield;
    public SpriteRenderer spriteRenderer;
    public string levelToLoad;
    public PlayerMovement movement;
    public BoxCollider2D bc2d;
    bool isDead;
    public PlayerMovement pMovement;
    public AudioSource engineSound;

    public GameObject beamRifle;
    public GameObject beamRifle1;
    public GameObject beamRifle2;

    public GameObject Booster;

   




    private void Awake()
    {
        spriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        SoundManager.Instance.GetComponent<AudioSource>().Play();
        guns = transform.GetComponentsInChildren<Gun>();
        foreach (Gun gun in guns)
        {
            source = gameObject.AddComponent<AudioSource>();
            shield = transform.Find("Shield").gameObject;
            gun.isActive = true;
            if (gun.poweUpLevelRequirement != 0)
            {
                gun.gameObject.SetActive(false);
            }
        }
        engineSound.Play();
        beamRifle.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.gameEnding) return;
        if (Pause.paused) return;
        if (invincible)
        {

            if (invincibleTimer >= invincibletime)
            {
                invincibleTimer = 0;
                invincible = false;
                spriteRenderer.enabled = true;
            }
            else
            {
                invincibleTimer += Time.deltaTime;
                spriteRenderer.enabled = !spriteRenderer.enabled;
            }
        }
        ulti = Input.GetKeyDown(KeyCode.Q);
        if (ulti)
        {
            Ultimate();
        }
        shoot = Input.GetKeyDown(KeyCode.Mouse0);
        if (shoot)
        {
            shoot = false;
            foreach (Gun gun in guns)
            {
                if (gun.gameObject.activeSelf)
                {
                    gun.Shoot();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            triggerSource.PlayOneShot(triggerSound);
            beamRifle.active = true;
            beamRifle1.active = true;
            beamRifle2.active = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            beamRifle.active = false;
            beamRifle1.active = false;
            beamRifle2.active = false;
        }

        
       
    }

    public void Ultimate()
    {
        if (ScoreUlt >= 5)
        {
            pMovement.IncreaseSpeed();
        }
    }

   
    public void ActivateShield()
    {
        shield.SetActive(true);
    }
    public void DeactivateShield()
    {
        shield.SetActive(false);
    }

    bool HasShield()
    {
        return shield.activeSelf;
    }
    void Hit(GameObject gameobjecthit)
    {
        if (HasShield())
        {
            DeactivateShield();
        }
        else
        {
            if (!invincible && !isDead)
            {
                hits--;
                StartCoroutine(afterHit());
                PlaySFX(Random.Range(0, HitClip.Length));
                gameObject.GetComponent<Sound>();
                
                if (hits == 0 )
                {
                    
        
                    spriteRenderer.enabled = false;
                    Booster.active = false;
                    movement.enabled = false;
                    bc2d.enabled = false;
                    Explosion.active = true;
                    source.PlayOneShot(deadSound);
                    StartCoroutine(menu());
                    isDead = true;
                    SoundManager.Instance.GetComponent<AudioSource>().Stop();
                    engineSound.Stop();
                    PlayerMovement.Instance.GetComponent<AudioSource>().Stop();
                    
                }
                else
                {
                    invincible = true;
                }
                Destroy(gameobjecthit);
            }
        }
    }

    void AddGuns()
    {
        powerUpGunLevel++;
        foreach (Gun gun in guns)
        {
            if (gun.poweUpLevelRequirement == powerUpGunLevel)
            {
                gun.gameObject.SetActive(true);
            }
        }
    }
    IEnumerator menu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(levelToLoad);
    }
    IEnumerator afterHit()
    {
        yield return new WaitForSeconds(0.5f);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (bullet.isEnemy)
            {
                ScoreUlt += 1;
                Hit(bullet.gameObject);
            }
        }
        Destructable destructable = collision.GetComponent<Destructable>();
        if (destructable != null)
        {
            Hit(destructable.gameObject);
        }

        PowerUp powerUp = collision.GetComponent<PowerUp>();
        if (powerUp)
        {
            if (powerUp.ActivateShield)
            {
                ActivateShield();
            }
            if (powerUp.addGuns)
            {
               AddGuns();
            }
            Destroy(powerUp.gameObject);
        }
    }
    public void PlaySFX(int index)
    {
        source.PlayOneShot(HitClip[index]);
    }




}
