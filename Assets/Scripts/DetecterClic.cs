using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecterClic : MonoBehaviour
{
    [SerializeField] private Collider colliderPlan;  // Le plan pour d�tecter o� est le clic

    private Rigidbody _rbody;   // Le rigidbody
    private bool _mouvementRequis; // On d�place dans le FixedUpdate
    private Vector3 _prochainePosition; // L'endroit o� on se d�place

    void Start()
    {
        _rbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3? positionClic = DeterminerClic();
            if (positionClic != null)
            {
                _prochainePosition = positionClic.Value;
                Debug.Log("Position finale: " + _prochainePosition.ToString());
                _mouvementRequis = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (_mouvementRequis)
        {
            _rbody.MovePosition(_prochainePosition);
            _mouvementRequis = false;
        }
    }

    /**
     * M�thode qui v�rifie si le clic est sur le plan. Si le clic est � l'ext�rieur
     * alors, on retourne null
     */
    private Vector3? DeterminerClic()
    {
        Vector3 positionSouris = Input.mousePosition;
        Vector3? pointClique = null;

        // Trouver le lien avec la cam�ra
        Ray ray = Camera.main.ScreenPointToRay(positionSouris);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Point de contact: " + hit.point);

            // V�rifier si l'objet touch� est le plan.
            if (hit.collider == colliderPlan)
            {
                // Le vecteur est initialise ici car le clic est sur le plan
                pointClique = hit.point;
            }
        }
        return pointClique;
    }
}
