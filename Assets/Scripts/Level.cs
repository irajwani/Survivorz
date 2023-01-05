using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    int experience = 0;
    
    [SerializeField] ExperienceBar experienceBar;

    int LEVEL_UP_AT {
        get { 
            // TODO: const
            return level * 1000; 
        }
    }

    private void Start() {
        experienceBar.UpdateExperienceSlider(experience, LEVEL_UP_AT);
        experienceBar.SetLevelText(level);
    }

    public void AddExperience(int amount) {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, LEVEL_UP_AT);
    }

    public void CheckLevelUp() {
        if (experience > LEVEL_UP_AT) {
            experience -= LEVEL_UP_AT; // Reset xp to 0
            level += 1;
            experienceBar.SetLevelText(level);
        }
    }
}
