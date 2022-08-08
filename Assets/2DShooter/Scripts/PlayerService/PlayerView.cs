using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using WeaponSystem;
using Photon.Pun;

namespace PlayerSystem
{
    public class PlayerView : MonoBehaviourPun, IPunObservable
    {
        public PhotonView pv;
        private float speed = 50f;
        [SerializeField]
        private Text playerName;

        [SerializeField]
        private GameObject playerCamera, bulletPrefab, shotPos;

        private Rigidbody2D myBody;
        private Vector3 smoothMovement;
        // Start is called before the first frame update
        void Start()
        {
            myBody = GetComponent<Rigidbody2D>();
            if (pv.IsMine)
            {
                playerName.text = PhotonNetwork.NickName;
                playerCamera.SetActive(true);
                Camera.main.gameObject.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if(pv.IsMine)
            {
                Movement();
                if(Input.GetMouseButtonDown(0))
                {
                    SpawnBullet();
                }
            }


            //else
            //{
            //    ReadMovement();
            //}
        }

        void SpawnBullet()
        {
            GameObject bullet = PhotonNetwork.Instantiate(bulletPrefab.name, shotPos.transform.position, Quaternion.identity, 0);
            bullet.GetComponent<BulletView>().Shoot(Vector3.right);
        }

        void Movement()
        {
            float valH = Input.GetAxis("Horizontal");
            myBody.velocity = new Vector2(valH, myBody.velocity.y);
        }

        //void ReadMovement()
        //{
        //    transform.position = Vector3.Lerp(transform.position, smoothMovement, Time.deltaTime * 5f);
        //}

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            //if(stream.IsWriting)
            //{
            //    stream.SendNext(transform.position);
            //}
            //else if(stream.IsReading)
            //{
            //    smoothMovement = (Vector3)stream.ReceiveNext();
            //}
        }
    }
}