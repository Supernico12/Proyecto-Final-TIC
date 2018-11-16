using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Script Para el ataque de la Araña unicamente
public class EnemyDamage : MonoBehaviour
{

    private float distance;

    public float radius;
    public Transform player;
    public float enemyDamage;

    Animator anim;
    CharacterStats playerHealth;
    GameObject playerGo;


    public float maxRange;
    private bool attacking = false;

    public NavMeshAgent agent;

    Transform firePoint;
    Transform lastPos;


    EnemyMovement movement;

    #region Line
    public LineRenderer line;
    public LineRenderer attack;
    public float speed = 60f;
    public bool casted = false;

    float distanceToHit;
    #endregion 
    RaycastHit hit;
    #region Timer
    int time1;
    int time2;
    public int Cooldown;
    Vector3 hitPoint;
    public GameObject linePrefab;
    public GameObject rayPrefab;
    #endregion


    public ParticleSystem effect;

    public float stoppingDistance;
    GameObject head;

    public event System.Action OnAttack;

    // Use this for initialization
    void Start()
    {
        playerGo = PlayerManager.instance.player;
        anim = GetComponent<Animator>();
        firePoint = GameObject.Find("FirePoint").transform;
        player = PlayerManager.instance.playertransform;
        movement = GetComponent<EnemyMovement>();
        head = GameObject.Find("Craneo");
        agent.stoppingDistance = stoppingDistance;
        playerHealth = playerGo.GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {


        distance = Vector3.Distance(firePoint.position, player.position);

        if (distance <= agent.stoppingDistance)
        {
            Attack();
            LookAt();
        }
        else
        {
            movement.canMove = true;
            anim.enabled = true;
            line.SetPosition(0, Vector3.zero);
            line.SetPosition(1, Vector3.zero);
            attack.SetPosition(0, Vector3.zero);
            attack.SetPosition(1, Vector3.zero);

            casted = false;


        }
        if (time2 > Cooldown)
        {
            line.SetPosition(0, Vector3.zero);
            line.SetPosition(1, Vector3.zero);
            attack.SetPosition(0, Vector3.zero);
            attack.SetPosition(1, Vector3.zero);

            casted = false;
            time1 = 0;
            time2 = 0;
            attacking = false;
        }
    }

    public void LookAt()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    public void Attack()
    {
        time1++;
        time2++;
        hitPoint += (player.position - hitPoint) * speed * Time.deltaTime;

        movement.canMove = true;

        anim.enabled = false;


        if (!attacking)
        {

            if (!casted)
            {
                line.SetPosition(0, firePoint.position);
                line.SetPosition(1, hitPoint);

            }
            distanceToHit = Vector3.Distance(line.GetPosition(1), player.position);

            if (distanceToHit < .5f)
            {

                attacking = true;
                CastRay();
            }

        }
    }

    public void CastRay()
    {


        attack.SetPosition(0, firePoint.position);
        attack.SetPosition(1, hitPoint);
        Instantiate(effect, hitPoint, Quaternion.identity);
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, Vector3.zero);
        casted = true;
        if (OnAttack != null)
            OnAttack.Invoke();
        time1 = 0;
        attacking = false;


        Debug.Log("Damaging");
        playerHealth.TakeDamage(enemyDamage);

    }
}