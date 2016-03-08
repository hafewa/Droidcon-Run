//This is a very basic swipe detection class, that invokes unity events upon detection
//so we can set up the events in the editor.
using UnityEngine;  
using UnityEngine.Events;

  
public class SwipeControlsCS : MonoBehaviour {  
	public enum SwipeDirection   
	{  
		Null = 0, 
		Duck = 1, 
		Jump = 2, 
		Right = 3, 
		Left = 4,
		Click = 5
	}  
	public UnityEngine.Events.UnityEvent OnSwipeDuck = new UnityEngine.Events.UnityEvent();
	public UnityEngine.Events.UnityEvent OnSwipeJump = new UnityEngine.Events.UnityEvent();
	public UnityEngine.Events.UnityEvent OnSwipeRight = new UnityEngine.Events.UnityEvent();
	public UnityEngine.Events.UnityEvent OnSwipeLeft = new UnityEngine.Events.UnityEvent();
	public UnityEngine.Events.UnityEvent OnClick = new UnityEngine.Events.UnityEvent();

	private float fSensitivity = 15;  
  	private SwipeDirection sSwipeDirection;               
	private float fInitialX;  
	private float fInitialY;  
	private float fFinalX;  
	private float fFinalY;  
	private int iTouchStateFlag;   
	private float inputX;                   
	private float inputY;                   
	private float slope;   
	private float precision = 2f;
	private float fDistance;               
 
	void Start ()  
	{  
		fInitialX = 0.0f;  
		fInitialY = 0.0f;  
		fFinalX = 0.0f;  
		fFinalY = 0.0f;  
		inputX = 0.0f;  
		inputY = 0.0f;  
		iTouchStateFlag = 0;  
		sSwipeDirection = SwipeDirection.Null;  
	}  
	void Update()  
	{  
		if (iTouchStateFlag == 0 && Input.GetMouseButtonDown(0))  
		{            
			fInitialX = Input.mousePosition.x;       
			fInitialY = Input.mousePosition.y;     
			sSwipeDirection = SwipeDirection.Null;  
			iTouchStateFlag = 1;  
		}            
		if (iTouchStateFlag == 1)      
		{  
			fFinalX = Input.mousePosition.x;  
			fFinalY = Input.mousePosition.y;  
			sSwipeDirection = swipeDirection();     
			if (sSwipeDirection != SwipeDirection.Null && sSwipeDirection != SwipeDirection.Click)  {
				iTouchStateFlag = 2;  

				switch (getSwipeDirection) {
				case SwipeDirection.Duck:
					OnSwipeDuck.Invoke();
					break;
				case SwipeDirection.Jump:
					OnSwipeJump.Invoke();
					break;
				case SwipeDirection.Left:
					OnSwipeLeft.Invoke();
					break;
				case SwipeDirection.Right:
					OnSwipeRight.Invoke();
					break;
			 
				}
			}
			 

		}            
		if (iTouchStateFlag == 2 || Input.GetMouseButtonUp(0))     //state 3 of swipe control  
		{  
 			iTouchStateFlag = 0;  
			fFinalX = Input.mousePosition.x;  
			fFinalY = Input.mousePosition.y;  
			if(getSwipeDirection==SwipeDirection.Click){
				OnClick.Invoke();
			}
		} 


	}  
 
	private SwipeDirection swipeDirection()  
	{  
 		inputX = fFinalX - fInitialX;  
		inputY = fFinalY - fInitialY;  
		slope = inputY / inputX;  
 		fDistance = Mathf.Sqrt( Mathf.Pow((fFinalY-fInitialY), 2) + Mathf.Pow((fFinalX-fInitialX), 2) );  
		if (fDistance <= (Screen.width / fSensitivity)) {
			return SwipeDirection.Click;  

		}
		if (inputX >= 0 && inputY > 0 && slope > precision)   
		{            
			return SwipeDirection.Jump;  
		}  
		else if (inputX <= 0 && inputY > 0 && slope < -precision) 
		{  
			return SwipeDirection.Jump;  
		}  
		else if (inputX > 0 && inputY >= 0 && slope < precision && slope >= 0)
		{  
			return SwipeDirection.Right;  
		}  
		else if (inputX > 0 && inputY <= 0 && slope > -precision && slope <= 0)   
		{  
			return SwipeDirection.Right;  
		}  
		else if (inputX < 0 && inputY >= 0 && slope > -precision && slope <= 0) 
		{  
			return SwipeDirection.Left;  
		}  
		else if (inputX < 0 && inputY <= 0 && slope >= 0 && slope < precision)
		{  
			return SwipeDirection.Left;  
		}  
		else if (inputX >= 0 && inputY < 0 && slope < -precision) 
		{  
			return SwipeDirection.Duck;  
		}  
		else if (inputX <= 0 && inputY < 0 && slope > precision) 
		{  
			return SwipeDirection.Duck;  
		} 
		return SwipeDirection.Null;       




	} 
	public SwipeDirection getSwipeDirection{ 
		get
		{  
			if (sSwipeDirection != SwipeDirection.Null)  
			{  
				var etempSwipeDirection = sSwipeDirection;  
				sSwipeDirection = SwipeDirection.Null;  
				return etempSwipeDirection;  
			}  
			else  
				return SwipeDirection.Null;  
		}  
	}
}  