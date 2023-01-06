// Implementation file for parser generated by fsyacc
module FunPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "FunPar.fsy"

 (* File Fun/FunPar.fsy 
    Parser for micro-ML, a small functional language; one-argument functions.
    sestoft@itu.dk * 2009-10-19
  *)

 open Absyn;

# 15 "FunPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | LPAR
  | RPAR
  | EQ
  | NE
  | GT
  | LT
  | GE
  | LE
  | PLUS
  | MINUS
  | TIMES
  | DIV
  | MOD
  | ENUM
  | DOT
  | BAR
  | ELSE
  | END
  | FALSE
  | IF
  | IN
  | LET
  | NOT
  | THEN
  | TRUE
  | CSTBOOL of (bool)
  | NAME of (string)
  | CSTINT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_EQ
    | TOKEN_NE
    | TOKEN_GT
    | TOKEN_LT
    | TOKEN_GE
    | TOKEN_LE
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_TIMES
    | TOKEN_DIV
    | TOKEN_MOD
    | TOKEN_ENUM
    | TOKEN_DOT
    | TOKEN_BAR
    | TOKEN_ELSE
    | TOKEN_END
    | TOKEN_FALSE
    | TOKEN_IF
    | TOKEN_IN
    | TOKEN_LET
    | TOKEN_NOT
    | TOKEN_THEN
    | TOKEN_TRUE
    | TOKEN_CSTBOOL
    | TOKEN_NAME
    | TOKEN_CSTINT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_Expr
    | NONTERM_AtExpr
    | NONTERM_AppExpr
    | NONTERM_Const
    | NONTERM_EnumList
    | NONTERM_EnumList1

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | LPAR  -> 1 
  | RPAR  -> 2 
  | EQ  -> 3 
  | NE  -> 4 
  | GT  -> 5 
  | LT  -> 6 
  | GE  -> 7 
  | LE  -> 8 
  | PLUS  -> 9 
  | MINUS  -> 10 
  | TIMES  -> 11 
  | DIV  -> 12 
  | MOD  -> 13 
  | ENUM  -> 14 
  | DOT  -> 15 
  | BAR  -> 16 
  | ELSE  -> 17 
  | END  -> 18 
  | FALSE  -> 19 
  | IF  -> 20 
  | IN  -> 21 
  | LET  -> 22 
  | NOT  -> 23 
  | THEN  -> 24 
  | TRUE  -> 25 
  | CSTBOOL _ -> 26 
  | NAME _ -> 27 
  | CSTINT _ -> 28 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_LPAR 
  | 2 -> TOKEN_RPAR 
  | 3 -> TOKEN_EQ 
  | 4 -> TOKEN_NE 
  | 5 -> TOKEN_GT 
  | 6 -> TOKEN_LT 
  | 7 -> TOKEN_GE 
  | 8 -> TOKEN_LE 
  | 9 -> TOKEN_PLUS 
  | 10 -> TOKEN_MINUS 
  | 11 -> TOKEN_TIMES 
  | 12 -> TOKEN_DIV 
  | 13 -> TOKEN_MOD 
  | 14 -> TOKEN_ENUM 
  | 15 -> TOKEN_DOT 
  | 16 -> TOKEN_BAR 
  | 17 -> TOKEN_ELSE 
  | 18 -> TOKEN_END 
  | 19 -> TOKEN_FALSE 
  | 20 -> TOKEN_IF 
  | 21 -> TOKEN_IN 
  | 22 -> TOKEN_LET 
  | 23 -> TOKEN_NOT 
  | 24 -> TOKEN_THEN 
  | 25 -> TOKEN_TRUE 
  | 26 -> TOKEN_CSTBOOL 
  | 27 -> TOKEN_NAME 
  | 28 -> TOKEN_CSTINT 
  | 31 -> TOKEN_end_of_input
  | 29 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_Expr 
    | 3 -> NONTERM_Expr 
    | 4 -> NONTERM_Expr 
    | 5 -> NONTERM_Expr 
    | 6 -> NONTERM_Expr 
    | 7 -> NONTERM_Expr 
    | 8 -> NONTERM_Expr 
    | 9 -> NONTERM_Expr 
    | 10 -> NONTERM_Expr 
    | 11 -> NONTERM_Expr 
    | 12 -> NONTERM_Expr 
    | 13 -> NONTERM_Expr 
    | 14 -> NONTERM_Expr 
    | 15 -> NONTERM_Expr 
    | 16 -> NONTERM_Expr 
    | 17 -> NONTERM_Expr 
    | 18 -> NONTERM_AtExpr 
    | 19 -> NONTERM_AtExpr 
    | 20 -> NONTERM_AtExpr 
    | 21 -> NONTERM_AtExpr 
    | 22 -> NONTERM_AtExpr 
    | 23 -> NONTERM_AtExpr 
    | 24 -> NONTERM_AppExpr 
    | 25 -> NONTERM_AppExpr 
    | 26 -> NONTERM_Const 
    | 27 -> NONTERM_Const 
    | 28 -> NONTERM_EnumList 
    | 29 -> NONTERM_EnumList 
    | 30 -> NONTERM_EnumList1 
    | 31 -> NONTERM_EnumList1 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 31 
let _fsyacc_tagOfErrorTerminal = 29

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | LPAR  -> "LPAR" 
  | RPAR  -> "RPAR" 
  | EQ  -> "EQ" 
  | NE  -> "NE" 
  | GT  -> "GT" 
  | LT  -> "LT" 
  | GE  -> "GE" 
  | LE  -> "LE" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | TIMES  -> "TIMES" 
  | DIV  -> "DIV" 
  | MOD  -> "MOD" 
  | ENUM  -> "ENUM" 
  | DOT  -> "DOT" 
  | BAR  -> "BAR" 
  | ELSE  -> "ELSE" 
  | END  -> "END" 
  | FALSE  -> "FALSE" 
  | IF  -> "IF" 
  | IN  -> "IN" 
  | LET  -> "LET" 
  | NOT  -> "NOT" 
  | THEN  -> "THEN" 
  | TRUE  -> "TRUE" 
  | CSTBOOL _ -> "CSTBOOL" 
  | NAME _ -> "NAME" 
  | CSTINT _ -> "CSTINT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | LPAR  -> (null : System.Object) 
  | RPAR  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | NE  -> (null : System.Object) 
  | GT  -> (null : System.Object) 
  | LT  -> (null : System.Object) 
  | GE  -> (null : System.Object) 
  | LE  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | DIV  -> (null : System.Object) 
  | MOD  -> (null : System.Object) 
  | ENUM  -> (null : System.Object) 
  | DOT  -> (null : System.Object) 
  | BAR  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | END  -> (null : System.Object) 
  | FALSE  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | NOT  -> (null : System.Object) 
  | THEN  -> (null : System.Object) 
  | TRUE  -> (null : System.Object) 
  | CSTBOOL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 22us; 65535us; 0us; 2us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 34us; 17us; 35us; 18us; 36us; 19us; 37us; 20us; 38us; 21us; 39us; 22us; 40us; 23us; 41us; 24us; 42us; 25us; 43us; 26us; 44us; 27us; 49us; 28us; 50us; 29us; 53us; 30us; 54us; 31us; 60us; 32us; 62us; 33us; 24us; 65535us; 0us; 4us; 4us; 64us; 5us; 65us; 9us; 4us; 11us; 4us; 13us; 4us; 15us; 4us; 34us; 4us; 35us; 4us; 36us; 4us; 37us; 4us; 38us; 4us; 39us; 4us; 40us; 4us; 41us; 4us; 42us; 4us; 43us; 4us; 44us; 4us; 49us; 4us; 50us; 4us; 53us; 4us; 54us; 4us; 60us; 4us; 62us; 4us; 22us; 65535us; 0us; 5us; 9us; 5us; 11us; 5us; 13us; 5us; 15us; 5us; 34us; 5us; 35us; 5us; 36us; 5us; 37us; 5us; 38us; 5us; 39us; 5us; 40us; 5us; 41us; 5us; 42us; 5us; 43us; 5us; 44us; 5us; 49us; 5us; 50us; 5us; 53us; 5us; 54us; 5us; 60us; 5us; 62us; 5us; 24us; 65535us; 0us; 45us; 4us; 45us; 5us; 45us; 9us; 45us; 11us; 45us; 13us; 45us; 15us; 45us; 34us; 45us; 35us; 45us; 36us; 45us; 37us; 45us; 38us; 45us; 39us; 45us; 40us; 45us; 41us; 45us; 42us; 45us; 43us; 45us; 44us; 45us; 49us; 45us; 50us; 45us; 53us; 45us; 54us; 45us; 60us; 45us; 62us; 45us; 1us; 65535us; 58us; 59us; 2us; 65535us; 58us; 68us; 70us; 71us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 26us; 51us; 74us; 99us; 101us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 12us; 1us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 1us; 2us; 2us; 24us; 2us; 3us; 25us; 2us; 4us; 19us; 1us; 4us; 1us; 4us; 1us; 5us; 12us; 5us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 5us; 12us; 5us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 5us; 12us; 5us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 6us; 12us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 12us; 7us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 12us; 7us; 8us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 12us; 7us; 8us; 9us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 12us; 7us; 8us; 9us; 10us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 12us; 7us; 8us; 9us; 10us; 11us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 12us; 13us; 14us; 15us; 16us; 17us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 13us; 14us; 15us; 16us; 17us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 14us; 15us; 16us; 17us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 15us; 16us; 17us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 16us; 17us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 17us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 20us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 20us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 21us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 21us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 22us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 23us; 1us; 7us; 1us; 8us; 1us; 9us; 1us; 10us; 1us; 11us; 1us; 12us; 1us; 13us; 1us; 14us; 1us; 15us; 1us; 16us; 1us; 17us; 1us; 18us; 1us; 19us; 2us; 20us; 21us; 2us; 20us; 21us; 1us; 20us; 1us; 20us; 1us; 20us; 1us; 21us; 1us; 21us; 1us; 21us; 1us; 21us; 1us; 22us; 1us; 22us; 1us; 22us; 1us; 22us; 1us; 22us; 1us; 22us; 1us; 23us; 1us; 23us; 1us; 24us; 1us; 25us; 1us; 26us; 1us; 27us; 1us; 29us; 2us; 30us; 31us; 1us; 31us; 1us; 31us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 17us; 19us; 22us; 25us; 28us; 30us; 32us; 34us; 47us; 49us; 62us; 64us; 77us; 79us; 92us; 105us; 118us; 131us; 144us; 157us; 170us; 183us; 196us; 209us; 222us; 235us; 248us; 261us; 274us; 287us; 300us; 313us; 315us; 317us; 319us; 321us; 323us; 325us; 327us; 329us; 331us; 333us; 335us; 337us; 339us; 342us; 345us; 347us; 349us; 351us; 353us; 355us; 357us; 359us; 361us; 363us; 365us; 367us; 369us; 371us; 373us; 375us; 377us; 379us; 381us; 383us; 385us; 388us; 390us; |]
let _fsyacc_action_rows = 72
let _fsyacc_actionTableElements = [|8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 0us; 49152us; 12us; 32768us; 0us; 3us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 9us; 34us; 10us; 35us; 11us; 36us; 12us; 37us; 13us; 38us; 0us; 16385us; 6us; 16386us; 1us; 62us; 14us; 56us; 22us; 47us; 26us; 67us; 27us; 46us; 28us; 66us; 6us; 16387us; 1us; 62us; 14us; 56us; 22us; 47us; 26us; 67us; 27us; 46us; 28us; 66us; 1us; 16403us; 15us; 7us; 1us; 32768us; 27us; 8us; 0us; 16388us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 12us; 32768us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 9us; 34us; 10us; 35us; 11us; 36us; 12us; 37us; 13us; 38us; 24us; 11us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 12us; 32768us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 9us; 34us; 10us; 35us; 11us; 36us; 12us; 37us; 13us; 38us; 17us; 13us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 11us; 16389us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 9us; 34us; 10us; 35us; 11us; 36us; 12us; 37us; 13us; 38us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 3us; 16390us; 11us; 36us; 12us; 37us; 13us; 38us; 3us; 16391us; 11us; 36us; 12us; 37us; 13us; 38us; 3us; 16392us; 11us; 36us; 12us; 37us; 13us; 38us; 0us; 16393us; 0us; 16394us; 0us; 16395us; 9us; 16396us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 9us; 34us; 10us; 35us; 11us; 36us; 12us; 37us; 13us; 38us; 9us; 16397us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 9us; 34us; 10us; 35us; 11us; 36us; 12us; 37us; 13us; 38us; 5us; 16398us; 9us; 34us; 10us; 35us; 11us; 36us; 12us; 37us; 13us; 38us; 5us; 16399us; 9us; 34us; 10us; 35us; 11us; 36us; 12us; 37us; 13us; 38us; 5us; 16400us; 9us; 34us; 10us; 35us; 11us; 36us; 12us; 37us; 13us; 38us; 5us; 16401us; 9us; 34us; 10us; 35us; 11us; 36us; 12us; 37us; 13us; 38us; 12us; 32768us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 9us; 34us; 10us; 35us; 11us; 36us; 12us; 37us; 13us; 38us; 21us; 50us; 12us; 32768us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 9us; 34us; 10us; 35us; 11us; 36us; 12us; 37us; 13us; 38us; 18us; 51us; 12us; 32768us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 9us; 34us; 10us; 35us; 11us; 36us; 12us; 37us; 13us; 38us; 21us; 54us; 12us; 32768us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 9us; 34us; 10us; 35us; 11us; 36us; 12us; 37us; 13us; 38us; 18us; 55us; 12us; 32768us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 9us; 34us; 10us; 35us; 11us; 36us; 12us; 37us; 13us; 38us; 18us; 61us; 12us; 32768us; 2us; 63us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 9us; 34us; 10us; 35us; 11us; 36us; 12us; 37us; 13us; 38us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 0us; 16402us; 0us; 16403us; 1us; 32768us; 27us; 48us; 2us; 32768us; 3us; 49us; 27us; 52us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 0us; 16404us; 1us; 32768us; 3us; 53us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 0us; 16405us; 1us; 32768us; 27us; 57us; 1us; 32768us; 3us; 58us; 1us; 16412us; 27us; 69us; 1us; 32768us; 21us; 60us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 0us; 16406us; 8us; 32768us; 1us; 62us; 10us; 15us; 14us; 56us; 20us; 9us; 22us; 47us; 26us; 67us; 27us; 6us; 28us; 66us; 0us; 16407us; 0us; 16408us; 0us; 16409us; 0us; 16410us; 0us; 16411us; 0us; 16413us; 1us; 16414us; 16us; 70us; 1us; 32768us; 27us; 69us; 0us; 16415us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 9us; 10us; 23us; 24us; 31us; 38us; 40us; 42us; 43us; 52us; 65us; 74us; 87us; 96us; 108us; 117us; 121us; 125us; 129us; 130us; 131us; 132us; 142us; 152us; 158us; 164us; 170us; 176us; 189us; 202us; 215us; 228us; 241us; 254us; 263us; 272us; 281us; 290us; 299us; 308us; 317us; 326us; 335us; 344us; 353us; 354us; 355us; 357us; 360us; 369us; 378us; 379us; 381us; 390us; 399us; 400us; 402us; 404us; 406us; 408us; 417us; 418us; 427us; 428us; 429us; 430us; 431us; 432us; 433us; 435us; 437us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 1us; 1us; 3us; 6us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 1us; 1us; 7us; 8us; 7us; 3us; 2us; 2us; 1us; 1us; 0us; 1us; 1us; 3us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 4us; 4us; 5us; 5us; 6us; 6us; 7us; 7us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 65535us; 65535us; 65535us; 65535us; 16388us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16402us; 16403us; 65535us; 65535us; 65535us; 65535us; 16404us; 65535us; 65535us; 65535us; 16405us; 65535us; 65535us; 65535us; 65535us; 65535us; 16406us; 65535us; 16407us; 16408us; 16409us; 16410us; 16411us; 16413us; 65535us; 65535us; 16415us; |]
let _fsyacc_reductions ()  =    [| 
# 276 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startMain));
# 285 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 35 "FunPar.fsy"
                                                               _1 
                   )
# 35 "FunPar.fsy"
                 : Absyn.expr));
# 296 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "FunPar.fsy"
                                                               _1                     
                   )
# 39 "FunPar.fsy"
                 : Absyn.expr));
# 307 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "FunPar.fsy"
                                                               _1                     
                   )
# 40 "FunPar.fsy"
                 : Absyn.expr));
# 318 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "FunPar.fsy"
                                                               EnumVal(_1, _3)        
                   )
# 41 "FunPar.fsy"
                 : Absyn.expr));
# 330 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 42 "FunPar.fsy"
                                                               If(_2, _4, _6)         
                   )
# 42 "FunPar.fsy"
                 : Absyn.expr));
# 343 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 "FunPar.fsy"
                                                               Prim("-", CstI 0, _2)  
                   )
# 43 "FunPar.fsy"
                 : Absyn.expr));
# 354 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 "FunPar.fsy"
                                                               Prim("+",  _1, _3)     
                   )
# 44 "FunPar.fsy"
                 : Absyn.expr));
# 366 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "FunPar.fsy"
                                                               Prim("-",  _1, _3)     
                   )
# 45 "FunPar.fsy"
                 : Absyn.expr));
# 378 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "FunPar.fsy"
                                                               Prim("*",  _1, _3)     
                   )
# 46 "FunPar.fsy"
                 : Absyn.expr));
# 390 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "FunPar.fsy"
                                                               Prim("/",  _1, _3)     
                   )
# 47 "FunPar.fsy"
                 : Absyn.expr));
# 402 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "FunPar.fsy"
                                                               Prim("%",  _1, _3)     
                   )
# 48 "FunPar.fsy"
                 : Absyn.expr));
# 414 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "FunPar.fsy"
                                                               Prim("=",  _1, _3)     
                   )
# 49 "FunPar.fsy"
                 : Absyn.expr));
# 426 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "FunPar.fsy"
                                                               Prim("<>", _1, _3)     
                   )
# 50 "FunPar.fsy"
                 : Absyn.expr));
# 438 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "FunPar.fsy"
                                                               Prim(">",  _1, _3)     
                   )
# 51 "FunPar.fsy"
                 : Absyn.expr));
# 450 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "FunPar.fsy"
                                                               Prim("<",  _1, _3)     
                   )
# 52 "FunPar.fsy"
                 : Absyn.expr));
# 462 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "FunPar.fsy"
                                                               Prim(">=", _1, _3)     
                   )
# 53 "FunPar.fsy"
                 : Absyn.expr));
# 474 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "FunPar.fsy"
                                                               Prim("<=", _1, _3)     
                   )
# 54 "FunPar.fsy"
                 : Absyn.expr));
# 486 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "FunPar.fsy"
                                                               _1                     
                   )
# 58 "FunPar.fsy"
                 : Absyn.expr));
# 497 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "FunPar.fsy"
                                                               Var _1                 
                   )
# 59 "FunPar.fsy"
                 : Absyn.expr));
# 508 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 60 "FunPar.fsy"
                                                               Let(_2, _4, _6)        
                   )
# 60 "FunPar.fsy"
                 : Absyn.expr));
# 521 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _7 = (let data = parseState.GetInput(7) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 61 "FunPar.fsy"
                                                               Letfun(_2, _3, _5, _7) 
                   )
# 61 "FunPar.fsy"
                 : Absyn.expr));
# 535 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'EnumList)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 62 "FunPar.fsy"
                                                               Enum(_2, _4, _6)       
                   )
# 62 "FunPar.fsy"
                 : Absyn.expr));
# 548 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 63 "FunPar.fsy"
                                                               _2                     
                   )
# 63 "FunPar.fsy"
                 : Absyn.expr));
# 559 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 67 "FunPar.fsy"
                 : Absyn.expr));
# 571 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 68 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 68 "FunPar.fsy"
                 : Absyn.expr));
# 583 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 72 "FunPar.fsy"
                                                               CstI(_1)               
                   )
# 72 "FunPar.fsy"
                 : Absyn.expr));
# 594 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : bool)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 73 "FunPar.fsy"
                                                               CstB(_1)               
                   )
# 73 "FunPar.fsy"
                 : Absyn.expr));
# 605 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 77 "FunPar.fsy"
                                                                  []       
                   )
# 77 "FunPar.fsy"
                 : 'EnumList));
# 615 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'EnumList1)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 78 "FunPar.fsy"
                                                                  _1       
                   )
# 78 "FunPar.fsy"
                 : 'EnumList));
# 626 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 82 "FunPar.fsy"
                                                                [_1]     
                   )
# 82 "FunPar.fsy"
                 : 'EnumList1));
# 637 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'EnumList1)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 83 "FunPar.fsy"
                                                                _1 :: _3 
                   )
# 83 "FunPar.fsy"
                 : 'EnumList1));
|]
# 650 "FunPar.fs"
let tables () : FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 32;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))