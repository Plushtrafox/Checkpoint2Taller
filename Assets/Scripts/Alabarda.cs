using UnityEngine;

public class Alabarda : MonoBehaviour
{
    [SerializeField] Transform player; // Referencia al transform del jugador
    [SerializeField] LayerMask Player;
    [SerializeField] Vector3 offset = new Vector3(20, 0, 0); // Ajusta la direcci�n aqu�
    Quaternion Rotacion; // Declaraci�n sin inicializaci�n aqu�

    private void Awake()
    {
        // Inicializa Rotacion aqu�, cuando transform ya est� disponible
        Rotacion = Quaternion.Euler(0, 94, 264); // Ajusta la rotaci�n aqu�
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto es el jugador usando el LayerMask
        if (((1 << other.gameObject.layer) & Player) != 0)
        {
            // Haz que la alabarda sea hija del jugador
            transform.SetParent(other.transform);

            // Ajusta la posici�n relativa
            transform.localPosition = offset;

            // (Opcional) Ajusta la rotaci�n si es necesario
            transform.localRotation = Rotacion;

            // (Opcional) Desactiva el collider para evitar m�s colisiones
            GetComponent<Collider>().enabled = false;
        }
    }
}


