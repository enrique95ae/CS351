 let AssertEquality a b = if a<>b then failwith
"Failed!" else printfn "Test Success!"
 //---- transforming lists with map
 let square x =
  x*x
 let original = [0..5]
 let result = List.map square original
 AssertEquality original [0..5]
 AssertEquality result [0;1;4;9;16;25]
 //-----------------------------------------------------
 // ---- filtering lists with where

 let isEven1 x1 =
 x1 % 2 = 0
 let original1 = [0..5]
 let result1 = List.filter isEven1 original1
AssertEquality original1 [0..5]
 AssertEquality result1 [0;2;4]
 //-----------------------------------------------------
 // ---- dividing lists with partition ---------------------------
 let isOdd2 x2 = not(x2 % 2 = 0)
 let original2 = [0..5]
 let result12, result22 = List.partition
 isOdd2 original2
 AssertEquality result12 [1;3;5]
 AssertEquality result22 [0;2;4]
 //-----------------------------------------------------
 // Note: There are many other useful methods in the List module.
 //Check them
// via intellisense in Visual Studio by typing '.' after List, or online at
//  http://msdn.microsoft.com/en-us/library/ee353738.aspx
//-----------------------------------------------------
// Pipelining

// The forward pipe operator is one of the most commonly used
// symbols in F# programming. You can use it combine operations
// on lists and other data structures in a readable way.
//-----------------------------------------------------
// ---- square even numbers with separate statementes   
let square3 x3 =
  x3 * x3
let isEven3 x3 =
  x3 % 2 = 0
//One way to combine operations is by using separate statements.
// However, this is can be clumsy since you have to name each result.
let numbers3 = [0..5]
AssertEquality result3 [0;4;16]
let evens3 = List.filter isEven3 numbers3
let result3 = List.map square3 evens3
 
//-----------------------------------------------------
// ---- square even numbers with parens
//You can avoid this problem by using parens to pass the result of one
// funciton to another. This can be difficult to read since you 
//have to
// start from the innermost function and work your way out.
let numbers4 = [0..5]
AssertEquality result4 [0;4;16]
let result4 = List.map square3 (List.filter isEven3 numbers4)
 //-----------------------------------------------------
 // ---- square even numbers with  the pipeline operator
 //In F#, you can use the pipeline operator to get the benefit of the
 //parens style with the readablity of the statement style.
 let result5 =
 [0..5]
 |> List.filter isEven3
 |> List.map square3
 AssertEquality result5 [0;4;16]
 //-----------------------------------------------------
 // ---- how the pipe operator is defined
 let (|>) x6 y6 =
 y6 x6
 let result6 =
 [0..5]
 |> List.filter isEven3
 |> List.map square3
 AssertEquality result6 [0;4;16]
 //-----------------------------------------------------
 //-----------------------------------------------------
 // Arrays
 //
// Like lists, arrays are another basic container type in F#.
//-----------------------------------------------------
// ---- creating arrays
 let fruits = [| "apple"; "pear"; "peach"|]
 AssertEquality fruits.[0] "apple"
 AssertEquality fruits.[1] "pear"
 AssertEquality fruits.[2] "peach"
 //-----------------------------------------------------
 // ---- arrays are mutable
 let fruits7 = [| "apple"; "pear" |]
 fruits7.[1] <- "peach"
 AssertEquality fruits7 [|"apple"; "peach"|]
 //-----------------------------------------------------
 // ---- you can create arrays with comprehensions
 let numbers8 =
 [| for i in 0..10 do
  let cube x =
  if i % 2 = 0 then yield i |]
AssertEquality numbers8 [|0;2;4;6;8;10|]
 //-----------------------------------------------------
 // ---- you can also perform operations on arrays x*x*x
 let original9 = [| 0..5 |]
 let result9 = Array.map cube original9
 AssertEquality original9 [|0..5|]
 AssertEquality result9 [|0;1;8;27;64;125|]
 //See more Array methods at
 //  http://msdn.microsoft.com/en-us/library/ee370273.aspx *)
 //-----------------------------------------------------
-------
