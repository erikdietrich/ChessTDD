Feature: Pawn Moves
	In order to know where to put a pawn
	As a chess player
	I want to be shown legal moves

@mytag
Scenario: Move one space ahead
	Given A normal chessboard initial setup
	And I am the first player
	When I look for moves available for pawn
	Then The result contains a space one ahead
