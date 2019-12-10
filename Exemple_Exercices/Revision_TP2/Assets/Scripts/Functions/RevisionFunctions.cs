using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevisionFunctions : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        int monAdition = Addition(2,7);
        Debug.Log(monAdition);
    }

    // Update is called once per frame
    void Update()
    {
        MaFonction();

        
    }

    // Void étant le type de retour de retour de ma fonction, void étant rien, donc on a pas besoin de return.
    // Un Nom de fonction
    // Les paramètres que ma fonction s'entend a recevoir entre paranthèse.
    private void MaFonction()
    {

    }

    public void MaFonctionPublique()
    {

    }

    // int étant la valeur de retour de notre fonction
    // Addition étant le Nom de la fonction
    // return est nécessaire puisque notre fonction s'attend a retourner un int
    private int Addition(int i_Chiffre1, int i_Chiffre2)
    {
        return i_Chiffre1 + i_Chiffre2;
    }

    public void SetWeapon(Weapon i_Weapon)
    {
        
    }
}