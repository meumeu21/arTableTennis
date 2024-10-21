using UnityEngine;

public class BallMovementScript : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    [Header("UI Elements")]
    [SerializeField] private GameObject rulesUI;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject scoreUI;

    [Header("Player Racquet")]
    [SerializeField] private GameObject PlRac;

    [Header("Ball Anchors")]
    [SerializeField] private GameObject anchorpc;
    [SerializeField] private GameObject anchorpl;

    [Header("Ball Animation")]
    [SerializeField] private GameObject realBall;
    private Animator ballanim;

    [Header("Racquets Animation")]
    [SerializeField] private GameObject racpl;
    [SerializeField] private GameObject racpc;
    private Animator racplanim;
    private Animator racpcanim;

    private float xStart;
    private float yStart;
    private float zStart;
    private float zStart2;

    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    private ScoreScript scsc;

    private static bool opponentAttacking = true;
    private static bool opponentWon;

    private TrailRenderer trail;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();

        scsc = scoreUI.GetComponent<ScoreScript>();

        xStart = anchorpc.transform.position.x;
        yStart = anchorpc.transform.position.y;
        zStart = anchorpc.transform.position.z;
        zStart2 = anchorpl.transform.position.z;

        ballanim = realBall.GetComponent<Animator>();
        racplanim = racpl.GetComponent<Animator>();
        racpcanim = racpc.GetComponent<Animator>();

        trail = realBall.GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (scsc.OnGameEnded())
        {
            EndedGame();
        }
    }

    public void EndedGame()
    {
        trail.Clear();
        trail.enabled = false;
        _rigidbody.isKinematic = true;
        transform.position = new Vector3(xStart, yStart, -1.069f);
        PlRac.transform.position = new Vector3(xStart, PlRac.transform.position.y, PlRac.transform.position.z);
    }

    public void StartingPosition(bool opponentSide)
    {
        _rigidbody.isKinematic = false;
        trail.Clear();
        if (opponentSide)
        {
            transform.position = new Vector3(xStart, yStart, zStart);
            opponentAttacking = true;
        }
        else
        {
            float x = PlRac.transform.position.x;
            transform.position = new Vector3(x, yStart, zStart2);
            opponentAttacking = false;
        }
        trail.enabled = true;
        AddForceMove(opponentSide);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("racop"))
        {
            opponentAttacking = true;
            AddForceMove(opponentAttacking);
        }
        if (other.CompareTag("racpl"))
        {
            opponentAttacking = false;
            AddForceMove(opponentAttacking);
        }


        if (other.CompareTag("plside"))
        {
            opponentWon = true;
            ScoreScript.currentOpponentScore++;
            Debug.Log("plside attacked, opponent:" + ScoreScript.currentOpponentScore);
            trail.Clear();
            StartingPosition(!opponentWon);
        }
        if (other.CompareTag("opside") || other.CompareTag("opsideb"))
        {
            opponentWon = false;
            ScoreScript.currentPlayerScore++;
            Debug.Log("opside attacked, player:" + ScoreScript.currentPlayerScore);
            trail.Clear();
            StartingPosition(!opponentWon);
        }

        if (other.CompareTag("plsideb"))
        {
            if (opponentAttacking)
            {
                opponentWon = false;
                ScoreScript.currentPlayerScore++;
                Debug.Log("plsideb attacked, player:" + ScoreScript.currentPlayerScore);
            }
            else
            {
                opponentWon = true;
                ScoreScript.currentOpponentScore++;
                Debug.Log("plsideb attacked, opponent:" + ScoreScript.currentOpponentScore);
            }
            trail.Clear();
            StartingPosition(!opponentWon);
        }
    }

    public void AddForceMove(bool opponentSide)
    {
        _rigidbody.isKinematic = true;
        float x = transform.position.x;
        float z = opponentSide ? Random.Range(-0.0144f, -0.014f) : Random.Range(0.014f, 0.0144f);
        if (opponentSide)
        {
            x = Random.value < 0.5f ? Random.Range(-0.005f, -0.001f) : Random.Range(0.001f, 0.005f);
        }
        else
        {
            x = 0.16f - x < x + 0.16f ? Random.Range(-0.005f, -0.001f) : Random.Range(0.001f, 0.005f);
        }
        Vector3 direction = new Vector3(x, 0, z);
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(direction * this.speed, ForceMode.Impulse);
        Debug.Log(direction * 1000);
        if (opponentSide) { racpcanim.Play("racpcanim"); }
        else { racplanim.Play("racplanim"); }
        ballanim.Play("ballanim");
        _audioSource.Play();
    }
}
