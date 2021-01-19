using UnityEngine;
public class VoiceClips : MonoBehaviour
{
    public static AudioClip energyRecoverySound,keyCollectedSound,fullEnergySound;
    static AudioSource audioSrc;
    void Start()
    {
        
        energyRecoverySound = Resources.Load<AudioClip>("energyRecovery");
        keyCollectedSound= Resources.Load<AudioClip>("keyCollected");
        fullEnergySound = Resources.Load<AudioClip>("fullEnergy");

        audioSrc = GetComponent<AudioSource>();
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "energyRecovery":
                audioSrc.PlayOneShot(energyRecoverySound);
                break;

            case "keyCollected":
                audioSrc.PlayOneShot(keyCollectedSound);
                break;

            case "fullEnergy":
                audioSrc.PlayOneShot(fullEnergySound);
                break;
        }

    }
}