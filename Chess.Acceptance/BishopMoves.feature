Feature: Bishop Movement

Scenario: A white bishop in its beginning position on an empty board
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     | WB  |     |     |     |     |     |
	Then the piece at (3,1) should have exactly the following moves
		| X | Y |
		| 2 | 2 |
		| 1 | 3 |
		| 4 | 2 |
		| 5 | 3 |
		| 6 | 4 |
		| 7 | 5 |
		| 8 | 6 |

Scenario: A black bishop in its beginning position on an empty board
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |     |     |  BB |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	Then the piece at (6,8) should have exactly the following moves
		| X | Y |
		| 5 | 7 |
		| 4 | 6 |
		| 3 | 5 |
		| 2 | 4 |
		| 1 | 3 |
		| 7 | 7 |
		| 8 | 6 |

Scenario: Bishops in their beginning positions when all pieces are present
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
	Then the piece at (3,1) should have exactly the following moves
        | X | Y |
	And the piece at (6,1) should have exactly the following moves
		| X | Y |
	And the piece at (3,8) should have exactly the following moves
		| X | Y |
	And the piece at (6,8) should have exactly the following moves
        | X | Y |

Scenario: A bishop with a capture opportunity
	When there is a chess board set up as
    	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |  BB |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     | WB  |     |     |     |     |     |
	Then the piece at (3,1) should have exactly the following moves
		| X | Y |
		| 2 | 2 |
		| 1 | 3 |
		| 4 | 2 |
		| 5 | 3 |
		| 6 | 4 |
		| 7 | 5 |
		| 8 | 6 |

Scenario: White bishop surrounded by enemy pieces
	When there is a chess board set up as
    	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |  BR |  BQ | BR  |     |     |     |     |
    	   |     | BKn |  WB | BKn |     |     |     |     |
	Then the piece at (3,1) should have exactly the following moves
         | X | Y |
         | 2 | 2 |
         | 4 | 2 |

Scenario: Black bishop is surrounded by enemy pieces
	When there is a chess board set up as
    	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
    	   |     | WKn |  BB | WKn |     |     |     |     |
    	   |     | WR  |  WB | WR  |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
	Then the piece at (3,8) should have exactly the following moves
         | X | Y |
         | 2 | 7 |
         | 4 | 7 |