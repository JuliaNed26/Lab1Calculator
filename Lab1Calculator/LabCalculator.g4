grammar LabCalculator;

/*
* Parser Rules
*/
compileUnit : expression EOF;
expression :
LPAREN expression RPAREN #ParenthesizedExpr
| expression EXPONENT expression #ExponentialExpr
| expression operatorToken=(MULTIPLY | DIVIDE) expression #MultiplicativeExpr
| expression operatorToken=(PLUS | MINUS) expression #AdditiveExpr
| INC expression #IncExpr
| DEC expression #DecExpr
| MAX LPAREN exp1=expression COMMA exp2=expression RPAREN #MaxExpr
| MIN LPAREN exp1=expression COMMA exp2=expression RPAREN #MinExpr
| NUMBER #NumberExpr
| IDENTIFIER #IdentifierExpr
;

/*(...) підправило
*(...)* повторення підправила 0 чи більше разів
*(...)+ Повторення підправила 1 чи більше разів
*(...)? підправило, може бути відсутнє
*{...} семантичні дії
*[...] параметри правила
*| оператор альтернативи
*.. оператор діапазона
*~ заперечення
*. довільний символ
*= присвоювання
*: мітка початку
*; мітка закінчення правила
*/


/*
* Lexer Rules
*/
NUMBER : INT ('.' INT)?;
IDENTIFIER : [A-Z]+[0-9]+;
INT : ('0'..'9')+;
EXPONENT : '^';
MULTIPLY : '*';
DIVIDE : '/';
MINUS : '-';
PLUS : '+';
LPAREN : '(';
RPAREN : ')';
INC : 'inc';
DEC : 'dec';
MAX : 'max';
MIN : 'min';
COMMA : ',';
WS : [ \t\r\n] -> channel(HIDDEN);