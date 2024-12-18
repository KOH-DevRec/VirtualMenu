using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHand : MonoBehaviour
{
    [SerializeField]
    private OVRHand.Hand HandType = OVRHand.Hand.HandLeft;

    [SerializeField]
    private OVRSkeleton skeleton;

    private TextMesh text = null;
    private OVRHand hand = null;

    public bool pinchingT;
    public bool pinchingI;
    public bool pinchingM;
    public bool pinchingR;
    public bool pinchingP;
    public int pinchingNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<OVRHand>();
    }

    private void Update()
    {
        PinchingCheck();
    }


    void PinchingCheck()
    {
        pinchingT = hand.GetFingerIsPinching(OVRHand.HandFinger.Thumb);
        pinchingI = hand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        pinchingM = hand.GetFingerIsPinching(OVRHand.HandFinger.Middle);
        pinchingR = hand.GetFingerIsPinching(OVRHand.HandFinger.Ring);
        pinchingP = hand.GetFingerIsPinching(OVRHand.HandFinger.Pinky);

        if (pinchingI == true)
        {
            Debug.Log("IndexPinching");
            pinchingNum = 1;
        }
        else if (pinchingM == true)
        {
            Debug.Log("MiddlePinching");
            pinchingNum = 2;
        }
        else if (pinchingR == true)
        {
            Debug.Log("RingPinching");
            pinchingNum = 3;
        }
        else if (pinchingP == true)
        {
            Debug.Log("PinkyPinching");
            pinchingNum = 4;
        }
        else
        {
            pinchingNum = 0;
        }
    }


}
