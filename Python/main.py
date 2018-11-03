#Built by: Enrique Alonso Esposito
#09/09/2018
#With Python and TKinter  in PyCharm.


##VERISON: 1.0
##Purpose: To create a program with a GUI. Two text boxes are added. When the user clicks a button the program (so far)
##copies the input from one txtbox into the other (line by line)


#Websites visited:
## https://stackoverflow.com/questions/2258097/how-to-copy-data-from-one-tkinter-text-widget-to-another
## https://www.tutorialspoint.com/python/tk_place.htm
## https://www.python-course.eu/tkinter_entry_widgets.php
## http://anh.cs.luc.edu/handsonPythonTutorial/ifstatements.html


##KNOWN ERRORS/THINGS TO FIX
# Not outputting anything -------------> SOLVED  09/09/2018
# Outputting everything at once -------> SOLVED  09/09/2018
# Incorrect current processing line ---> SOLVED  09/10/2018
# Formatting errors -------------------> SOLVED  09/11/2018
#

##CURRENT EXTRA FEATURES:
# Scrolling bars in order to navigate within the TEXT WIDGETS
# Counter = keeps track of processed lines
# RESET button in order to set program to default and not having to quit and re-launch
#
#


##importing tkinter module:
import tkinter
from tkinter import *
#############################################################################################################

##Variables
textItself = "Write Here"
numLines = 0

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
        #print(textItself)   #tests
        #print(count)        #tests
        outputTB.insert(END, textItself)
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

ResetButton = Button (mainWindow, text='Reset', command=reset)
ResetButton.place(x=700, y=550)


##############################################################################################################
mainWindow.mainloop()
############################

