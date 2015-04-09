Feature: King movement
 
Scenario:  A king in its beginning position
  When there is a chess board set up as
   |  a  |  b |  c |  d |  e |  f |  g  |  h |
   |    |     |    | BK |    |    |     |    |
   |    |     |    |    |    |    |     |    |
   |    |     |    |    |    |    |     |    |
   |    |     |    |    |    |    |     |    |
   |    |     |    |    |    |    |     |    |
   |    |     |    |    |    |    |     |    |
   | WP | WP  | WP | WP | WP | WP | WP  | WP |
   | WR | WKn | WB | WQ | WK | WB | WKn | WR |
   
  Then the WK at E8 should have the following moves
   | Start  | End  |