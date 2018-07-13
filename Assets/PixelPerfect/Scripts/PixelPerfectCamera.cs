using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class PixelPerfectCamera : MonoBehaviour {

	public bool smoothScroll=true;
	public int pixelsPerUnit=16;
	[Range(1,16)]public int pixelZoom=1;

	[HideInInspector]public int checkedPixelZoom;

	float currentWidth, currentHeight;
	float targetHeight {get{return Screen.height;}}
	float targetWidth  {get{return Screen.width ;}}

	void Update () {
		AdjustSize();
	}
	
	Vector3 savePosition, checkPosition, fixedPosition;
	
	void OnPreRender() {
		if (checkPosition!=transform.position) {
			PixelPerfect.requestPostRender=true;
			checkPosition=transform.position;
			savePosition=transform.position;
			if (smoothScroll) {
				fixedPosition=new Vector3(
					Mathf.Floor((transform.position.x)/PixelPerfect.unitsPerPixel*pixelZoom)*PixelPerfect.unitsPerPixel/pixelZoom,
					Mathf.Floor((transform.position.y)/PixelPerfect.unitsPerPixel*pixelZoom)*PixelPerfect.unitsPerPixel/pixelZoom,
					transform.position.z);
				if (pixelZoom%2==0) {
					if (Screen.width%2==0)  {fixedPosition+=Vector3.right*PixelPerfect.unitsPerPixel*0.5f/pixelZoom;}
					if (Screen.height%2==0) {fixedPosition+=Vector3.up*PixelPerfect.unitsPerPixel*0.5f/pixelZoom;}
				} else {
					if (Screen.width%2==0)  {fixedPosition+=Vector3.right*PixelPerfect.unitsPerPixel*0.5f;}
					if (Screen.height%2==0) {fixedPosition+=Vector3.up*PixelPerfect.unitsPerPixel*0.5f;}
				}
				transform.position=fixedPosition;
				checkPosition=transform.position;
			} else {
				fixedPosition=new Vector3(
					Mathf.Floor((transform.position.x)/PixelPerfect.unitsPerPixel)*PixelPerfect.unitsPerPixel,
					Mathf.Floor((transform.position.y)/PixelPerfect.unitsPerPixel)*PixelPerfect.unitsPerPixel,
					transform.position.z);
				if (pixelZoom%2==0) {
					if (Screen.width%2==0)  {fixedPosition+=Vector3.right*PixelPerfect.unitsPerPixel*0.5f/pixelZoom;}
					if (Screen.height%2==0) {fixedPosition+=Vector3.up*PixelPerfect.unitsPerPixel*0.5f/pixelZoom;}
				} else {
					if (Screen.width%2==0)  {fixedPosition+=Vector3.right*PixelPerfect.unitsPerPixel*0.5f;}
					if (Screen.height%2==0) {fixedPosition+=Vector3.up*PixelPerfect.unitsPerPixel*0.5f;}
				}
				transform.position=fixedPosition;
			}
			Debug.DrawLine(transform.position, savePosition);
		} else {
			PixelPerfect.requestPostRender=false;
			transform.position=fixedPosition;
		}
	}
	
	void OnPostRender() {
		if (PixelPerfect.requestPostRender) {
			transform.position=savePosition;
		}
	}
	
	public void AdjustSize() {
		if (targetWidth!=currentWidth || targetHeight!=currentHeight || checkedPixelZoom!=pixelZoom) {
			PixelPerfect.SetPixelPerfect(pixelsPerUnit, pixelZoom);
			GetComponent<Camera>().orthographicSize = (float)(((double)targetHeight / (double)PixelPerfect.pixelsPerUnit / (double)PixelPerfect.pixelScale) * 0.5d);		
			currentWidth=targetWidth;
			currentHeight=targetHeight;
			checkedPixelZoom=pixelZoom;
		}
	}

}