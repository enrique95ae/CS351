let AssertEquality a b = if a<>b then failwith "Failed!" else printfn "Test Success!"

//---------------------------------------------------------------
// Overview
//
// Below is a set of exercises designed to get you familiar 
// with F#. By the time you're done, you'll have a basic 
// understanding of the syntax of F# and learn a little more
// about functional programming in general.
//
// Answering Problems
// 
// This is where the fun begins! Each dashed section contains an 
// example designed to teach you a lesson about the F# language. 
// If you highlight the code in an example and execute it (use 
// Ctrl+Enter or the run button) it will initially fail. Your
// job is to fill in the blanks to make it pass. With each
// passing section, you'll learn more about F#, and add another
// weapon to your F# programming arsenal.
//
// Start by highlighitng the section below and running it. Once
// you see it fail, replace the __ with 2 to make it pass.
//---------------------------------------------------------------

// ---- about asserts -------------------------------------------

let mutable expected_value = 1 + 1
let mutable actual_value = 2

AssertEquality expected_value actual_value

//Easy, right? Try the next one.

//---------------------------------------------------------------
 
// ---- more about asserts --------------------------------------

//AssertEquality "foo" "bar"

//---------------------------------------------------------------

//---------------------------------------------------------------
// About Let
//
// The let keyword is one of the most fundamental parts of F#.
// You'll use it in almost every line of F# code you write, so
// let's get to know it well! (no pun intended)
//---------------------------------------------------------------

// ---- let binds a name to a value -----------------------------

let mutable x = 50
        
AssertEquality x 50
    
//---------------------------------------------------------------

// ---- let infers the type of values when it can ---------------

(* In F#, values created with let are inferred to have a type like
   "int" for integer values, "string" for text values, and "bool" 
   for true or false values. *)

let mutable x1 = 50
let mutable typeOfX1 = x1.GetType()
AssertEquality typeOfX1 typeof<int>

let mutable y1 = "a string"
let mutable expectedType = y1.GetType()
AssertEquality expectedType typeof<string>

//---------------------------------------------------------------

// ---- you can make the types explicit -------------------------

let mutable (x2:int) = 42
let mutable typeOfX2 = x2.GetType()

let mutable y2:string = "forty two"
let mutable typeOfY2 = y2.GetType()

AssertEquality typeOfX1 typeof<int>
AssertEquality typeOfY2 typeof<string>

(* You don't usually need to provide explicit type annotations 
   types for local varaibles, but type annotations can come in 
   handy in other contexts as you'll see later. *)

//---------------------------------------------------------------

// ---- floats and ints -----------------------------------------

(* Depending on your background, you may be surprised to learn that
    in F#, integers and floating point numbers are different types. 
    In other words, the following is true. *)
let mutable x3= 20
let mutable typeOfX3 = x3.GetType()

let mutable y3 = 20.0
let mutable typeOfY3 = y3.GetType()

//you don't need to modify these
AssertEquality typeOfX3 typeof<int>
AssertEquality typeOfY3 typeof<float>

//If you're coming from another .NET language, float is F# slang for
//the double type.

//---------------------------------------------------------------

// ---- modifying the value of variables ------------------------

let mutable x4 = 100
x4 <- 200

AssertEquality x4 200

//---------------------------------------------------------------

// ---- you can't modify a value if it isn't mutable ------------

let mutable x5 = 50

//What happens if you try to uncomment and run the following line of code?
//(look at the output in the output window)
//x <- 100

//NOTE: Although you can't modify immutable values, it is 
//      possible to reuse the name of a value in some cases 
//      using "shadowing".
let x6 = 100
 
AssertEquality x6 100

//---------------------------------------------------------------

// ---- creating functions with let -----------------------------

(* By default, F# is whitespace sensitive. For functions, this 
   means that the last line of a function is its return value,
   and the body of a function is denoted by indentation. *)

let add x y =
    x + y

let mutable result1 = add 2 2
let mutable result2 = add 5 2

AssertEquality result1 4
AssertEquality result2 7

//---------------------------------------------------------------

// ---- nesting functions ---------------------------------------

let quadruple x =    
    let double x =
        x * 2

    double(double(x))

let mutable result = quadruple 4
AssertEquality result 16

//---------------------------------------------------------------

// ---- adding type annotations ---------------------------------

(* Sometimes you need to help F#'s type inference system out with
   an explicit type annotation *)

let sayItLikeAnAuctioneer (text:string) =
    text.Replace(" ", "")

let mutable auctioneered = sayItLikeAnAuctioneer "going once going twice sold to the lady in red"
AssertEquality auctioneered "goingoncegoingtwicesoldtotheladyinred"

//TRY IT: What happens if you remove the type annotation on text?

//---------------------------------------------------------------

// ---- variables in the parent scope can be accessed -----------

let mutable suffix = "!!!"

let caffinate (text:string) =
    let mutable exclaimed = text + suffix
    let mutable yelled = exclaimed.ToUpper()
    yelled.Trim()

let mutable caffinatedReply = caffinate "hello there"

AssertEquality caffinatedReply "HELLO THERE!!!"

(* NOTE: Accessing the suffix variable in the nested caffinate function 
         is known as a closure. 
         
         See http://en.wikipedia.org/wiki/Closure_(computer_science) 
         for more about about closure. *)

//---------------------------------------------------------------

//---------------------------------------------------------------
// About the Order of Evaluation
//
// Sometimes you'll need to be explicit about the order in which
// functions are evaluated. F# offers a couple mechanisms for
// doing this.
//---------------------------------------------------------------

// ---- using parenthesis to control the order of operation -----

let add3 x y =
    x + y

let mutable result3 = add3 (add3 5 8) (add3 1 1)

AssertEquality result3 15

(* TRY IT: What happens if you remove the parensthesis?*)

//---------------------------------------------------------------

// ---- the backward pipe operator can also help with grouping --

let add4 x y =
    x + y

let double x =
    x * 2

let mutable result4 = double <| add4 5 8

AssertEquality result4 26

//---------------------------------------------------------------

// ---- the backward pipe operator can also help with grouping --

let add5 x y =
    x + y

let double5 x =
    x * 2

let mutable result5 = double5 <| add5 5 8

AssertEquality result5 26

//---------------------------------------------------------------

// About Unit
//
// The unit type is a special type that represents the lack of
// a value. It's similar to void in other languages, but unit
// is actually considered to be a type in F#.
//---------------------------------------------------------------

// ---- unit is used when there is no return value --------------
let sendData data =
    //...pretend we are sending the data to the server...
    ()

let mutable x7 = sendData "data"
AssertEquality x7 ()//Don't overthink this

//---------------------------------------------------------------

// ---- parameterless fucntions take unit as their argument -----

let sayHello() =
    "hello"

let mutable result6 = sayHello()
AssertEquality result6 "hello"

//---------------------------------------------------------------

// Tuples
//
// Tuples are used to easily group together values in F#. They're 
// another fundamental construct of the language.
//---------------------------------------------------------------

// ---- creating tuples -----

let mutable items = ("apple", "dog")

AssertEquality items ("apple", "dog")

//---------------------------------------------------------------

// ---- accessing tuple elements --------------------------------

let mutable items1 = ("apple", "dog")
 
let mutable fruit1 = fst items1
let mutable animal1 = snd items1
 
AssertEquality fruit1 "apple"
AssertEquality animal1 "dog"

//---------------------------------------------------------------

// ---- accessing tuple elements with pattern matching ----------

(* fst and snd are useful in some situations, but they only work with
   tuples containing two elements. It's usually better to use a 
   technique called pattern matching to access the values of a tuple. 
    
   Pattern matching works with tuples of any arity, and it allows you to 
   simultaneously break apart the tuple while assigning a name to each 
   value. Here's an example. *)

let mutable items2 = ("apple", "dog", "Mustang")

let mutable fruit2, animal2, car2 = items2

AssertEquality fruit2 "apple"
AssertEquality animal2 "dog"
AssertEquality car2 "Mustang"

//---------------------------------------------------------------

// ---- ignoring values when pattern matching -------------------
       
let mutable items3 = ("apple", "dog", "Mustang")

let mutable fruit3, animal3, car3 = items3

AssertEquality animal3 "dog"
    
//---------------------------------------------------------------

// ---- using tuples to return multiple values from a function --

let squareAndCube8 x8 =
    (x8 ** 2.0, x8 ** 3.0)

let mutable squared8, cubed8 = squareAndCube8 3.0


AssertEquality squared8 9.0
AssertEquality cubed8 27.0

(* THINK ABOUT IT: Is there really more than one return value?
                   What type does the squareAndCube function
                   return? *)

//---------------------------------------------------------------

// ---- the truth behind multiple return values ------------------

let squareAndCube9 x9 =
    (x9 ** 2.0, x9 ** 3.0)
            
let mutable result9 = squareAndCube9 3.0
       
AssertEquality result9 (9.0, 27.0)
