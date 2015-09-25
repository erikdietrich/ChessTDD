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

Scenario: White pawn en passant is allowed
	When there is a chess board set up as
    	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |  BP |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   | WP  |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
	And there is a move from (2,5) to (2,4)
	And there is a move from (1,2) to (1,4)
	Then the piece at (2,4) should have exactly the following moves
	| X | Y |
	| 2 | 3 |
	| 1 | 3 |
	
Scenario: Black pawn en passant is allowed
	 When there is a chess board set up as
     	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
     	   |     |     |     |     |     |     |     |     |
     	   | BP  |     |     |     |     |     |     |     |
     	   |     |     |     |     |     |     |     |     |
     	   |     |     |     |     |     |     |     |     |
     	   |     |  WP |     |     |     |     |     |     |
     	   |     |     |     |     |     |     |     |     |
     	   |     |     |     |     |     |     |     |     |
     	   |     |     |     |     |     |     |     |     |
	And there is a move from (2,4) to (2,5)
	And there is a move from (1,7) to (1,5)
	Then the piece at (2,5) should have exactly the following moves
	| X | Y |
	| 2 | 6 |
	| 1 | 6 |


Scenario: White en passant is allowed on the other side
	When there is a chess board set up as
    	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |  BP |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     | WP  |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
	And there is a move from (2,5) to (2,4)
	And there is a move from (3,2) to (3,4)
	Then the piece at (2,4) should have exactly the following moves
	| X | Y |
	| 2 | 3 |
	| 3 | 3 | 

Scenario: Black en passant is allowed on the other side
	When there is a chess board set up as
     	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
     	   |     |     |     |     |     |     |     |     |
     	   |     |     |  BP |     |     |     |     |     |
     	   |     |     |     |     |     |     |     |     |
     	   |     |     |     |     |     |     |     |     |
     	   |     |  WP |     |     |     |     |     |     |
     	   |     |     |     |     |     |     |     |     |
     	   |     |     |     |     |     |     |     |     |
     	   |     |     |     |     |     |     |     |     |
	And there is a move from (2,4) to (2,5)
	And there is a move from (3,7) to (3,5)
	Then the piece at (2,5) should have exactly the following moves
	| X | Y |
	| 2 | 6 |
	| 3 | 6 |

Scenario: White en passant expires after an interim move

	When there is a chess board set up as
    	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
    	   |     |     |     |     |     |     |     |     |
    	   | BP  |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |  BP |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     | WP  |     |     |     |     |  WP |
    	   |     |     |     |     |     |     |     |     |
	And there is a move from (2,5) to (2,4)
	And there is a move from (3,2) to (3,4)
	And there is a move from (1,7) to (1,6) 
	And there is a move from (8,2) to (8,3)
	Then the piece at (2,4) should have exactly the following moves
	| X | Y |
	| 2 | 3 |

Scenario: Black en passant expires after an interim move
	When there is a chess board set up as
    	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
    	   |     |     |     |     |     |     |     |     |
    	   |     |  BP |     |     |     |     |     | BP  |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     | WP  |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |     |
    	   |     |     |     |     |     |     |     |  WP |
    	   |     |     |     |     |     |     |     |     |
	And there is a move from (3,4) to (3,5)
	And there is a move from (2,7) to (2,5)
	And there is a move from (8,2) to (8,3)
	And there is a move from (8,7) to (8,6)
	Then the piece at (3,5) should have exactly the following moves
	| X | Y |
	| 3 | 6 |

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

Scenario: A black pawn that has already moved
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |     |     |     |     |     |
	   | BP  |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	And there is a move from (1,7) to (1,6)
	Then the piece at (1,6) should have exactly the following moves
	| X | Y |
    | 1 | 5 |

Scenario: A black pawn at the end of the board
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   | BP  |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	And there is a move from (1,2) to (1,1)
	Then the piece at (1,1) should have exactly the following moves
	| X | Y |

Scenario: A blocked black pawn
	When there is a chess board set up as
    	|  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
    	|     |     |     |     |     |     |     |     |
    	| BP  |     |     |     |     |     |     |     |
    	| WP  |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
    	|     |     |     |     |     |     |     |     |
	Then the piece at (1,7) should have exactly the following moves
         | X | Y |


Scenario: A black pawn capture
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |     |     |     |     |     |
	   |  BP |     |     |     |     |     |     |     |
	   |     | WP  |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	Then the piece at (1,7) should have exactly the following moves
        | X | Y |
        | 1 | 6 |
        | 1 | 5 |
        | 2 | 6 |

Scenario: Another black pawn capture
	When there is a chess board set up as
	   |  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	   |     |     |     |     |     |     |     |     |
	   |     | BP  |     |     |     |     |     |     |
	   |  WP |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	Then the piece at (2,7) should have exactly the following moves
		| X | Y |
		| 2 | 6 |
		| 2 | 5 |
		| 1 | 6 |