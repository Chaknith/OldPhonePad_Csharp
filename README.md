# OldPhonePad!

## Question
Here is an old phone keypad with alphabetical letters, a backspace key, and a sendbutton. Each button has a number to identify it and pressing a button multiple times will cycle through the letters on it allowing each button to represent more than one letter.

![image](https://user-images.githubusercontent.com/101816109/189865394-2adb8c64-3292-46cb-a27b-51a13db6061e.png)

|          |          |           |            |
| ---      | ---      | ---       | ---        |
| 1 ==> &  | 11 ==> ' | 111 ==> ( |
| 2 ==> A  | 22 ==> B | 222 ==> C |
| 3 ==> D  | 33 ==> E | 333 ==> F |
| 4 ==> G  | 44 ==> H | 444 ==> I |
| 5 ==> J  | 55 ==> K | 555 ==> L |
| 6 ==> M  | 66 ==> N | 666 ==> O |
| 7 ==> P  | 77 ==> Q | 777 ==> R | 7777 ==> S |
| 8 ==> T  | 88 ==> U | 888 ==> V |
| 9 ==> W  | 99 ==> X | 999 ==> Y | 9999 ==> Z |
| * ==> delete  | 0 ==> space | # ==> send |

For example, pressing 2 once will return ‘A’ but pressing twice in succession will return ‘B’. You must pause for a second in order to type two characters from the same button after each other: “222 2 22” -> “CAB”. Assume that a send “#” will always be included at the end of every input.

###### Example
```python
OldPhonePad("33#")  # => output: E
OldPhonePad("227*#")  # => output: B
OldPhonePad("4433555 555666#")  # => output: HELLO
OldPhonePad("8 88777444666*664#") # => output: ????
```
###### Task
Design a class of method that will turn any input to OldPhonePad into the correct output.
## Inputs
Here is the varieties of possible input.
###### Test inputs
```python
["33#", "227*#", "4433555 555666#", "8 88777444666*664#", "4433555 555666********#", "#", "*********#", "*4433555 555666#", "*****4433555999*****4433555 555666096667775553#"]
```
###### Outputs
```
E
B
HELLO
TURING
 (blankspace)
 (blankspace)
 (blankspace)
HELLO
HELLO WORLD
```
## Solution
The solution is written in python. [Here](https://www.online-python.com/p0J1xiWQjh) is the web IDE for solution.
```python
class Solution:
    def OldPhonePad(self, data):
        """
        :type data: str
        :return type: str
        """
        lookUpTable = [[" "],
                       ["&", "'", "("], ["A", "B", "C"], ["D", "E", "F"],
                       ["G", "H", "I"], ["J", "K", "L"], ["M", "N", "O"],
                       ["P", "Q", "R", "S"], ["T", "U", "V"], ["W", "X", "Y", "Z"]]

        # Handle empty input
        if data[0] == "#":
            return ""

        # Handle none "#" ending input
        if data[-1] != "#":
            data += "#"

        previous = data[0]
        count = 0
        finalStr = ""
        pointer = 1

        while pointer < len(data):
            if data[pointer] == "*" and previous == "*":
                finalStr = finalStr[:-1:]
            elif data[pointer] == "*":
                previous = data[pointer+1]
                count = 0
                pointer += 1
            elif data[pointer] == previous:
                count += 1
                previous = data[pointer]
            else:
                if previous != " " and previous != "*":
                    finalStr += lookUpTable[int(previous)][count]
                count = 0
                previous = data[pointer]
            pointer += 1

        return finalStr

p1 = Solution()

print(p1.OldPhonePad("33#"))
print(p1.OldPhonePad("227*#"))
print(p1.OldPhonePad("4433555 555666#"))
print(p1.OldPhonePad("8 88777444666*664#"))
```

For convenience the python code below can be used to generate custom input for the solution. It takes alphabetical character and some symbol.
````*```` symbol is to simulate backspace in keyboard. Use it after the character you want to delete. <br />
###### Example:
```
hely*lo ==> 4433555999*555666#
```
Generate for the word hello. ````*```` is being used to delete y character
###### Generate input
[Here](https://www.online-python.com/5Ka4pYClUJ) is the web IDE for Generate input.
```python
class Question:
    def GenerateInput(self, data):
        """
        :type data: str
        :return type: str
        """
        lookUpDict = {"*": "*",
                      " ": "0",
                      "&": "1", "'": "11", "(": "111",
                      "A": "2", "B": "22", "C": "222",
                      "D": "3", "E": "33", "F": "333",
                      "G": "4", "H": "44", "I": "444",
                      "J": "5", "K": "55", "L": "555",
                      "M": "6", "N": "66", "O": "666",
                      "P": "7", "Q": "77", "R": "777", "S": "7777",
                      "T": "8", "U": "88", "V": "888",
                      "W": "9", "X": "99", "Y": "999", "Z": "9999"}

        # Handle empty input
        if not data:
            return "#"

        # Handle first input as a "*"
        if data[0] == "*":
            finalStr = "*"
        else:
            finalStr = lookUpDict[data[0].upper()]

        # Store input that is not in the old phone pad
        notInDict = []

        for ele in data[1::]:
            try:
                if ele == "*":
                    finalStr += "*"
                else:
                    ele = ele.upper()
                    if finalStr[-1] in lookUpDict[ele]:
                        finalStr += " " + lookUpDict[ele]
                    else:
                        finalStr += lookUpDict[ele]
            except:
                if ele not in notInDict:
                    notInDict.append(ele)
        if notInDict:
            print("{} character is not in the old phone pad. Therefore it is being removed from the output string.".format(notInDict))

        return finalStr + "#"


p1 = Question()

print(p1.GenerateInput("hello"))
```
