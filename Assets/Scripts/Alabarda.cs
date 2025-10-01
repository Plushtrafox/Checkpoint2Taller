using UnityEngine;

public class Alabarda : MonoBehaviour
{
    [SerializeField] Transform player; // Referencia al transform del jugador
    [SerializeField] LayerMask Player;
    [SerializeField] Vector3 offset = new Vector3(20, 0, 0); // Ajusta la dirección aquí
    Quaternion Rotacion; // Declaración sin inicialización aquí

    private void Awake()
    {
        // Inicializa Rotacion aquí, cuando transform ya está disponible
        Rotacion = Quaternion.Euler(0, 94, 264); // Ajusta la rotación aquí
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto es el jugador usando el LayerMask
        if (((1 << other.gameObject.layer) & Player) != 0)
        {
            // Haz que la alabarda sea hija del jugador
            transform.SetParent(other.transform);

            // Ajusta la posición relativa
            transform.localPosition = offset;

            // (Opcional) Ajusta la rotación si es necesario
            transform.localRotation = Rotacion;

            // (Opcional) Desactiva el collider para evitar más colisiones
            GetComponent<Collider>().enabled = false;
        }
    }
}


