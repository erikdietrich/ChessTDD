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
   | 3 | 8 |
   
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
	| 3 | 1 |

Scenario: A King that can castle on one side only
	When there is a chess board set up as
	|  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |  WK |     |     | WR  |
	Then the piece at (5,1) should have exactly the following moves
	| X | Y |
	| 4 | 1 |
	| 4 | 2 |
	| 5 | 2 |
	| 6 | 2 |
	| 6 | 1 |
	| 7 | 1 |

Scenario: Black king eligible to castle
	When there is a chess board set up as
	|  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	|  BR |     |     |     |  BK |     |     | BR  |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	Then the piece at (5,8) should have exactly the following moves
	| X | Y |
	| 4 | 8 |
	| 4 | 7 |
	| 5 | 7 |
	| 6 | 7 |
	| 6 | 8 |
	| 7 | 8 |
	| 3 | 8 |

Scenario: Castling when rook has moved
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
	And there is a move from (1,1) to (1,2)
	And there is a move from (1,2) to (1,1)
	Then the piece at (5,1) should have exactly the following moves
	| X | Y |
	| 4 | 1 |
	| 4 | 2 |
	| 5 | 2 |
	| 6 | 2 |
	| 6 | 1 |
	| 7 | 1 |

Scenario: Castling when king has moved
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
	And there is a move from (5,1) to (5,2)
	And there is a move from (5,2) to (5,1)
	Then the piece at (5,1) should have exactly the following moves
	| X | Y |
	| 4 | 1 |
	| 4 | 2 |
	| 5 | 2 |
	| 6 | 2 |
	| 6 | 1 |

Scenario: Castling if a piece is in between
	When there is a chess board set up as
	|  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	| WR  |     |     |     | WK  |     | WKn | WR  |
	Then the piece at (5,1) should have exactly the following moves
	| X | Y |
	| 4 | 1 |
	| 4 | 2 |
	| 5 | 2 |
	| 6 | 2 |
	| 6 | 1 |
	| 3 | 1 |

Scenario: Castling with both sides blocked
	When there is a chess board set up as
	|  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	| WR  | WKn |     |     | WK  |     | WKn | WR  |
	Then the piece at (5,1) should have exactly the following moves
	| X | Y |
	| 4 | 1 |
	| 4 | 2 |
	| 5 | 2 |
	| 6 | 2 |
	| 6 | 1 |

Scenario: Castling for black with both sides blocked
	When there is a chess board set up as
	|  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
	|  BR | BKn |     |     | BK  |     | BKn | BKn |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	|     |     |     |     |     |     |     |     |
	Then the piece at (5,8) should have exactly the following moves
	| X | Y |
	| 4 | 8 |
	| 4 | 7 |
	| 5 | 7 |
	| 6 | 7 |
	| 6 | 8 |

Scenario: White king can't castle through check to queen's side
	When there is a chess board set up as
		|  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
		|     |     |     | BQ  |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|  WR |     |     |     |  WK |     |     | WR  |
	Then the piece at (5,1) should have exactly the following moves
		| X | Y |
		| 5 | 2 |
		| 6 | 2 |
		| 6 | 1 |
		| 7 | 1 |

Scenario: White king can't castle through a piece
	When there is a chess board set up as
		|  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		| WR  |     |     | WQ  | WK  |     |     | WR  |
	Then the piece at (5,1) should have exactly the following moves
		| X | Y |
		| 4 | 2 |
		| 5 | 2 |
		| 6 | 2 |
		| 6 | 1 |
		| 7 | 1 |

Scenario: White king can't castle onto a piece
	When there is a chess board set up as
		|  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		| WR  |     | WB  |     | WK  |     |     | WR  |
	Then the piece at (5,1) should have exactly the following moves
		| X | Y |
		| 4 | 1 |
		| 4 | 2 |
		| 5 | 2 |
		| 6 | 2 |
		| 6 | 1 |
		| 7 | 1 |

Scenario: White king can't move into check
	When there is a chess board set up as
		|  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
		|     |     |     | BQ  |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|  WR |     |     |     |  WK |     |     | WR  |
	Then the piece at (5,1) should have exactly the following moves
		| X | Y |
		| 5 | 2 |
		| 6 | 2 |
		| 6 | 1 |
		| 7 | 1 |

Scenario: Black king can't move into check
	When there is a chess board set up as
		|  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
		| BR  |     |     |     | BK  |     |     |  BR |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|  WR |     |     |  WQ |  WK |     |     | WR  |
	Then the piece at (5,8) should have exactly the following moves
		| X | Y |
		| 5 | 7 |
		| 6 | 7 |
		| 6 | 8 |
		| 7 | 8 |

Scenario: Immobilized King
	When there is a chess board set up as
		|  1  |  2  |  3  |  4  |  5  |   6 |  7  |  8  |
		|     |     |     | BQ  |     | BR  |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |     |     |     |     |     |     |     |
		|     |  BR |     |     |     |     |     |     |
		|  WR |     |     |     |  WK |     |     | WR  |
	Then the piece at (5,1) should have exactly the following moves
		| X | Y |
