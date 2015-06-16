Feature: Queen Movement

Scenario: A queen in her beginning position on an empty board
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |  WQ |     |     |     |     |
	Then the piece at (4,1) should have exactly the following moves
		| X | Y |
		| 1 | 1 |
		| 2 | 1 |
		| 3 | 1 |
		| 5 | 1 |
		| 6 | 1 |
		| 7 | 1 |
		| 8 | 1 |
		| 4 | 2 |
		| 4 | 3 |
		| 4 | 4 |
		| 4 | 5 |
		| 4 | 6 |
		| 4 | 7 |
		| 4 | 8 |
		| 3 | 2 |
		| 2 | 3 |
		| 1 | 4 |
		| 5 | 2 |
		| 6 | 3 |
		| 7 | 4 |
		| 8 | 5 |
	
Scenario: Queens in their beginning positions when all pieces are present
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
	Then the piece at (4,1) should have exactly the following moves
		| X | Y |
	And the piece at (5,8) should have exactly the following moves
		| X | Y |

Scenario: A queen with a capture opportunity
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |  BQ |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |  WQ |     |     |     |     |
	Then the piece at (4,1) should have exactly the following moves
		| X | Y |
		| 1 | 1 |
		| 2 | 1 |
		| 3 | 1 |
		| 5 | 1 |
		| 6 | 1 |
		| 7 | 1 |
		| 8 | 1 |
		| 4 | 2 |
		| 4 | 3 |
		| 4 | 4 |
		| 4 | 5 |
		| 4 | 6 |
		| 4 | 7 |
		| 4 | 8 |
		| 3 | 2 |
		| 2 | 3 |
		| 1 | 4 |
		| 5 | 2 |
		| 6 | 3 |
		| 7 | 4 |
		| 8 | 5 |

Scenario: A queen surrounded by enemy pieces
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |  BQ |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |  BB |  BB |  BP |     |     |     |
	   |     |     |  BR |  WQ |  BR |     |     |     |
	Then the piece at (4,1) should have exactly the following moves
         | X | Y |
         | 3 | 1 |
         | 5 | 1 |
         | 3 | 2 |
         | 4 | 2 |
         | 5 | 2 |

Scenario: A black queen surrounded by enemy pieces
When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |  WR |  BQ |  WR |     |     |     |
	   |     |     |  WB |  WB |  WP |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |  WQ |     |     |     |     |
	Then the piece at (4,8) should have exactly the following moves
         | X | Y |
         | 3 | 8 |
         | 5 | 8 |
         | 3 | 7 |
         | 4 | 7 |
         | 5 | 7 |