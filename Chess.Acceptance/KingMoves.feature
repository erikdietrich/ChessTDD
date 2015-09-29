Feature: King movement
 
Scenario:  A king in its beginning position
  When there is a chess board set up as
   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
   |     |     |     | BK  |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   | WP  | WP  | WP  | WP  | WP  | WP  | WP  | WP  |
   | WR  | WKn | WB  | WQ  | WK  | WB  | WKn | WR  |
   
  Then the piece at (5,1) should have exactly the following moves
   | X  | Y  |

Scenario:  A king with no pawn in front
  When there is a chess board set up as
   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
   |     |     |     | BQ  |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   | WP  | WP  | WP  | WP  |     | WP  | WP  | WP  |
   | WR  | WKn | WB  | WQ  | WK  | WB  | WKn | WR  |
   
  Then the piece at (5,1) should have exactly the following moves
   | X | Y |
   | 5 | 2 |

Scenario:  King with nothing around
  When there is a chess board set up as
   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
   | BR  |     |     |     | BK  |     |     | BR  |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   | WP  | WP  | WP  | WP  |     | WP  | WP  | WP  |
   | WR  | WKn | WB  | WQ  | WK  | WB  | WKn | WR  |
   
  Then the piece at (5,8) should have exactly the following moves
   | X | Y |
   | 4 | 8 |
   | 4 | 7 |
   | 5 | 7 |
   | 6 | 7 |
   | 6 | 8 |
   | 7 | 8 |
   | 2 | 8 |
   
Scenario: A king eligible to castle
	When there is a chess board set up as
    	|  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|  WR |     |     |     |  WK |     |     | WR  |
	Then the piece at (5,1) should have exactly the following moves
	| X | Y |
	| 4 | 1 |
	| 4 | 2 |
	| 5 | 2 |
	| 6 | 2 |
	| 6 | 1 |
	| 7 | 1 |
	| 2 | 1 |