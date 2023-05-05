using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class BaseStats : MonoBehaviour
    {
        [Range(1, 99)]
        [SerializeField] int startingLevel = 1;
        [SerializeField] CharacterClass characterClass;
       
        public float GetHealth()
        {
            return 100; //progression.GetHealth(characterClass, startingLevel);
        }

    }
