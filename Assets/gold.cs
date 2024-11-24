using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold : MonoBehaviour
{
    public AudioClip coinSound;  // Âm thanh của coin
    public GameObject audioPlayerPrefab;  // Prefab chứa AudioSource

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Tạo một đối tượng âm thanh tạm thời để phát âm thanh
            GameObject audioPlayer = Instantiate(audioPlayerPrefab, transform.position, Quaternion.identity);
            AudioSource audioSource = audioPlayer.GetComponent<AudioSource>();
            audioSource.PlayOneShot(coinSound);

            // Hủy đối tượng coin ngay lập tức
            Destroy(gameObject);

            // Tự động hủy đối tượng âm thanh sau khi phát xong
            Destroy(audioPlayer, coinSound.length);
        }
    }
}
