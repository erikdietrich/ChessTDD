Feature: PawnMoves

Scenario:  A pawn in its beginning position
  When there is a chess board set up as
   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   | WP  |     |     |     |     |     |     |     |
   |     |     |     |     |     |     |     |     |
   
  Then the piece at (1,2) should have exactly the following moves
   | X | Y |
   | 1 | 3 |
   | 1 | 4 |

Scenario: A pawn that has already moved
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   | WP  |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	And there is a move from (1,2) to (1,3)
	Then the piece at (1, 3) should have exactly the following moves
	| X | Y |
    | 1 | 4 |

Scenario: A pawn at the end of the board
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |     |     |     |     |     |
	   | WP  |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	And there is a move from (1,7) to (1,8)
	Then the piece at (1, 8) should have exactly the following moves
	| X | Y |

Scenario: A blocked pawn
	When there is a chess board set up as
    	|  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	| BP  |     |     |     |     |     |     |     |
    	| WP  |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
	Then the piece at (1,2) should have exactly the following moves
         | X | Y |

Scenario: A white pawn capture
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     | BP  |     |     |     |     |     |     |
	   |  WP |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	Then the piece at (1,2) should have exactly the following moves
         | X | Y |
         | 1 | 3 |
         | 1 | 4 |
         | 2 | 3 |

Scenario: Another white pawn capture
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |  BP |     |     |     |     |     |     |     |
	   |     | WP  |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	Then the piece at (2,2) should have exactly the following moves
		| X | Y |
		| 2 | 3 |
		| 2 | 4 |
		| 1 | 3 |

Scenario: A black pawn in its starting position
	When there is a chess board set up as
    	|  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
    	|     |     |     |     |     |     |     |     |
    	|  BP |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
	Then the piece at (1,7) should have exactly the following moves
		| X | Y |
		| 1 | 6 |
		| 1 | 5 |