using UnityEngine;

public class UnityBaseFonctions : MonoBehaviour
{
    // Le Awake est caller dès la creation de l'objet et ce une seule fois.
    // On veut donc initialiser nos variables ou faire nos GetComponents ici pour s'assurer d'avoir nos références directement a la creation
    void Awake()
    {
        
    }

    // Le start est caller une fois a la fin du premier frame de creation de l'Objet
    void Start()
    {
        
    }

    // L'Update est caller a tout les frames du Computer.
    // Donc plus le CPU va vite, plus de fois je vais passé dans la fonction Update.
    // Donc le nombre de fois que Update est caller est variables selon le FPS ( Frame per seconds )
    void Update()
    {
        //Time.deltaTime;

        // Le temps qui s'est passé entre 2 frames.
        // Entre mon frame en cours et le frame du dernier Update

        // On va utiliser le Time.deltaTime pour s'assurer de l'incrémentation du valeur en 1secondes.

        float temps = 0f;
        temps += 1f; // Ma varaible temps sera incrémenter de 1f a tout les frames. Donc dans une secondes je ne sais pas qu'elle sera la valeur de temps, puisque mon FPS est variable.
        temps += 1f * Time.deltaTime; // Ma variables temps sera incrémenter de 1f * Time.deltaTime a tout les frames. Donc je m'assure que ma variable aura augmenter de 1f après 1 seconde.
    }

    // FixedUpdate caller a tout les interval régulier.
    // Donc de Base dans Edit-Project Settings-Time, on a la valeur Fixed Timestep qui représente la valeur fixe en seconds entre chaque frame de Fixed Updated ( 0.02 de base, donc 50x par secondes )
    // Pourquoi on utilise FixedUpdate, pour la PHYSIQUE, pour s'assurer que le nombre de check en physique est constant, peu importe le frame rate.
    void FixedUpdate()
    {
        Debug.Log(Time.fixedDeltaTime);
        // fixedDeltaTime sera toujours la même valeur que l'on a mis dans Edit-Project Settings-Time, Donc 0.02 de base.
    }
}
