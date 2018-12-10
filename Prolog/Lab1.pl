/************
 * Facts
 * Always start with lowercase letter, end with full stop
 * You could use _ in facts (names), but please avoid math operators
*/

thanksgivingsoon.
sunny.
wanttoplay.

/*These are all facts. This whole page is your database for your facts & rules.
You can also ask questions/query about your database.*/

/*Now, on the right side, after the ?- ask your first query:
 * sunny.
 * Hit run and see if the answer is yes
 * the ?- means asking a question, it is already provided by this complier. 
 * You would need to write it in other compliers in format: ?- sunny.
*/

/*Now, ask query: ?- raining.
 * What is the output?  */

/*__True__*/

/*You can defind facts with arguments. (just like a function with input variables)
 * It is just relationship between items.
 * Relation names must begin with lowercase letter as well.*/

likes(mary,food).
likes(mary,wine).
likes(john,wine).
likes(john,mary).

/*Ask query: ?- likes(mary,food).*/

/*__true___*/

/*OK, some KOANS about facts: */

eats(fred,oranges).                           /* "Fred eats oranges" */
eats(fred,"T-bone steaks").               /* "Fred eats T-bone steaks" */
eats(tony,apples).                     /* "Tony eats apples" */
eats(john,apples).                         /* "John eats apples" */

/*Ask some queries on the right side:
 * Does Fred eats T-bone steaks?
 * ?- eats(tony,pears). means what? What is the result?*/



/*You can also link up two sentances with ,
 * Try query:
 * ?- eats(fred,X),
 * X=oranges
 * What is the output? What is the meaning of this query?*/
/*__your answer here___*/

age(ian,2).                   /*  Ian is 2 */

/*will query ?- age(ian, two). give yes? Why?*/
/*No it doesn't. The variables we're testing are not of the same type. */


/*************
 * Variables
 * With only the facts, we cannot really do anything productive with this PL.
 * Just like other PLs, we need variables.
 * Variables have to start with a CAPITAL letter
 * The process of matching items with variables is known as unification.*/
/*
 * X: vairable X
 * Myvar: another legal variable
 * Myvar_current: also ok*/

/*What is the result of query ?- eats(fred,FoodX). ?
 *Make sure you press next button to see all the results.
 *In other editors, you would type ; to represent show next result.*/

/*__This allows us to view all possible variables that make the query true___*/

/***********
 * Rules
 * Each rule can have several variations -- clauses.
 * Rules provide ways to get inferences about facts.
 */

/*Operator :- means if*/
mortal(X) :- 
    human(X).  /*X is mortal if X is human*/
human(petter).  /*give a fact that petter is a human*/

/*__your answer here___*/ /*Ask query: is petter mortal?*/
/*What is the result of your query?*/
/*__True___*/

/*__Petter___*/ /*Ask query: who is mortal?*/
/*__Petter___*/ /*What is the result of your query?*/

/*One rule can have several variations.
 * The following example shows 3 ways that some thing is fun*/

fun(X) :-                      /* an item is fun if */ 
        red(X),                /* the item is red */
        car(X).                /* and it is a car */
fun(X) :-                      /*  or an item is fun if */
        blue(X),               /* the item is blue */
        bike(X).               /* and it is a bike */
fun(ice_cream).                /* and ice cream is also fun. */

/*Together with some facts:*/
car(vw_beatle).
car(ford_escort).
bike(harley_davidson).
red(vw_beatle).
red(ford_escort).
blue(harley_davidson).

/*__true___*/ /*Ask query: is harley_davidson fun?*/
/*What is the result of your query?*/
/*What are the logical steps that Prolog took to find the answer for you?
 * Hint: start matching from the first fun clause.*/
/*__what is fun? red^car^blue^bike_->what is red^car^blue^bike? -> Harley_davidson =blue -> harleydavidson is fun.__*/

/*__X = vw_beatle
X = ford_escort
X = harley_davidson
X = ice_cream___*/ /*Ask query: What is fun?*/
