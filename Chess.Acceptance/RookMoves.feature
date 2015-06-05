Feature: Rook Movement

Scenario: A rook in its beginning position on an empty board
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |  WR |     |     |     |     |     |     |     |
	Then the piece at (1,1) should have exactly the following moves
		| X | Y |
		| 1 | 2 |
		| 1 | 3 |
		| 1 | 4 |
		| 1 | 5 |
		| 1 | 6 |
		| 1 | 7 |
		| 1 | 8 |
		| 2 | 1 |
		| 3 | 1 |
		| 4 | 1 |
		| 5 | 1 |
		| 6 | 1 |
		| 7 | 1 |
		| 8 | 1 |

Scenario: Rooks in their beginning positions when all pieces are present
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   | BR  | BKn | BB  | BQ  | BK  | BB  | BKn | BR  |
	   | BP  | BP  | BP  | BP  | BP  | BP  | BP  | BP  |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   | WP  | WP  | WP  | WP  | WP  | WP  | WP  | WP  |
	   | WR  | WKn | WB  | WQ  | WK  | WB  | WKn | WR  |
	Then the piece at (1,1) should have exactly the following moves
		| X | Y |
	And the piece at (8,1) should have exactly the following moves
		| X | Y |
	And the piece at (1,8) should have exactly the following moves
		| X | Y |
	And the piece at (8,8) should have exactly the following moves
		| X | Y |

Scenario: A rook with a capture opportunity
	When there is a chess board set up as
    	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
    	   |  BR |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |  WR |     |     |     |     |     |     |     |
	Then the piece at (1,1) should have exactly the following moves
		| X | Y |
		| 1 | 2 |
		| 1 | 3 |
		| 1 | 4 |
		| 1 | 5 |
		| 1 | 6 |
		| 1 | 7 |
		| 1 | 8 |
		| 2 | 1 |
		| 3 | 1 |
		| 4 | 1 |
		| 5 | 1 |
		| 6 | 1 |
		| 7 | 1 |
		| 8 | 1 |

Scenario: White queen's rook surrounded by enemy pieces
	When there is a chess board set up as
    	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |  BR | BB  |     |     |     |     |     |     |
    	   |  WR | BR  |     |     |     |     |     |     |
	Then the piece at (1,1) should have exactly the following moves
         | X | Y |
         | 1 | 2 |
         | 2 | 1 |

Scenario: Black king's rook surrounded by enemy pieces
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |     |     |     |  WR |  BR |
	   |     |     |     |     |     |     |  WB |  WR |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	Then the piece at (8,8) should have exactly the following moves
         | X | Y |
         | 7 | 8 |
         | 8 | 7 |