using TMPro;
using UnityEngine;

public class MessegeBoxFoarmPrefab : MonoBehaviour
{
    public GameObject BoxFoarmPrefab;

    public float BoxOffset;

    public Vector2 ScreenSize = new(1920,1080);

    public RectTransform BoxTransform;

    public RectTransform ButtonTransform;
    
    public TextMeshProUGUI BoxHeader;
    public TextMeshProUGUI BoxMessege;
  
}
