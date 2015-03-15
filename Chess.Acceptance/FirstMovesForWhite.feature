Feature: FirstMovesForWhite
	In order to know my first move options
	As the white player
	I want to be shown my valid moves

@mytag
Scenario Outline: Move first pawn
	Given A normal chessboard initial setup
	When I look for moves for the pawn in column <column>
	Then The result contains a space one ahead in column <column>
	And The result contains a space two ahead in column <column>
	And The result does not contain a space three ahead in column <column>
	And The result does not contain the capture space one up and one over for column <column>

Examples:
	| column |
	| 1      |
	| 2      |
	| 3      |
	| 4      |
	| 5      |
	| 6      |
	| 7      |
	| 8      |
