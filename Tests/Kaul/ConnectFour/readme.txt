Connect4 
----------

player1 : the first player --- red-token
player2 : the second player --- yellow-token

Horizontal Win : 
	After player's turn, the particular row in which token is recently placed will be traversed and check for consecutive four tokens having color as same as the color of current player's token
Vertical Win : 
	After player's turn, the particular column in which token is recently placed will be traversed and check for consecutive four token having color as same as the color of current player's token	
	
Diagonal Win :
	After the player's turn, the particular cell will be traversed from top-forward, top-backward, bottom-forward and bottom-backward. 
	

software requirement : VS2017 or VS 2019
--Build application for Nuget Package Restore