
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraMovement : MonoBehaviour
{
    // Update is called once per frame,
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform frogTransform;
    
    private float mouseY;
    private float mouseX;
    [SerializeField] private float camSens = 1;
    [SerializeField] private float camSensY = 1;//How sensitive it with mouse
    private Vector3 lastMouse; //kind of in the middle of the screen, rather than at the top (play)
    
    void Update ()
    {
        mouseY = Input.GetAxis("Mouse X");
        mouseX = Input.GetAxis("Mouse Y");

        Vector3 cameraAngles = cameraTransform.eulerAngles;
        Vector3 frogAngles = frogTransform.eulerAngles;
        frogTransform.Rotate(Vector3.up*100*mouseY*Time.deltaTime * camSens);
        
        float control = (cameraAngles + Vector3.up * 100 * mouseY * Time.deltaTime).x;
        if (control <= 340f && control >= 321) //UPPER THAN 40
        {
            cameraTransform.eulerAngles = new Vector3(340f, frogAngles.y, frogAngles.z);
        }
        if (control <= 320f && (cameraAngles + Vector3.up * 100 * mouseY * Time.deltaTime).x >= 40) //LOWER THAN -40
        {
           cameraTransform.eulerAngles = new Vector3(40, frogAngles.y,  frogAngles.z);
        } 
        else //NO BOUNDARY
        {
            cameraTransform.Rotate(-Vector3.right * 100 * mouseX * Time.deltaTime * camSensY);

        }
        
        Cursor.lockState = CursorLockMode.Locked;



    }

}
