using TMPro;
using UnityEngine;

namespace PythonDefence.UI
{
    public class tutorialContentOrganizer : MonoBehaviour
    {
        private string basicstext;
        private string Liststext;
        private string Ifstext;
        private string Loopstext;
        [SerializeField] private TMP_Text kartkacontent;
        [SerializeField] private GameObject kartkacanvas;
        // Start is called before the first frame update
        void Start()
        {
            basicstext = "The Print command is the simplest way to display a message on the screen or other display device. You can display numbers, text, or the results of various operations there.\r\n\r\nIt consists of two parentheses, in which we put what we want to display.\r\nTo display numbers, quotation marks are not needed.\r\nE.g.: Print(60)\r\nTo print text, we should use single or double quotation marks. Text in quotes is called a string.\r\nE.g.: Print(\"Hello World\")\r\nIf you want to print several strings under each other in a new line, each result should be written separately.\r\nE.g.:\r\nPrint(\"Carrots\")\r\nPrint(\"Potatoes\")\r\nAs you learned earlier, text written in quotes is a string. It is also worth knowing other types of variables, on which the operations performed on them depend.\r\n\r\nString - text in quotes, e.g.: \"fruits\"\r\nIntegers - whole numbers, e.g.: 7\r\nThe result of operations on integers is integers (the only exception is division).\r\nFloat - decimal number, e.g.: 3.0\r\nThe result of operations performed on a float is a float.\r\n\r\nIn Print, we can display the results of various operations.\r\nE.g.: print(2+1)\r\nThe basic operations in Python are:\r\nAddition +\r\nSubtraction -\r\nMultiplication *\r\nDivision /\r\nExponentiation **\r\nFloor division // (we determine how many times a given number fits during the operation, and the result is a whole number)\r\nModulo % (division that returns the remainder of the division)\r\n\r\n! Important information: when dividing integers, we recieve a float type variable !\r\n\r\n\r\nIf you want to perform more than one operation, we use parentheses.\r\nA minus sign before a number makes it negative.\r\nE.g.: print(-4 * (20 / 5))\r\nA variable is assigning a value to a name.\r\nE.g.:\r\nfruit = \"Apple\"\r\nnumber = 3\r\n\r\nA correct variable name may contain letters, numbers, and underscores (_). However, it cannot contain special characters or start the name with a number.\r\nAfter adding a variable, you can use it to perform operations on them.\r\n\r\nE.g.:\r\nX = 1\r\nY = 2\r\nPrint(x)\r\nPrint(y)\r\nPrint(x+y)\r\nPrint(x)\r\nPrint(y)\r\n\r\nTo use some variables entered by the user use the input function.\r\nE.g.:\r\nname = input()\r\nPrint(\"Your name is: \" + name)\r\nWhat you want to display as constant text should be written in quotes. Similarly, you can add text that will be displayed before entering a value (for example, what should be entered).\r\nE.g.: name = input(\"Enter your name: \")\r\n\r\nThe input function always returns a string. If you want it to be an integer, use the conversion function int().\r\nE.g.: number = int(input())\r\nTo convert to a float, we can use the float() function.\r\nE.g.: height = float(input())\r\n\r\nSometimes you also need to convert a number to text, you can use str().\r\nE.g.: x = 4\r\nPrint(\"The number is \" + str(x))";
            Liststext = "Lists - are used to store many elements in one place, list elements are ordered but can be edited and their values may appear more than one time (there can be two elements \"heart\"). List elements are indexed starting from zero [0] and can have any data type (integer, string, boolean).\r\n\r\nExample:\r\nlist = [\"house\", \"grass\", \"tree\", \"leaf\"]\r\nprint(list)\r\nResult: ['house', 'grass', 'tree', 'leaf']\r\n\r\nPrint elements from 2 to 4:\r\nlist = [\"house\", \"grass\", \"tree\", \"leaf\"]\r\nprint(list[2:4])\r\nResult: ['tree', 'leaf']\r\n\r\nChange the value of the 1st element:\r\nlist = [\"house\", \"grass\", \"tree\", \"leaf\"]\r\nlist[1] = \"banana\"\r\nprint(list)\r\nResult: ['house', 'banana', 'tree', 'leaf']\r\n\r\nFunctions with lists:\r\n\r\nlen() - number of elements len(list)\r\nappend() - adds a given element to the end of the list\r\ninsert(index, \"element\") - adds an element at the specified index\r\nremove(\"element\") - removes a given element\r\npop(index) - removes the element at the given index\r\nclear() - clears the entire list, but the list itself remains empty\r\n\r\n\r\n";
            Ifstext = "The \"if\" statement is based on boolean - it returns True or False. It executs a given code if something is true.\r\n\r\nSyntax:\r\nIf condition:\r\n\tStatement\r\n\r\nFor example:\r\nPoints = 60\r\nIf points>=60:\r\nPrint(\"You passed the exam!\")\r\n\r\nThanks to conditional statements, you can check if a given condition is true. If the condition has a value of False, the statement will not be executed.\r\n\r\nImportant note:\r\nIn Python, the space before the statement is essential. If there is no space before the statement, the code will not be executed.\r\n\r\nFor example:\r\nPoints = 60\r\nIf points == 60:\r\n\tPrint(\"Success!\")\r\n~ this code will not be executed because there is no space before the statement. The correct code is:\r\n\r\nPoints = 60\r\nIf points == 60:\r\n\tPrint(\"Success!\")\r\n\r\nWe need to add a little more information to our conditional statements. What if we want to do something if none of the conditional statements work? That's where \"else\" comes in, which works in that way.\r\n\r\nSyntax:\r\nif condition:\r\n\tstatement\r\nelse:\r\n\tstatement\r\n\r\nEach \"if\" statement can only contain one \"else.\" What if we want to add another condition if the first one does not work? We can use \"elif,\" which is a combination of \"else\" and \"if.\" It makes the code more clear and understandable.\r\n\r\nFor example:\r\nNumber= 5\r\nIf number==1:\r\n\tPrint(\"1\")\r\nElif number==2:\r\n\tPrint(\"2\")\r\nElif number==3:\r\n\tPrint(\"3\")\r\nElse:\r\n\tPrint(\"It's a different number\")\r\n\r\nSometimes we want to perform more interesting operations, for which we can use logical operators:\r\n\r\nAnd - an operator that allows us to combine conditions; both conditions must be true for the condition to be true\r\nOr - an operator in which only one condition needs to be true\r\nNot - changes the result of the condition to the opposite, True to False and False to True\r\n\r\nFor example:\r\nPrint(1==1 and 2==2)\r\nPrint(1!=1 or 2==2)\r\n\r\nPrint(not 1==1)";
            Loopstext = "In programming, loops are used to execute a block of code repeatedly until a certain condition is met. In Python, there are several types of loops that you can use to achieve this.\r\n\r\nFor Loop:\r\nThe for loop in Python is used to iterate over a sequence of elements. It takes an iterable object (such as a list or a string) and executes a block of code for each element in the sequence.\r\nSyntax:\r\nfor variable in sequence:\r\n\tcode block\r\n\r\nExample:\r\nfruits = [\"apple\", \"banana\", \"cherry\"]\r\nfor x in fruits:\r\n\tprint(x)\r\n\r\nOutput:\r\napple\r\nbanana\r\ncherry\r\n\r\nWhile Loop:\r\nThe while loop in Python is used to execute a block of code repeatedly as long as a certain condition is true. It keeps looping until the condition becomes false.\r\nSyntax:\r\nwhile condition:\r\ncode block\r\n\r\nExample:\r\ni = 0\r\nwhile i < 5:\r\n\tprint(i)\r\n\ti += 1\r\n\r\nOutput:\r\n0\r\n1\r\n2\r\n3\r\n4\r\n\r\nNested Loops:\r\nA nested loop in Python is a loop inside another loop. It is used to iterate over a sequence of elements that are themselves sequences.\r\nSyntax:\r\nfor variable1 in sequence1:\r\nfor variable2 in sequence2:\r\ncode block\r\n\r\nExample:\r\nadj = [\"red\", \"big\", \"tasty\"]\r\nfruits = [\"apple\", \"banana\", \"cherry\"]\r\nfor x in adj:\r\n\tfor y in fruits:\r\n\t\tprint(x, y)\r\n\r\nOutput:\r\nred apple\r\nred banana\r\nred cherry\r\nbig apple\r\nbig banana\r\nbig cherry\r\ntasty apple\r\ntasty banana\r\ntasty cherry\r\n\r\nRange() Function:\r\nThe range() function in Python is used to generate a sequence of numbers. It can be used in combination with loops to execute a block of code a specific number of times.\r\nSyntax:\r\nfor variable in range(start, stop, step):\r\ncode block\r\n\r\nExample:\r\nfor x in range(2, 10, 2):\r\n\tprint(x)\r\n\r\nOutput:\r\n2\r\n4\r\n6\r\n8\r\n\r\nBreak Statement:\r\nThe break statement in Python is used to exit a loop prematurely. It is used to stop the loop from executing further once a certain condition is met.\r\nSyntax:\r\nwhile condition:\r\n\tif expression:\r\n\t\tbreak\r\n\r\nExample:\r\ni = 0\r\nwhile i < 10:\r\n\tprint(i)\r\n\tif i == 5:\r\n\t\tbreak\r\n\t\ti += 1\r\n\r\nOutput:\r\n0\r\n1\r\n2\r\n3\r\n4\r\n5\r\n\r\nContinue Statement:\r\nThe continue statement in Python is used to skip the current iteration of a loop and move on to the next one. It is used to continue the loop execution without executing the rest of the code block for the current iteration.\r\nSyntax:\r\nwhile condition:\r\nif expression:\r\ncontinue\r\n\r\nExample:\r\ni = 0\r\nwhile i < 10:\r\n\ti += 1\r\n\tif i == 5:\r\n\t\tcontinue\r\n\t\tprint(i)\r\n\r\nOutput:\r\n1\r\n2\r\n3\r\n4\r\n6\r\n7\r\n8\r\n9\r\n10\r\n\r\nElse Statement:\r\nThe else statement in Python is used in conjunction with loops to execute a block of code once the loop has completed its iterations. It is executed only if the loop has not been terminated prematurely using the break statement.\r\nSyntax:\r\nfor variable in sequence:\r\n\tcode block\r\nelse:\r\n\tcode block\r\n\r\nExample:\r\nfruits = [\"apple\", \"banana\", \"cherry\"]\r\nfor x in fruits:\r\n\tprint(x)\r\nelse:\r\n\tprint(\"Finished!\")\r\n\r\nOutput:\r\napple\r\nbanana\r\ncherry";

        }

        // Update is called once per frame
        void Update()
        {

            if (!kartkacanvas.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1.0f;
                gameObject.SetActive(false);
            }
            if (kartkacanvas.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            {
                kartkacanvas.SetActive(false);
            }
        
        }
        public void KartkaBasics()
        {
            kartkacanvas.SetActive(true);
            kartkacontent.text = basicstext;
        }
        public void KartkaLists()
        {
            kartkacanvas.SetActive(true);
            kartkacontent.text = Liststext;
        }
        public void KartkaIfs()
        {
            kartkacanvas.SetActive(true);
            kartkacontent.text = Ifstext;
        }
        public void KartkaLoops()
        {
            kartkacanvas.SetActive(true);
            kartkacontent.text = Loopstext;
        }
    }
}
