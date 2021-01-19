using UnityEngine;

public class SoundManager : MonoBehaviour
{
  
    public static AudioClip playerJumpSound,teleportSound, energyRecoverySound;
    static AudioSource audioSrc;
    void Start()
    {
        playerJumpSound = Resources.Load<AudioClip>("playerJump");
        teleportSound = Resources.Load<AudioClip>("teleport");
        energyRecoverySound = Resources.Load<AudioClip>("energyRecovery");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "playerJump":
                audioSrc.PlayOneShot(playerJumpSound );
                break;

            case "teleport":
                audioSrc.PlayOneShot(teleportSound);
                break;

         

        }

    }
}
