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
   
  Then the piece at (5,1) should have the following moves
   | X  | Y  |

Scenario:  A king with no pawn in front
  When there is a chess board set up as
   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
   |     |     |     | BK  |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   | WP  | WP  | WP  | WP  |     | WP  | WP  | WP  |
   | WR  | WKn | WB  | WQ  | WK  | WB  | WKn | WR  |
   
  Then the piece at (5,1) should have the following moves
   | X | Y |
   | 5 | 2 |

Scenario:  King with nothing around
  When there is a chess board set up as
   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
   |     |     |     | BK  |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   | WP  | WP  | WP  | WP  |     | WP  | WP  | WP  |
   | WR  | WKn | WB  | WQ  | WK  | WB  | WKn | WR  |
   
  Then the piece at (4,8) should have the following moves
   | X | Y |
   | 3 | 8 |
   | 3 | 7 |
   | 4 | 7 |
   | 5 | 7 |
   | 5 | 8 |
   