using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerController
{
    public class Cartel : MonoBehaviour
    {
        public GameObject informacion;

        public bool informacionHabilitada;

        public LayerMask personaje;

        // Start is called before the first frame update
        void Start()
        {
            informacion.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

            informacionHabilitada = Physics2D.OverlapCircle(this.transform.position, 2f, personaje);

            if (informacionHabilitada == true)
            {
                informacion.gameObject.SetActive(true);
            }
            if (informacionHabilitada == false)
            {
                informacion.gameObject.SetActive(false);
            }
        }
    }
}
