Feature: ActualGame

Scenario: Initial board setup
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
	Then the piece at (2,1) should have exactly the following moves
        | X | Y |
        | 1 | 3 |
        | 3 | 3 |
	And the piece at (7,1) should have exactly the following moves
        | X | Y |
        | 6 | 3 |
        | 8 | 3 |
	And all white non-knight pieces should have no moves
	And all white pawns should have two moves