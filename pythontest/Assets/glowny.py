import UnityEngine as unity
from jeden import zmienna

if zmienna == "elo":
    tekst = unity.GameObject.Find("wynik")
    tekst.text = "dobrze"
else:
    tekst = unity.GameObject.Find("wynik")
    tekst.text = "zle"