let AssertEquality a b = if a<>b then failwith "Failed!" else printfn "Test Success!"


// ---- basic if statements -------------------------------------

let isEven x1 =
    if x1 % 2 = 0 then
        "it's even!"
    else
        "it's odd!"
    
let result1 = isEven 2                
AssertEquality result1 "it's even!"
//---------------------------------------------------------------

// ---- if statements return values -----------------------------
    
(* In languages like C++, Java, and C# if statements do not yield 
  results; they can only cause side effects. If statements in F# 
  return values due to F#'s functional programming roots. *)
   
let result2 = 
    if 2 = 3 then
        "something is REALLY wrong"
    else
        "math is working!"

AssertEquality result2 "math is working!"

//---------------------------------------------------------------

// ---- branching with pattern matching -------------------------
 
let isApple x3 =
    match x3 with
    | "apple" -> true
    | _ -> false

let result3 = isApple "apple"
let result4 = isApple ""

AssertEquality result3 true
AssertEquality result4 false

//---------------------------------------------------------------

// ---- using tuples with if statements quickly becomes clumsy --
        
let getDinner x5 = 
    let name5, foodChoice5 = x5
    
    if foodChoice5 = "veggies" || foodChoice5 ="fish" || 
       foodChoice5 = "chicken" then
        sprintf "%s doesn't want red meat" name5
    else
        sprintf "%s wants 'em some %s" name5 foodChoice5
 
let person5 = ("Chris", "steak")
let person6 = ("Dave", "veggies")

AssertEquality (getDinner person5) "Chris wants 'em some steak"
AssertEquality (getDinner person6) "Dave doesn't want red meat"

//---------------------------------------------------------------

// ---- pattern matching with tuples is much nicer --------------
    
let getDinner7 x7 =
    match x7 with
    | (name7, "veggies")
    | (name7, "fish")
    | (name7, "chicken") -> sprintf "%s doesn't want red meat" name7
    | (name7, foodChoice7) -> sprintf "%s wants 'em some %s" name7 foodChoice7 
    
let person7 = ("Bob", "fish")
let person8 = ("Sally", "Burger")

AssertEquality (getDinner7 person7) "Bob doesn't want red meat"
AssertEquality (getDinner7 person8) "Sally wants 'em some Burger"

//---------------------------------------------------------------

//---------------------------------------------------------------
// About Lists
//
// Lists are important building blocks that you'll use frequently
// in F# programming. They are used to group arbitrarily large 
// sequences of values. It's very common to store values in a 
// list and perform operations across each value in the 
// list.
//---------------------------------------------------------------

// ---- creating lists ------------------------------------------

let list = ["apple"; "pear"; "grape"; "peach"]

//Note: The list data type in F# is a singly linked list, 
//      so indexing elements is O(n). 
 
AssertEquality list.Head "apple"
AssertEquality list.Tail ["pear"; "grape"; "peach"]
AssertEquality list.Length 4

       
(* .NET developers coming from other languages may be surprised
   that F#'s list type is not the same as the base class library's
   List<T>. In other words, the following assertion is true *)

//let dotNetList = new List<string>()

//you don't need to modify the following line
//AssertInequality (list.GetType()) (dotNetList.GetType())

//---------------------------------------------------------------

// ---- building new lists---------------------------------------

let first9 = ["grape"; "peach"]
let second9 = "pear" :: first9
let third9 = "apple" :: second9

//Note: "::" is known as "cons"

AssertEquality ["apple"; "pear"; "grape"; "peach"] third9
AssertEquality second9 ["pear"; "grape"; "peach"]
AssertEquality first9 ["grape"; "peach"]

//What happens if you uncomment the following?

//first.Head <- "apple"
//first.Tail <- ["peach"; "pear"]

//THINK ABOUT IT: Can you change the contents of a list once it 
//                has been created?

//---------------------------------------------------------------

// ---- concatenating lists -------------------------------------

let first10 = ["apple"; "pear"; "grape"]
let second10 = first10 @ ["peach"]

AssertEquality first10 ["apple"; "pear"; "grape"]
AssertEquality second10 ["apple"; "pear"; "grape"; "peach"]

(* THINK ABOUT IT: In general, what performs better for building lists, 
   :: or @? Why?
   
   Hint: There is no way to modify "first" in the above example. It's
   immutable. With that in mind, what does the @ function have to do in
   order to append ["peach"] to "first" to create "second"? *)

//---------------------------------------------------------------

// ---- creating lists with a range------------------------------

let list11 = [0..4]

AssertEquality list11.Head 0
AssertEquality list11.Tail [1; 2; 3; 4]

//---------------------------------------------------------------

// ---- creating lists with comprehensions-----------------------

let list12 = [for i in 0..4 do yield i ]
                            
AssertEquality list12 [0; 1; 2; 3; 4]

//---------------------------------------------------------------
    
// ---- comprehensions with conditions --------------------------

let list13 = [for i in 0..10 do 
                if i % 2 = 0 then yield i ]
                    
AssertEquality list13 [0; 2; 4; 6; 8; 10]

//---------------------------------------------------------------

