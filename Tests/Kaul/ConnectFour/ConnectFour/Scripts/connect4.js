var $connect4 = new Array(6);
for (var i = 1; i <= 6; i++) {
    $connect4[i] = new Array(7);
}
$gameOver = false;

$row = 0; $maxRow = 6;
$column = 0; $maxColumn = 7;

$player1 = "red-token";
$player2 = "yellow-token";

$turn = $player1;

$(".blank").click(function (e) {

    $column = parseInt($(this).parent().data("col"));
    $row = parseInt($(this).parent().parent().data("row"));

    if (!isNaN($column)) {

        $rowCounter = $maxRow;
        $columnCounter = 0;

        while ($rowCounter >= 1) {
            if ($connect4[$rowCounter][$column] != null) {
                $rowCounter--;
            } else {

                $color = ($turn == $player1) ? "red" : "yellow";

                $connect4[$rowCounter][$column] = $color;
                $("tr[data-row=" + ($rowCounter) + "] td[data-col=" + $column + "] .blank").removeClass("blank").addClass($turn);

                /*Horizontal*/
                $winnerCounter = 0;
                $result = horizontalCounter($maxColumn, $rowCounter, $color);

                if ($result == 4) {
                    endGame();
                }

                /*Vertical*/

                $result = verticalCounter($maxRow, $column, $color);
                if ($result == 4) {
                    endGame();
                }

                /*Diagonal*/
                $result = diagonalCounter($column, $rowCounter, $color);
                if ($result == 4) {
                    endGame();
                }


                togglePlayerTurn();
                $rowCounter = -1;
            }
        }
    } else {
        alert("ATB");
    }
});

/* change player's turn */
function togglePlayerTurn() {
    $("#yellow,#red").toggle();

    if ($turn == $player1) {
        $turn = $player2;
    }
    else {
        $turn = $player1;
    }
}

function horizontalCounter($maxCol, $currentRow, $color) {
    $winner = 0;
    $consectiveStartCol = 0;
    $consectiveEndCol = 0;

    for (var i = 0; i < $maxCol; i++) {
        if ($connect4[$currentRow][i + 1] != undefined && $connect4[$currentRow][i + 1] != null && $connect4[$currentRow][i + 1] == $color) {
            $winner++;
            if ($consectiveStartCol > 0) {
                $consectiveEndCol = (i + 1);
            } else {
                $consectiveStartCol = (i + 1);
            }
        } else {
            $winner = $consectiveStartCol = $consectiveEndCol = 0;
        }
        if ($winner == 4) {
            return $winner;
        }
    }
    return $winner;
}


function verticalCounter($maxRow, $currentCol, $color) {
    $winner = 0;
    $consectiveStartRow = 0;
    $consectiveEndRow = 0;

    for (var i = 0; i < $maxRow; i++) {
        if ($connect4[i + 1][$currentCol] != undefined && $connect4[i + 1][$currentCol] != null && $connect4[i + 1][$currentCol] == $color) {
            $winner++;
            if ($consectiveStartRow > 0) {
                $consectiveEndRow = (i + 1);
            } else {
                $consectiveStartRow = (i + 1);
            }
        } else {
            $winner = $consectiveStartRow = $consectiveEndRow = 0;
        }
        if ($winner == 4) {
            return $winner;
        }
    }
    return $winner;
}


function diagonalCounter($currentCol, $currentRow, $color) {

    $winner = 0;
    if ($currentCol < 4 && $currentRow < 4) {
        $winner = diagonalForward($currentCol, $currentRow, $color);
        if ($winner <= 4) {
            $winner = diagonalLeftUp($currentCol, $currentRow, $color);
        }
    }
    else if ($currentCol > 4 && $currentRow < 4) {
        $winner = diagonalBackward($currentCol, $currentRow, $color);
        if ($winner <= 4) {
            $winner = diagonalLeftUp($currentCol, $currentRow, $color);
        }

        if ($winner <= 4) {
            $winner = diagonalRightUp($currentCol, $currentRow, $color);
        }
    }
    else if ($currentRow < 4) {
        $winner = diagonalForward($currentCol, $currentRow, $color);
        if ($winner < 4) {
            $winner = diagonalBackward($currentCol, $currentRow, $color);
        }
        if ($winner < 4) {
            $winner = diagonalLeftUp($currentCol, $currentRow, $color);
        }
        if ($winner < 4) {
            $winner = diagonalRightUp($currentCol, $currentRow, $color);
        }

    } else if (($currentCol < 4 && $currentRow > 4) || ($currentCol < 4 && $currentRow > 3)) {
        $winner = diagonalRightUp($currentCol, $currentRow, $color);
    } else {
        $winner = diagonalLeftUp($currentCol, $currentRow, $color);
        if ($winner < 4) {
            $winner = diagonalRightUp($currentCol, $currentRow, $color);
        }
    }

    return $winner;
}

function diagonalForward($currentCol, $currentRow, $color) {
    $winner = 0;
    for (var i = 0; i < 4; i++) {
        if ($connect4[$currentRow + i][$currentCol + i] != undefined && $connect4[$currentRow + i][$currentCol + i] != null && $connect4[$currentRow + i][$currentCol + i] == $color) {
            $winner++;
        }
        else {
            return $winner;
        }
    }
    return $winner;
}

function diagonalBackward($currentCol, $currentRow, $color) {
    $winner = 0;
    for (var i = 0; i < 4; i++) {
        if ($connect4[$currentRow + i][$currentCol - i] != undefined && $connect4[$currentRow + i][$currentCol - i] != null && $connect4[$currentRow + i][$currentCol - i] == $color) {
            $winner++;
        }
    }

    return $winner;
}

function diagonalRightUp($currentCol, $currentRow, $color) {
    $winner = 0;
    $colDifference = $currentCol - 1;
    $lastDiagonalRow = $currentRow + $colDifference;
    $firstDiagonalCol = $currentCol - $colDifference;
    if ($lastDiagonalRow <= $maxRow && $lastDiagonalRow > 0) {
        for (var i = 0; i < 4; i++) {
            if ($firstDiagonalCol > 0 && $lastDiagonalRow > 0) {
                if ($connect4[$lastDiagonalRow][$firstDiagonalCol] != undefined && $connect4[$lastDiagonalRow][$firstDiagonalCol] != null && $connect4[$lastDiagonalRow][$firstDiagonalCol] == $color) {
                    $winner++;
                    $firstDiagonalCol++; $lastDiagonalRow--;
                }
            }
        }
    }

    if ($winner == 0) {

        $rowDifference = $maxRow - $currentRow;

        $lastDiagonalRow = $currentRow + $rowDifference;
        $firstDiagonalCol = $currentCol - $rowDifference;
        if ($lastDiagonalRow <= $maxRow && $lastDiagonalRow > 0) {
            for (var i = 0; i < $maxColumn; i++) {
                if ($firstDiagonalCol > 0 && $lastDiagonalRow > 0) {
                    if ($connect4[$lastDiagonalRow][$firstDiagonalCol] != undefined && $connect4[$lastDiagonalRow][$firstDiagonalCol] != null && $connect4[$lastDiagonalRow][$firstDiagonalCol] == $color) {
                        $winner++;
                        if ($winner == 4) {
                            return $winner;
                        }
                    }
                }
                $firstDiagonalCol++; $lastDiagonalRow--;
            }
        }

    }


    return $winner;
}

function diagonalLeftUp($currentCol, $currentRow, $color) {
    $winner = 0;
    if ($currentCol < 4) {
        $winner = 0;
        $rowDifference = $maxRow - $currentRow;
        $lastDiagonalRow = $currentRow + $rowDifference;
        if ($lastDiagonalRow <= $maxRow && $lastDiagonalRow > 0) {
            $lastDiagonalCol = $currentCol + $rowDifference;
            for (var i = 0; i < 4; i++) {
                if ($lastDiagonalCol > 0 && $lastDiagonalRow > 0) {
                    if ($connect4[$lastDiagonalRow][$lastDiagonalCol] != undefined && $connect4[$lastDiagonalRow][$lastDiagonalCol] != null && $connect4[$lastDiagonalRow][$lastDiagonalCol] == $color) {
                        $winner++;
                        $lastDiagonalCol--; $lastDiagonalRow--;
                    }
                }
            }
        }
    }

    else {
        $colDifference = $maxColumn - $currentCol;
        $lastDiagonalRow = $currentRow + $colDifference;
        if ($lastDiagonalRow <= $maxRow && $lastDiagonalRow > 0) {
            $lastDiagonalCol = $currentCol + $colDifference;
            for (var i = 0; i < 4; i++) {
                if ($lastDiagonalCol > 0 && $lastDiagonalRow > 0) {
                    if ($connect4[$lastDiagonalRow][$lastDiagonalCol] != undefined && $connect4[$lastDiagonalRow][$lastDiagonalCol] != null && $connect4[$lastDiagonalRow][$lastDiagonalCol] == $color) {
                        $winner++;
                        $lastDiagonalCol--; $lastDiagonalRow--;
                    }
                }
            }
        }
    }




    if ($winner < 4) {
        $winner = 0;
        if ($currentCol > 2) {
            $firstDiagonalRow = $currentRow - ($currentRow - 1);
            $firstDiagonalCol = $currentCol - ($currentRow - 1);
        }
        else {
            $firstDiagonalRow = $currentRow - 1;
            $firstDiagonalCol = $currentCol - 1;
        }

        for (var i = 0; i < $maxColumn; i++) {
            if ($firstDiagonalRow > 0 && $firstDiagonalCol > 0 && $firstDiagonalCol <= $maxColumn && $firstDiagonalRow <= $maxRow) {
                if ($connect4[$firstDiagonalRow][$firstDiagonalCol] != undefined && $connect4[$firstDiagonalRow][$firstDiagonalCol] != null && $connect4[$firstDiagonalRow][$firstDiagonalCol] == $color) {
                    $winner++;
                    if ($winner == 4) {
                        return $winner;
                    }
                }
                $firstDiagonalCol++; $firstDiagonalRow++;
            }
        }
    }


    if ($winner < 4 && $currentRow > 3) {
        $winner = 0;
        $lastDiagonalRow = $currentRow;
        $lastDiagonalCol = $currentCol;
        for (var i = 0; i < 4; i++) {
            if ($lastDiagonalCol > 0 && $lastDiagonalRow > 0) {
                if ($connect4[$lastDiagonalRow][$lastDiagonalCol] != undefined && $connect4[$lastDiagonalRow][$lastDiagonalCol] != null && $connect4[$lastDiagonalRow][$lastDiagonalCol] == $color) {
                    $winner++;
                    $lastDiagonalCol--; $lastDiagonalRow--;
                }
            }
        }
    }

    return $winner;
}

function endGame() {
    if ($turn == $player1) {
        $("#message").html("Winner : Player 1");
    } else {
        $("#message").html("Winner : Player 2");
    }

    $("td div").unbind("click");
    $gameOver = true;
}

function newgame() {
    window.location.reload();
}
