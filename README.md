# HomeCodingTest
Boggle Board Game

# Quick Start

To start game, Follow Below Steps:

1. Open MainScene and Press Play button of Unity Editor.
2. This will Open Input Panel. Fill All the fields (Direaction to fill data Given After setps).
3. Press Submit button.
4. Now you'll see Output screen, where Boggle Board would have generated as per the Given Input. Click on Get Words Button to get the Output.
5. Output area will have Count of the Words along with the comma separated list of words.


*** In Order to make it easy for the user, 2 sample datas are also added in the application. In order to get them, Click on Sample1 or Sample2 button in Input Panel to pre-fill the input fields with sample data.

DIREACTION FOR INPUT DATA:

1. Board Dimesion: Enter only numbers. No Alphabets.
2. Board Data: Enter comma separated Alphabets for each box of the boggle board. (Please see sample data)
3. Dictionary: Enter comma separated words for creating the dictionary. This will be taken as refference and output will be taken on the basis of only these words.
4. Constraint: Enter Only Number in this fields. Both min and max value given as input will be taken and won't be Excluded. For Example if 2 is Min constraint, then
	Words with length 2 will be included in the input. same with Max Constraint.
	

DEFAULT Cases:
1. If no dimensions are given then both Row and Column is taken as 3,3. If one of them is not given, then other one is equated to the other given one.
2. If board data is not enough, then new words are added reandomly from 26 Characters.

ASSUMPTIONS:
1. Inputs are given in the format as mentioned.
2. Constraint are set both Upper and Lower limit.
3. Default cases are considered.
4. Repetation of same character in single word is not allowed.
5. In Dictionary, Duplicates will be taken only one as hashset are used for Faster searching.

# Description
Detailed Description:

This projects consists of 1 Scene. One Panle is created for collecting Input from User. Rest of the scene shows the boggle board and Output Window.

Lets see fields from Input Panel.

1. Board Dimesion: This consists of 2 fields for getting the number of rows and colums for the boggle board.
2. Board Data: This take Input as comma separated values of the boggle board.
3. Dictionary: This consists of list of comma separated words towards which we need to cross check whether those words are present in the boggle board.
4. Length Constraint: This consists of 2 inputs. One for Max Word Length Allowed, one for Minimum word length allowed.
5. 3 Buttons: Clear Button is there for clearing all the data from Input form, Submit Button is for navigating out from the menu with setting the input given by user.And Close button is there to close the Menu (This will also set the values which are set in the input fields).
6. 2 Buttons for Getting the sample Input Data are also added namely Sample1 & Sample2.

Lets see OUTPUT Window:

1. On Left hand side it generates a Boggle Board with Given Input.
2. On Right Hand Side, there is Output box, where on Top it displays the count of words that are found in the dictionary w.r.t. Boggle Board input. And below that
	Displays the list of words that are separated by comma (",").
3. Between above 2 Panles, there are 2 Buttons. Menu Button, to enable the Menu Panel. And Get Words Button to get all the list of words found along with the count.

Editor Level Description:

It consists of 1 Canvas that has Input Panel, Grid Panel, List Panel, Buttons, UIManager & BoardDataManager. Input Panel consists of Input Fields as already Discussed, List Panel is Output screen. Grid Panle is the area where the Boggle Board get generated.

Code Level Description:

There are 2 Gameobjects in the canvas UIManager & BoardDataManager which contains there respective scripts with same name.

1. UIManager :- As name suggests, UIManager takes care of the UI Elements Enabling, Disabling, Generation, etc.
2. BoardDataManager :- This takes care of the Input from the User. Run the Logic to get The list of words and set them in the output fields.  


Planned But Couldn't Implement:

1. Scrumble button, to auto generate a boogle board.
2. Proper validation on input fields, like handling exception cases like alphabatical input in integer fields, etc.


# Sample Data

Please find below sample Data for inputs.

Case 1 (Simple):

INPUT:-
Board Dimesion => 3,3
Board Data => q,w,e,a,s,d,z,x,c
Dictionary => zax,qwedsaz,qaswed,qwert,za
Length Constraint (min, max) => 3,6

OUTPUT:-
Count => 2
Words => zax,qaswed

CASES COVERED:-
1. Length Constraint is checked.
2. All Words Checked.
3. Linear Grid Checked.

Case 2 (Medium):

INPUT:-
Board Dimesion => 5,3
Board Data => r,t,y,u,i,f,g,h,j,k,c,v,b,n,m

r,t,y,u,i,
f,g,h,j,k,
c,v,b,n,m

Dictionary => rtygfrt,rfvcgbt,llkmjfn,bnghrtyf,ik,rgtfvbnmk,hjyt,rgbjiuy
Length Constraint (min, max) => 2,8

OUTPUT:-
Count => 3
Words => ik,hjyt,rgbjiuy

CASES COVERED:-
1. Uneven Grid Checked.
2. No Character Repeted Checked.

Case 3 (Bit Complex): 

INPUT:-
Board Dimesion => 5,3
Board Data => m,n,s,p,l,d,e,h,c,s,u,r,i,t,o

m,n,s,p,l
d,e,h,c,s
u,r,i,t,o

Dictionary => Fields,fill,data,dictionary,dimensions,displays,find,basis,below,bnghrtyf,board,boggle,button,max,menu,min,navigating,need,new,no,name,number,numbers,validation,value,values,canvas,care,cases,check,checked,clearing,close,collecting,colums,comma,creating,cross,zax,above,added,allowed,alphabatical,already,area,auto,samples,sample,scene,scripts,suggests,setting,fields
Length Constraint (min, max) => 2,9

OUTPUT:-
Count => 
Words => 

CASES COVERED:-
1. Large Dictionary Data.
2. Bigger Grid Checked.

