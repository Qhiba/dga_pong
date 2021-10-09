using UnityEngine;

public class BallControl : MonoBehaviour
{
    //Rigidbody2D Bola
    private Rigidbody2D rigidbody2D;

    //Besarnya gaya awal yang diberikan untuk mendorong bola
    //public float xInitialForce;
    //public float yInitialForce;

    //Titik asal lintasan bola saat ini
    private Vector2 trajectoryOrigin;

    //Variabel untuk mengatur kecepatan pada bola
    [SerializeField] private float speed;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        //Mulai game
        RestartGame();

        trajectoryOrigin = transform.position;
    }

    private void ResetBall()
    {
        //Reset posisi menjadi (0,0);
        transform.position = Vector2.zero;

        //Reset kecepatan menjadi (0,0);
        rigidbody2D.velocity = Vector2.zero;
    }

    private void PushBall()
    {
        /*
        //Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce;
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        //Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
        float randomDirection = Random.Range(0, 2);

        //Jika nilainya di bawah 1, bola bergerak ke kiri.
        //Jika tidak, bola bergerak ke kanan.
        if (randomDirection < 1.0f)
        {
            //Gunakan gaya untuk menggerakan bola ini.
            rigidbody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rigidbody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
        */
          
        //Modifikasi kode untuk submission
        //Variabel untuk menentukan y dan x disederhanakan.
        float yRandomDirection = Random.Range(-1.0f, 1.0f);
        float xRandomDirection = Random.value < 0.5f ? -1.0f : 1.0f;

        //Menggunakan method Vector2.normalized untuk menjadikan magnitude (panjang vektor) menjadi 1.
        //Speed sebagai variabel yang mengatur seberapa cepat bola bergerak.
        rigidbody2D.AddForce(new Vector2(xRandomDirection, yRandomDirection).normalized * speed);        
    }

    private void RestartGame()
    {
        //Kembalikan bola ke posisi semua
        ResetBall();

        //setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", 2);
    }

    //Ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    //Untuk mengakses informasi titik asal lintasan
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
