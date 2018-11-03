#Built by: Enrique Alonso Esposito
#09/09/2018
#With Python and TKinter  in PyCharm.


##VERISON: 1.0
##Purpose: To create a program with a GUI. Two text boxes are added. When the user clicks a button the program (so far)
##copies the input from one txtbox into the other (line by line)

##VERSION: 2.0
##Purpose: on the previously done GUI, building a lexer. User inputs some code and the program outputs the tokens line by line.


#Websites visited:
## https://stackoverflow.com/questions/2258097/how-to-copy-data-from-one-tkinter-text-widget-to-another
## https://www.tutorialspoint.com/python/tk_place.htm
## https://www.python-course.eu/tkinter_entry_widgets.php
## http://anh.cs.luc.edu/handsonPythonTutorial/ifstatements.html

#######for the lexer:#######

## https://docs.python.org/2/howto/regex.html
## https://stackoverflow.com/questions/14225608/python-how-to-use-regex-in-an-if-statement


##KNOWN ERRORS/THINGS TO FIX
# Not outputting anything -------------> SOLVED  09/09/2018
# Outputting everything at once -------> SOLVED  09/09/2018
# Incorrect current processing line ---> SOLVED  09/10/2018
# Formatting errors -------------------> SOLVED  09/11/2018
#
# VERSION 2.0 LEXER
#
#
# Keywords are not being printed ------> SOLVED 09/25/2018
# Identifiers not working properly
#
#   Works fine.
#   Tons of formatting errors!.
#
#

##CURRENT EXTRA FEATURES:
# Scrolling bars in order to navigate within the TEXT WIDGETS
# Counter = keeps track of processed lines
# RESET button in order to set program to default and not having to quit and re-launch


#HOW DOES IT WORK:

#       1st  The program waits for a user input and user click on "next line' button
#       2nd  one line is copied into a variable in order to be manipulated
#       3rd  The variable is inspected looking for:
#           -Operators
#           -Separators
#           -keywords
#           -identifiers
#           -literals
#           -comments
#           for each of this categories, when a match is found, we have a list into which we put the matching elements
#       4th matches are then removed from the string in order to look for more tokens
#       5th repeating until end.
#       6th Printing out lists
#       7th Next line and so on...



##importing tkinter module:
import tkinter
import re
from tkinter import *
#############################################################################################################

##Variables
textItself = "Write Here"
manipulatedString = "NULL"
numLines = 0


#Lists.
## For each line to analyze the different keywords will be stored in this lists and then printed out. After printing out
##lists are set to NULL.
identifiers = []
keywords = []       #WORKING
separators = []     #WORKING
operators = []      #WORKING
comments = []       #WORKING
literals = []       #WORKING

##Setting Up the main window ################################################################################
mainWindow = Tk()
mainWindow.geometry("900x600") #mainWindow size
mainWindow.resizable(0,0)
mainWindow.title("HW2: python GUI") #mainWindow title

count = 1

#Setting up the GUI #########################################################################################
InputLabel = Label(mainWindow, text="Input: ")
OutputLabel = Label(mainWindow, text="Output: ")
CurrentLineLabel = Label(mainWindow, text="Current processing line: ")
CurrentNumberLabel = Label(mainWindow, text="No lines analyzed yet")

InputLabel.place(x=10, y=30)
OutputLabel.place(x=450, y=30)
CurrentLineLabel.place(x=50, y=450)
CurrentNumberLabel.place(x=250, y=450)

inputTB = Text(mainWindow, borderwidth=2, relief=SUNKEN)
inputTB.place(x=10, y=50, width=400, height=300)

outputTB = Text(mainWindow, borderwidth=2, relief=SUNKEN)
outputTB.place(x=450, y=50, width=400, height=300)

## SCROLLBARS FOR TEXT WIDGETS ##############################################################################
scrollbar1 = Scrollbar(inputTB)
scrollbar1.pack(side=RIGHT, fill=Y)
scrollbar1.config(command=inputTB.yview)
inputTB.config(yscrollcommand=scrollbar1.set)

scrollbar2 = Scrollbar(outputTB)
scrollbar2.pack(side=RIGHT, fill=Y)
scrollbar2.config(command=outputTB.yview)
outputTB.config(yscrollcommand=scrollbar2.set)


##Setting Up Events for Buttons. #############################################################################

def gettingNumLines():
    lines = inputTB.get("1.0", "end").splitlines()
    totalLines = len(lines)
    return totalLines



def inputIntoVar():
    bound=gettingNumLines()
    global count

    if count <= bound:
        textItself = inputTB.get(str(count) + ".0", str(count) + ".end")

        ###MANIPULATING THE STRING############################################################################

        manipulatedString = textItself

        operators = re.findall('[=+>]', manipulatedString)
        manipulatedString = re.sub('[=+>]', ' ', manipulatedString)

        separators = re.findall('[")(:]', manipulatedString)
        manipulatedString = re.sub('[")(:]', ' ', manipulatedString)

        if re.search('if', manipulatedString):
            keywords.append(re.findall('if', manipulatedString))
            manipulatedString = re.sub('if', ' ', manipulatedString)
        if re.search('else', manipulatedString):
            keywords.append(re.findall('else', manipulatedString))
            manipulatedString = re.sub('else', ' ', manipulatedString)
        if re.search('int', manipulatedString):
            keywords.append(re.findall('int', manipulatedString))
            manipulatedString = re.sub('int', ' ', manipulatedString)

        comments = re.findall('(?://).*', manipulatedString)
        manipulatedString = re.sub('(?://).*', ' ', manipulatedString)

        identifiers = re.findall('[a-z]+ | [a-z]+[0-9] | [0-9]+[a-z] | \w+',manipulatedString)
        manipulatedString = re.sub('[a-z]+ | [a-z]+[0-9] | [0-9]+[a-z] | \w+', ' ', manipulatedString)

        literals = re.findall('\d+', manipulatedString)


        manipulatedString = 'NULL'
        ######################################################################################################

        outputTB.insert(END, 'Keywords: ')
        outputTB.insert(END, str(keywords) + "\n")

        outputTB.insert(END, 'Separators: ')
        outputTB.insert(END, str(separators) + "\n")

        outputTB.insert(END, 'Operators: ')
        outputTB.insert(END, str(operators) + "\n")

        outputTB.insert(END, 'Identifiers: ')
        outputTB.insert(END, str(identifiers) + "\n")

        outputTB.insert(END, 'Literals: ')
        outputTB.insert(END, str(literals) + "\n")

        outputTB.insert(END, 'Comments: ')
        outputTB.insert(END, str(comments) + "\n")

        keywords.clear()

        outputTB.insert(END, "\n")
        count = count + 1
        CurrentNumberLabel.config(text=count-1)

    else:
        outputTB.insert('end', "No more lines to analyze!!" + "\n")


def reset():
    global count
    count = 0
    inputTB.delete('1.0', END)
    outputTB.delete('1.0', END)
    CurrentNumberLabel.config(text="No lines analyzed yet")



##CREATING THE BUTTONS:  #####################################################################################
QuitButton = Button(mainWindow, text='Quit', command=mainWindow.quit)
QuitButton.place(x=800, y=550)

NextLineButton = Button(mainWindow, text='Next Line', command=inputIntoVar)
NextLineButton.place(x=320, y=360)

ResetButton = Button(mainWindow, text='Reset', command=reset)
ResetButton.place(x=700, y=550)


##############################################################################################################
mainWindow.mainloop()
############################

