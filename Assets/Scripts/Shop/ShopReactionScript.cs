using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopReactionScript : MonoBehaviour {
	public Text buyText;
	public GameObject[] panels;
	private int currentPanelIndex;
	private GameObject[] frame;
	private GameObject[] selectFrame;
	private GameObject[] selectedFrame;

	private int numberOfCars = 11;
	private int typeOfCar;
	private int[] priceCar = {0, 70, 90, 120, 150, 180, 190,230,250, 270, 300}; // polo, papid, driad, cynic, hipie, papa, ambulance,tresla, country, peep, army
	private int selectedCar = 0;
	
	void Start() {
		PlayerPrefs.SetInt ("car" + 0, 1); // ulozenie vlastnictva prveho auta
		currentPanelIndex = 0;
		frame = new GameObject[numberOfCars];
		selectFrame = new GameObject[numberOfCars];
		selectedFrame = new GameObject[numberOfCars];
		selectedCar = PlayerPrefs.GetInt ("selectedCar", 0);

		for(int i = 0; i < numberOfCars; i++) { // prebehne pole ak su auta true ulozia sa do listu
			if(PlayerPrefs.GetInt("car" + i, 0) == 1) {
				if(selectedCar == i) {
					frame[i] = GameObject.Find("Frame"+ i);
					frame[i].SetActive(false);
					selectFrame[i] = GameObject.Find("SelectFrame"+ i);
					selectFrame[i].SetActive(false);
				    selectedFrame[i] = GameObject.Find("SelectedFrame"+ i);
				    selectedFrame[i].SetActive(true);
				} else {
					frame[i] = GameObject.Find("Frame"+ i);
					frame[i].SetActive(false);
					selectFrame[i] = GameObject.Find("SelectFrame"+ i);
					selectFrame[i].SetActive(true);
					selectedFrame[i] = GameObject.Find("SelectedFrame"+ i);
					selectedFrame[i].SetActive(false);
				}
			} else {
				frame[i] = GameObject.Find("Frame"+ i);
				frame[i].SetActive(true);
				selectFrame[i] = GameObject.Find("SelectFrame"+ i);
				selectFrame[i].SetActive(false);
				selectedFrame[i] = GameObject.Find("SelectedFrame"+ i);
				selectedFrame[i].SetActive(false);
			}
		} 
	}
	
	public void BuyCar(int typeOfCar) {
		buyText.text = "Do you want to buy this car?";
		this.typeOfCar = typeOfCar;
		if (PlayerPrefs.GetInt ("car" + typeOfCar, 0) == 0) {
			ChangePanel(1);
		} else {
			PlayerPrefs.SetInt ("selectedCar", typeOfCar);

			for(int i = 0; i < numberOfCars; i++) {
				if(i == typeOfCar) {
					frame [i].SetActive (false);
					selectFrame [i].SetActive (false);
					selectedFrame [i].SetActive (true);
				} else {
					if (PlayerPrefs.GetInt ("car" + i, 0) == 0) {
						frame [i].SetActive (true);
						selectFrame [i].SetActive (false);
						selectedFrame [i].SetActive (false);
					} else {
						frame [i].SetActive (false);
						selectFrame [i].SetActive (true);
						selectedFrame [i].SetActive (false);
					}
				}
			}
		}
	}

	public void ChangePanel(int panelIndex) {
		panels [currentPanelIndex].SetActive (false);
		currentPanelIndex = panelIndex;
		panels [currentPanelIndex].SetActive (true);
	}

	public void YesBtn() { // potvrdenie nakupu auta
		if (PlayerPrefs.GetInt ("money", 0) >= priceCar [typeOfCar]) {   // zisti ci mas dost penazi
			MoneyScript.RemoveScore (priceCar [typeOfCar]); //odobranie penazi
			PlayerPrefs.SetInt ("money", MoneyScript.GetMoney ()); // ulozenie zostatku penazi
			PlayerPrefs.SetInt ("car" + typeOfCar, 1); // ulozenie vlastnictva auta
			PlayerPrefs.SetInt ("selectedCar", typeOfCar);
			
			frame [typeOfCar].SetActive (false);
			selectFrame [typeOfCar].SetActive (false);
			selectedFrame [typeOfCar].SetActive (true);
			for(int i = 0; i < numberOfCars; i++) {
				if(i == typeOfCar) {
					frame [i].SetActive (false);
					selectFrame [i].SetActive (false);
					selectedFrame [i].SetActive (true);
				} else {
					if (PlayerPrefs.GetInt ("car" + i, 0) == 0) {
						frame [i].SetActive (true);
						selectFrame [i].SetActive (false);
						selectedFrame [i].SetActive (false);
					} else {
						frame [i].SetActive (false);
						selectFrame [i].SetActive (true);
						selectedFrame [i].SetActive (false);
					}
				}
			}

			ChangePanel(0);
		} else {
			buyText.text = " You don't have enough money"; // hlaska ze nemas dost penazi
		}
	}
}

