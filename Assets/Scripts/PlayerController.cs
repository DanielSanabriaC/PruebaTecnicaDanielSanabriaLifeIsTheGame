using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance; //Singleton

    public float moveSpeed,gravityModifier;
    public CharacterController charController;

    private Vector3 moveInput;

    public Transform camTransform;
    public float mouseSensitivity = 2;
    public bool invertX;
    public bool invertY;



    //public GameObject bullet;
    public Transform firePoint;
    public Gun activeGun;
    public List<Gun> allGuns = new List<Gun>();
    public int currentGun;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        currentGun--;
        SwitchGun();
        
        
    }

    // Update is called once per frame
    void Update()
    {

        float yStore = moveInput.y;

        Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 horiMove = transform.right * Input.GetAxis("Horizontal");


        moveInput = horiMove + vertMove;
        moveInput.Normalize();
        moveInput = moveInput * moveSpeed;


        moveInput.y = yStore;
        moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;


       

        if (charController.isGrounded)
        {
            moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
        }


        charController.Move(moveInput * Time.deltaTime);

        // control camera rotation
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
        if (invertX)
        {
            mouseInput.x = -mouseInput.x;
        }
        if (invertY)
        {
            mouseInput.y = -mouseInput.y;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        camTransform.rotation = Quaternion.Euler(camTransform.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));

        // Handle Shooting
        //single shots
        if (Input.GetMouseButtonDown(0) && activeGun.fireCounter <= 0)
        {
            RaycastHit hit;

            if(Physics.Raycast(camTransform.position,camTransform.forward, out hit,50f))
            {
                if(Vector3.Distance(camTransform.position, hit.point) > 2f)
                {
                    firePoint.LookAt(hit.point);
                }
               
            }
            else
            {
                firePoint.LookAt(camTransform.position + (camTransform.forward * 30f));
            }


            
            FireShot();
        }

        // repeating shootings
        if (Input.GetMouseButton(0) && activeGun.canAutoFire)
        {
            if(activeGun.fireCounter <= 0)
            {
                FireShot();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchGun();
        }

    }

    public void FireShot()
    {

        if (activeGun.currentAmo > 0)
        {

            activeGun.currentAmo--;
            Instantiate(activeGun.bullet, firePoint.position, firePoint.rotation);

            activeGun.fireCounter = activeGun.fireRate;
            UIController.instance.ammoText.text = "Ammo: " + activeGun.currentAmo;
        }
    }

    public void SwitchGun()
    {
        activeGun.gameObject.SetActive(false);

        if(currentGun >= allGuns.Count)
        {
            currentGun = 0;
        }

        currentGun++;

        activeGun = allGuns[currentGun];
        activeGun.gameObject.SetActive(true);
        UIController.instance.ammoText.text = "Ammo: " + activeGun.currentAmo;
    }
}
