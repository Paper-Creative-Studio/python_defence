extends Panel

var kod: String;

func _ready():
	pass # Replace with function body.



func _on_Button_pressed():
	var file = File.new()
	file.open("pyton.py", File.WRITE)
	file.store_string($TextEdit.text)
	file.close()
	var stdout = []
	var exit = OS.execute("python3", ["pyton.py"], true, stdout)
	if exit == OK:
		print(stdout)
