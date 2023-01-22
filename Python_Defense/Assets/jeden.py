import UnityEngine as unity
def sprawdzanie():
	return "elo"
zmienna = sprawdzanie()

if zmienna == "elo":
    tekst = unity.GameObject.Find("wynik").GetComponent<unity.Text>()
    tekst.unity.text = "dobrze"
else:
    unity.GameObject.Find("wynik").text = "dobrze"