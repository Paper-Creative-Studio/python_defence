list = ['supports', 'minecart', 'pickaxe', 'shovel']list.append("tracks")
correct = ['supports', 'minecart', 'pickaxe', 'shovel', 'tracks']
if all(value in list for value in correct):
	print("List contains all needed materials")
else:
	print("List does not contains all needed materials")