using UnityEngine;

public class Disparo : MonoBehaviour
{
    [Header("Configuración de Disparo")]
    public GameObject prefabBala;
    public Transform puntoDisparo;
    public float velocidadBala = 15f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            DispararBala();
        }
    }

    void DispararBala()
    {

        if (animator != null)
        {
            animator.SetTrigger("Disparar");
        }


        GameObject balaNueva = Instantiate(prefabBala, puntoDisparo.position, Quaternion.identity);
        Rigidbody2D rbBala = balaNueva.GetComponent<Rigidbody2D>();

        float direccion = transform.localScale.x > 0 ? 1f : -1f;
        rbBala.linearVelocity = new Vector2(velocidadBala * direccion, 0);
        balaNueva.transform.localScale = new Vector3(direccion, 1, 1);

        Destroy(balaNueva, 2f);
    }
}