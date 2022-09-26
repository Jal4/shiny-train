using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionaryWalls : MonoBehaviour
{
    public float alpha;
    public float fadeTimer = 2.5f;
    public bool wallHasBeentHit;

    public Material illusionaryWallMaterial;
    public MeshRenderer meshRenderer;
    public BoxCollider wallCollider;


    //public AudioSource audioSource;
    //public AudioClip illusionaryWallSound;

    private void Awake()
    {
        illusionaryWallMaterial = Instantiate(illusionaryWallMaterial);
        meshRenderer.material = illusionaryWallMaterial;
    }

    public void FadeIllusionaryWall()
    {
        alpha = meshRenderer.material.color.a;
        alpha = (alpha - fadeTimer) / Time.deltaTime;
        Color fadedWallColor = new Color(1, 1, 1, alpha);
        meshRenderer.material.color = fadedWallColor;

        if (wallCollider.enabled)
        {
            wallCollider.enabled = false;

            //audioSource.PlayOneShot(illusionaryWallSound);
        }

        if (alpha <= 0)
        {
            Destroy(this);
        }
    }
}
