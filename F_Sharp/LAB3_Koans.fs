//Advanced Koans
//The original Koans only gives out very few examplesper concept.
//I designed some Lab questions similar to Koans foryou to practice more. Question banks avaliable onInternet are too hard for beginnners. I cannot use anybook related question banks as well, otherwise I haveto set this book as a required textbook and you wouldneed to buy it.
//The extra questions do not cover all the original Koan concepts. I picked out those that are the most commonly used and helpful for future bigger F# coding examples.
//Please let me know if you see errors in this file so I can update it.
//Referenced sources:
//Koans, Ninety-Nine F# problems, Project Eular, F# for Fun and Profit
//#########################
//Goal: fill in blanks to get every question run
//One question at a time. Comment out the questions you are done with.
//Based on Koans 0-, you now know the basics aboutfunction, tuple, and list in F#.
//#########################
 let AssertEquality a b = if a<>b then failwith "Fail!" else printfn "Test Success!"
 (*
 Completed example:
 let expected_value = 1 + 1
 let actual_value = 2
 AssertEquality expected_value actual_value
 *) //##### MOVE this line downwards to comment out the parts you are done with.

 //Q1
let expected_value = 5 + 6
let actual_value = 11
AssertEquality expected_value actual_value

 //Q2
let myvar=40
let newvar=80
AssertEquality newvar 80

 //Q3: nested function calls
let add a b =
  a+b

let res1 = add 3 6
let res2 = add 4 3

AssertEquality res1 9
AssertEquality res2 7

let addTwice x y =
  add (add x y) (add x y)
let restotal= addTwice 2 3
AssertEquality restotal 10

 //Q4
let mystr="Koans are puzzles."
let newstr="Koans are puzzles."
AssertEquality mystr newstr

 //Q5: nested function calls
let mystr1="Koans are puzzles."
let replaceEtoY (text:string) =
  text.Replace ("e", "Y")
let newstr1= replaceEtoY mystr1
AssertEquality newstr1 "Koans arY puzzlYs."

let replaceAEtoY(text:string)= 
  replaceEtoY(text.Replace("a", "Y"))
let finalstr=replaceAEtoY mystr1

AssertEquality finalstr "KoYns YrY puzzlYs."

 //Q6: nested function definitions
 //Compare this to Q3
(*let addTwice2 x y =
 //create a nested helper function
  let add2 x y =
    x+y
  //use the helper function
  add2 (add2 x y) (add2 x y)

  let res=addTwice2 3 4
  AssertEquality res 14

 //Q7: Compare to Q5
 let mystr2="Q7 Koans are puzzles."
 let replaceAEtoY2 (text:string) =
  //create helper func
  let replaceEtoY2 (text:string) =
    text.Replace ("e", "Y")
  //use helper func
  replaceEtoY2 (text.Replace ("a","Y"))

let res3=replaceAEtoY2 mystr2
//Try it out: can you use "replaceAEtoY text" instead of "replaceAEtoY (text:string)"?
//Why? F# is a strongly typed language. Its complier needs your help some times to tell the variable type to do its job.
   //Q8
 //let addTwice2_2 x y =
 //create a nested helper function
 //  let addTwice1_2 a b=
 // a+b
  //use the helper function
 // add2 (add2 x y) (add2 x y)

let res4=addTwice2 3 4
AssertEquality res4 14
//Why would this work?
//Try it out: If you do "let add2 a b = x +y" in Q8 instead, will it work? Why?
//Try it out: If you do "add2 (add2 a b) (add2 a b)" in Q8 instead, will it work? Why?
 //Q9 multi input func can be changed to solo input func
 let add2var x y=
    x+y
    *)
