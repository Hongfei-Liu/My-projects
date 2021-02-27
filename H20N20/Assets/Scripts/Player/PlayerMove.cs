using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Vector2 move = new Vector2();
    [Range(1f, 6f)] [Tooltip("速度移动区间")] [SerializeField] public float speed = 4;
    [Range(0f, 0.5f)][SerializeField] private float smooting = 0.1f;
    private Rigidbody2D rigid;
    private Vector3 zeroVelocity = Vector3.zero;
    [SerializeField] private int hp = 20;
    [SerializeField] public bool IsDeath = false;

    public HealthBar healthBar;
    public int currentHP;

    public GameObject deadpanel;
    public GameObject hpPanel;
    private GameManager manager;

    public GameObject skill;

    public Slider slider;

    public bullet bullet;

    public void OnMove(InputAction.CallbackContext context)//移动控制
    {
        move = context.ReadValue<Vector2>();        
    }
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance;
        rigid = GetComponent<Rigidbody2D>();
        healthBar = GetComponent<HealthBar>();
        slider.maxValue = hp;
        // healthBar.SetMax(hp); 
        hpPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3();
        position.x = move.x * speed;
        position.y = move.y * speed;
        rigid.velocity = Vector3.SmoothDamp(rigid.velocity, position, ref zeroVelocity, smooting);
        slider.value = hp;
    }  

    public void ISDeath()
    {
        IsDeath = true;
    }

    public void BeHit()
    {
        hp -= 1;
       // healthBar.SetHealth(currentHP);
        if (hp <= 0)
        {
            ISDeath();
            Destroy(this.gameObject);
            Time.timeScale = 0f;
            deadpanel.SetActive(true);
            hpPanel.SetActive(false);
            skill.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Hp+"))
        {
            //Debug.Log("hit" + other.name);
            if(hp < 20)
            {
                hp++;
            }
            else if (hp >= 20)
            {
                hp = 20;
            }
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Speed+"))
        {
            //Debug.Log("hit" + other.name);
            if (speed < 6f)
            {
                speed += speed * (0.3f);
            }
            if (speed >= 6f)
            {
                speed = 6f;
            }
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Speed-"))
        {
            //Debug.Log("hit" + other.name);
            if (speed > 1f)
            {
                speed -= speed * (0.3f);
            }
            else if (speed <= 1f)
            {
                speed = 1f;
            }
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Bullet+"))
        {
            Debug.Log("hit" + other.name);
            if (bullet.speed > 7f)
            {
                bullet.speed += bullet.speed * (0.2f);
            }
            else if (bullet.speed >= 10f)
            {
                bullet.speed = 10f;
            }
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Bullet-"))
        {
            //Debug.Log("hit" + other.name);
            if (bullet.speed < 10f)
            {
                bullet.speed -= bullet.speed * (0.5f);
            }
            else if (speed <= 6f)
            {
                bullet.speed = 6f;
            }
            Destroy(other.gameObject);
        }
    }
}
