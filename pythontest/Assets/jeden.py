import UnityEngine as unity
def sprawdzanie():
	return "elo"
zmienna = sprawdzanie()

if zmienna == "elo":
    tekst = unity.GameObject.Find("wynik").GetComponent<unity.Text>()
   
else:
    unity.GameObject.Find("wynik").text = "dobrze"