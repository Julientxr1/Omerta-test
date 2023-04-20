using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPunCallbacks
{
    public int Health;
    public float Speed;
    public int Damage;
    public bool isAlive;

    public Player(int health, float speed, int damage)
    {
        Health = health;
        Speed = speed;
        Damage = damage;
        isAlive = health >= 0;
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            transform.Translate(x, 0 ,z);
        }
    }
}
