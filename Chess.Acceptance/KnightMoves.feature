Feature: Knight Movement

Scenario: A knight in its beginning position on an empty board
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     | WKn |     |     |     |     |     |     |
	Then the piece at (2,1) should have exactly the following moves
	   | X | Y |
	   | 1 | 3 |
	   | 3 | 3 |
	   | 4 | 2 |

Scenario: A knight in its beginning position when all white pieces are present
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   | WP  | WP  | WP  | WP  | WP  | WP  | WP  | WP  |
	   | WR  | WKn | WB  | WQ  | WK  | WB  | WKn | WR  |
	Then the piece at (2,1) should have exactly the following moves
         | X | Y |
         | 1 | 3 |
         | 3 | 3 |
	And the piece at (7,1) should have exactly the following moves
		| X | Y |
		| 6 | 3 |
		| 8 | 3 |

Scenario: A black knight in its beginning position when all pieces are present
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
	Then the piece at (2,8) should have exactly the following moves
		| X | Y |
		| 1 | 6 |
		| 3 | 6 |
	And the piece at (7,8) should have exactly the following moves
		| X | Y |
		| 6 | 6 |
		| 8 | 6 |


Scenario: A white knight with a capture opportunity
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   | BR  | BKn | BB  | BQ  | BK  | BB  | BKn | BR  |
	   | BP  | BP  | BP  | BP  | BP  |     | BP  | BP  |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     | BP  |     |     |
	   | WP  | WP  | WP  | WP  | WP  | WP  | WP  | WP  |
	   | WR  | WKn | WB  | WQ  | WK  | WB  | WKn | WR  |
	Then the piece at (7,1) should have exactly the following moves
		| X | Y |
		| 6 | 3 |
		| 8 | 3 |

Scenario: A white knight in the middle of an empty board
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     | WKn |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	Then the piece at (4,4) should have exactly the following moves
		| X | Y |
		| 2 | 3 |
		| 2 | 5 |
		| 3 | 2 |
		| 3 | 6 |
		| 5 | 2 |
		| 5 | 6 |
		| 6 | 3 |
		| 6 | 5 |

 
