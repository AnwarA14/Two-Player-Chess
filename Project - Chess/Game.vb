Imports MySql.Data.MySqlClient

Public Class Game
    Dim board(7, 7) As PictureBox
    Dim boardPosition(7, 7) As Integer
    Dim pieces(31) As Pieces
    Dim turn As Integer
    Dim currentx As Integer
    Dim currenty As Integer
    Dim originalX As Integer
    Dim originalY As Integer
    Dim currentIndex As Integer
    Dim currentPosition As Integer
    Dim whiteCurrentPosition As Integer
    Dim blackCurrentPosition As Integer
    Dim whiteCurrentIndex As Integer
    Dim blackCurrentIndex As Integer

    Dim player(1) As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Sets the player usernames by importing input from Main Menu
        player(0) = MainMenu.username1
        player(1) = MainMenu.username2

        'Instantatiates all of the Chess Pieces
        For counter = 0 To 31
            pieces(counter) = New Pieces
        Next

        RichTextBox3.Text = "White"

        'This nested loop sets the chessboard up
        For x = 0 To 7
            For y = 0 To 7
                board(x, y) = New PictureBox 'Initialises each board as a picture box
                Controls.Add(board(x, y)) 'Adds controls to each picturebox
                board(x, y).Location = New Point(70 * x, 70 * y + 50) 'Sets the position of each picturebox
                board(x, y).Width = 70 'Sets up various properties of the picturebox
                board(x, y).Height = 70
                board(x, y).Visible = True
                board(x, y).Tag = x & "," & y
                'The following block of code determines which box should be which colour
                If (x Mod 2) = 0 Then
                    board(x, y).BackColor = Color.DarkGray
                Else
                    board(x, y).BackColor = Color.White
                End If
                If y > 0 Then
                    If board(x, y - 1).BackColor = Color.DarkGray Then
                        board(x, y).BackColor = Color.White
                    ElseIf board(x, y - 1).BackColor = Color.White Then
                        board(x, y).BackColor = Color.DarkGray
                    End If
                End If
            Next
        Next

        'This code sets up the 2D array that will be used to store the position of each piece
        boardPosition =
 {{5, 6, 0, 0, 0, 0, -6, -5},
 {4, 6, 0, 0, 0, 0, -6, -4},
 {3, 6, 0, 0, 0, 0, -6, -3},
 {2, 6, 0, 0, 0, 0, -6, -2},
 {1, 6, 0, 0, 0, 0, -6, -1},
 {3, 6, 0, 0, 0, 0, -6, -3},
 {4, 6, 0, 0, 0, 0, -6, -4},
 {5, 6, 0, 0, 0, 0, -6, -5}}

        'This variable will be used to match up a piece object with a boardposition
        Dim index As Integer
        index = 0

        For x = 0 To 7
            For y = 0 To 7
                If boardPosition(x, y) <> 0 Then
                    If Math.Abs(boardPosition(x, y)) = 1 Then
                        If Math.Sign(boardPosition(x, y)) = 1 Then
                            'The following block of code sets up each piece object
                            'with values from its corresponding board position
                            pieces(index).setPieceValue(boardPosition(x, y))
                            pieces(index).setInitialPosition(x, y)
                            pieces(index).setIndex(index)
                            pieces(index).setTag(board(x, y).Tag)
                            index = index + 1 'Increments the index
                        ElseIf Math.Sign(boardPosition(x, y)) = -1 Then
                            pieces(index).setPieceValue(boardPosition(x, y))
                            pieces(index).setInitialPosition(x, y)
                            pieces(index).setIndex(index)
                            pieces(index).setTag(board(x, y).Tag)
                            index = index + 1
                        End If
                    ElseIf Math.Abs(boardPosition(x, y)) = 2 Then
                        If Math.Sign(boardPosition(x, y)) = 1 Then
                            pieces(index).setPieceValue(boardPosition(x, y))
                            pieces(index).setInitialPosition(x, y)
                            pieces(index).setIndex(index)
                            pieces(index).setTag(board(x, y).Tag)
                            index = index + 1
                        ElseIf Math.Sign(boardPosition(x, y)) = -1 Then
                            pieces(index).setPieceValue(boardPosition(x, y))
                            pieces(index).setInitialPosition(x, y)
                            pieces(index).setIndex(index)
                            pieces(index).setTag(board(x, y).Tag)
                            index = index + 1
                        End If
                    ElseIf Math.Abs(boardPosition(x, y)) = 3 Then
                        If Math.Sign(boardPosition(x, y)) = 1 Then
                            pieces(index).setPieceValue(boardPosition(x, y))
                            pieces(index).setInitialPosition(x, y)
                            pieces(index).setIndex(index)
                            pieces(index).setTag(board(x, y).Tag)
                            index = index + 1
                        ElseIf Math.Sign(boardPosition(x, y)) = -1 Then
                            pieces(index).setPieceValue(boardPosition(x, y))
                            pieces(index).setInitialPosition(x, y)
                            pieces(index).setIndex(index)
                            pieces(index).setTag(board(x, y).Tag)
                            index = index + 1
                        End If
                    ElseIf Math.Abs(boardPosition(x, y)) = 4 Then
                        If Math.Sign(boardPosition(x, y)) = 1 Then
                            pieces(index).setPieceValue(boardPosition(x, y))
                            pieces(index).setInitialPosition(x, y)
                            pieces(index).setIndex(index)
                            pieces(index).setTag(board(x, y).Tag)
                            index = index + 1
                        ElseIf Math.Sign(boardPosition(x, y)) = -1 Then
                            pieces(index).setPieceValue(boardPosition(x, y))
                            pieces(index).setInitialPosition(x, y)
                            pieces(index).setIndex(index)
                            pieces(index).setTag(board(x, y).Tag)
                            index = index + 1
                        End If
                    ElseIf Math.Abs(boardPosition(x, y)) = 5 Then
                        If Math.Sign(boardPosition(x, y)) = 1 Then
                            pieces(index).setPieceValue(boardPosition(x, y))
                            pieces(index).setInitialPosition(x, y)
                            pieces(index).setIndex(index)
                            pieces(index).setTag(board(x, y).Tag)
                            index = index + 1
                        ElseIf Math.Sign(boardPosition(x, y)) = -1 Then
                            pieces(index).setPieceValue(boardPosition(x, y))
                            pieces(index).setInitialPosition(x, y)
                            pieces(index).setIndex(index)
                            pieces(index).setTag(board(x, y).Tag)
                            index = index + 1
                        End If
                    ElseIf Math.Abs(boardPosition(x, y)) = 6 Then
                        If Math.Sign(boardPosition(x, y)) = 1 Then
                            pieces(index).setPieceValue(boardPosition(x, y))
                            pieces(index).setInitialPosition(x, y)
                            pieces(index).setIndex(index)
                            pieces(index).setTag(board(x, y).Tag)
                            index = index + 1
                        ElseIf Math.Sign(boardPosition(x, y)) = -1 Then
                            pieces(index).setPieceValue(boardPosition(x, y))
                            pieces(index).setInitialPosition(x, y)
                            pieces(index).setIndex(index)
                            pieces(index).setTag(board(x, y).Tag)
                            index = index + 1
                        End If
                    End If
                End If
            Next
        Next

        'This nested loop determines which piece image should be displayed on each picturebox
        For x = 0 To 7
            For y = 0 To 7
                If boardPosition(x, y) <> 0 Then
                    If boardPosition(x, y) = -1 Then
                        board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\black_king.png")
                    ElseIf boardPosition(x, y) = 1 Then
                        board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\white_king.png")
                    ElseIf boardPosition(x, y) = -2 Then
                        board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\black_queen.png")
                    ElseIf boardPosition(x, y) = 2 Then
                        board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\white_queen.png")
                    ElseIf boardPosition(x, y) = -3 Then
                        board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\black_bishop.png")
                    ElseIf boardPosition(x, y) = 3 Then
                        board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\white_bishop.png")
                    ElseIf boardPosition(x, y) = -4 Then
                        board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\black_knight.png")
                    ElseIf boardPosition(x, y) = 4 Then
                        board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\white_knight.png")
                    ElseIf boardPosition(x, y) = -5 Then
                        board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\black_rook.png")
                    ElseIf boardPosition(x, y) = 5 Then
                        board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\white_rook.png")
                    ElseIf boardPosition(x, y) = -6 Then
                        board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\black_pawn.png")
                    ElseIf boardPosition(x, y) = 6 Then
                        board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\white_pawn.png")
                    End If
                ElseIf boardPosition(x, y) = 0 Then
                    board(x, y).Image = Nothing
                End If
            Next
        Next

        white_move() 'Calls the white_move() subroutine and begins the game

    End Sub

    Sub white_move()

        turn = 0 'This variable expresses the current turn

        For x = 0 To 7
            For y = 0 To 7
                'The following code removes the opposite clickhandlers to stop
                'the other pieces from being moved as well as to improve performance
                RemoveHandler board(x, y).Click, AddressOf Black_ClickHandler
                If Math.Sign(boardPosition(x, y)) = 1 Then
                    'This code adds a clickhandler to each white piece, allowing the
                    'pieces to be moved
                    AddHandler board(x, y).Click, AddressOf White_ClickHandler
                End If
            Next
        Next

    End Sub

    Sub black_move()

        turn = 1 'This variable expresses the current turn

        For x = 0 To 7
            For y = 0 To 7
                'The following code removes the opposite clickhandlers to stop
                'the other pieces from being moved as well as to improve performance
                RemoveHandler board(x, y).Click, AddressOf White_ClickHandler
                If Math.Sign(boardPosition(x, y)) = -1 Then
                    'This code adds a clickhandler to each black piece, allowing the
                    'pieces to be moved
                    AddHandler board(x, y).Click, AddressOf Black_ClickHandler
                End If
            Next
        Next

    End Sub

    Sub White_ClickHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim tempArray(3)

        'This code gets the x and y of the piece that has just been clicked
        tempArray = Split(sender.tag, ",")
        currentx = tempArray(0)
        currenty = tempArray(1)

        'This loop uses the x and y to find the index that the current piece 
        'corresponds to
        For counter = 0 To 31
            If pieces(counter).GetX = currentx And pieces(counter).GetY = currenty And pieces(counter).getTeam = 1 Then
                whiteCurrentIndex = counter
            End If
        Next

        'The following block of code determines what type of piece the current
        'piece is and then calls the relevant subroutine
        If pieces(whiteCurrentIndex).getboardPositionValue = 1 Then
            white_king_move()
        ElseIf pieces(whiteCurrentIndex).getboardPositionValue = 2 Then
            white_queen_move()
        ElseIf pieces(whiteCurrentIndex).getboardPositionValue = 3 Then
            white_bishop_move()
        ElseIf pieces(whiteCurrentIndex).getboardPositionValue = 4 Then
            white_knight_move()
        ElseIf pieces(whiteCurrentIndex).getboardPositionValue = 5 Then
            white_rook_move()
        ElseIf pieces(whiteCurrentIndex).getboardPositionValue = 6 Then
            white_pawn_move()
        End If





    End Sub

    Sub Black_ClickHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim tempArray(3)

        'This code gets the x and y of the piece that has just been clicked
        tempArray = Split(sender.tag, ",")
        currentx = tempArray(0)
        currenty = tempArray(1)


        'This loop uses the x and y to find the index that the current piece 
        'corresponds to
        For counter = 0 To 31
            If pieces(counter).GetX = currentx And pieces(counter).GetY = currenty And pieces(counter).getTeam = -1 Then
                blackCurrentIndex = counter
            End If
        Next


        'The following block of code determines what type of piece the current
        'piece is and then calls the relevant subroutine
        If pieces(blackCurrentIndex).getboardPositionValue = -1 Then
            black_king_move()
        ElseIf pieces(blackCurrentIndex).getboardPositionValue = -2 Then
            black_queen_move()
        ElseIf pieces(blackCurrentIndex).getboardPositionValue = -3 Then
            black_bishop_move()
        ElseIf pieces(blackCurrentIndex).getboardPositionValue = -4 Then
            black_knight_move()
        ElseIf pieces(blackCurrentIndex).getboardPositionValue = -5 Then
            black_rook_move()
        ElseIf pieces(blackCurrentIndex).getboardPositionValue = -6 Then
            black_pawn_move()
        End If



    End Sub

    Sub white_king_move()

        'Use board object tag to pass data between sub and clickhandler
        Dim piecex As Integer
        Dim piecey As Integer

        piecex = currentx 'Placeholder variables are used so that the value of current x and y is not changed
        piecey = currenty

        currentPosition = 1
        whiteCurrentPosition = 1 'Sets the white current position 

        kingMove(piecex, piecey, -1)

    End Sub

    Sub white_queen_move()
        'Use board object tag to pass data between sub and clickhandler
        Dim piecex As Integer
        Dim piecey As Integer

        piecex = currentx 'Placeholder variables are used so that the value of current x and y is not changed
        piecey = currenty

        currentPosition = 2
        whiteCurrentPosition = 2 'Sets the current position 

        queenMove(piecex, piecey, -1)

    End Sub

    Sub white_bishop_move()
        'Use board object tag to pass data between sub and clickhandler
        Dim piecex As Integer
        Dim piecey As Integer

        piecex = currentx 'Placeholder variables are used so that the value of current x and y is not changed
        piecey = currenty

        currentPosition = 3
        whiteCurrentPosition = 3 'Sets the current position 

        bishopMove(piecex, piecey, -1)
    End Sub

    Sub white_knight_move()
        'Use board object tag to pass data between sub and clickhandler
        Dim piecex As Integer
        Dim piecey As Integer

        piecex = currentx 'Placeholder variables are used so that the value of current x and y is not changed
        piecey = currenty

        currentPosition = 4
        whiteCurrentPosition = 4 'Sets the current position 

        knightMove(piecex, piecey, -1)
    End Sub

    Sub white_rook_move()
        'Use board object tag to pass data between sub and clickhandler
        Dim piecex As Integer
        Dim piecey As Integer

        piecex = currentx 'Placeholder variables are used so that the value of current x and y is not changed
        piecey = currenty

        currentPosition = 5
        whiteCurrentPosition = 5

        rookMove(piecex, piecey, -1)

    End Sub

    Sub white_pawn_move()  'This subroutine calculates the available movement for all the white pawns
        Dim movetiles As Integer

        'This piece of code determines if the pawn should have one or two tiles of
        'movement
        If pieces(whiteCurrentIndex).getTurn = 1 Then
            movetiles = 2
            pieces(whiteCurrentIndex).setTurn(2)
        Else
            movetiles = 1
        End If

        'Use board object tag to pass data between sub and clickhandler
        Dim piecex As Integer
        Dim piecey As Integer

        piecex = currentx 'Placeholder variables are used so that the value of current x and y is not changed
        piecey = currenty

        currentPosition = 6
        whiteCurrentPosition = 6 'Sets the current position 

        If piecey > -1 And piecey < 8 Then

            If (piecey + movetiles) < 8 Then
                For counter = 1 To movetiles
                    If boardPosition(piecex, piecey + counter) = 0 Then 'If tile infront has no piece

                        'The following complex if statement determines if the piece can move to a diagonal, even if the space in front is clear

                        If ((piecex + 1) < 8 And (piecey + 1) < 8) Or ((piecex - 1) > -1 And (piecey + 1) < 8) Then

                            If (piecey + counter) < 8 Then 'Forward Movement
                                moveUpdate(piecex, piecey + counter)
                            End If

                            If (piecex + 1) < 8 And (piecey + 1) < 8 Then 'Right diagonal (from piece perspective) movement
                                If boardPosition(piecex + 1, piecey + 1) <> 0 And Math.Sign(boardPosition(piecex + 1, piecey + 1)) = -1 Then
                                    moveUpdate(piecex + 1, piecey + 1)
                                End If
                            End If

                            If (piecex - 1) > -1 And (piecey + 1) < 8 Then 'Left diagonal (from piece perspective) movement 
                                If boardPosition(piecex - 1, piecey + 1) <> 0 And Math.Sign(boardPosition(piecex - 1, piecey + 1)) = -1 Then
                                    moveUpdate(piecex - 1, piecey + 1)
                                End If
                            End If

                        Else

                            If (piecey + counter) < 8 Then 'Forward Movement
                                moveUpdate(piecex, piecey + counter)
                            End If

                        End If

                    ElseIf boardPosition(piecex, piecey + counter) <> 0 Then 'If tile infront has a piece

                        If (piecex + 1) < 8 And (piecey + 1) < 8 Then 'Right diagonal (from piece perspective) movement
                            If boardPosition(piecex + 1, piecey + 1) <> 0 And Math.Sign(boardPosition(piecex + 1, piecey + 1)) = -1 Then
                                moveUpdate(piecex + 1, piecey + 1)
                            End If
                        End If

                        If (piecex - 1) > -1 And (piecey + 1) < 8 Then 'Left diagonal (from piece perspective) movement 
                            If boardPosition(piecex - 1, piecey + 1) <> 0 And Math.Sign(boardPosition(piecex - 1, piecey + 1)) = -1 Then
                                moveUpdate(piecex - 1, piecey + 1)
                            End If
                        End If


                    End If
                Next
            End If
        End If
    End Sub

    Sub black_king_move()

        'Use board object tag to pass data between sub and clickhandler
        Dim piecex As Integer
        Dim piecey As Integer

        piecex = currentx 'Placeholder variables are used so that the value of current x and y is not changed
        piecey = currenty

        currentPosition = -1
        blackCurrentPosition = -1 'Sets the current position

        kingMove(piecex, piecey, 1)

    End Sub

    Sub black_queen_move()
        'Use board object tag to pass data between sub and clickhandler
        Dim piecex As Integer
        Dim piecey As Integer

        piecex = currentx 'Placeholder variables are used so that the value of current x and y is not changed
        piecey = currenty

        currentPosition = -2
        blackCurrentPosition = -2 'Sets the current position

        queenMove(piecex, piecey, 1)

    End Sub

    Sub black_bishop_move()
        'Use board object tag to pass data between sub and clickhandler
        Dim piecex As Integer
        Dim piecey As Integer

        piecex = currentx 'Placeholder variables are used so that the value of current x and y is not changed
        piecey = currenty

        currentPosition = -3
        blackCurrentPosition = -3 'Sets the current position

        bishopMove(piecex, piecey, 1)

    End Sub

    Sub black_knight_move()
        'Use board object tag to pass data between sub and clickhandler
        Dim piecex As Integer
        Dim piecey As Integer

        piecex = currentx 'Placeholder variables are used so that the value of current x and y is not changed
        piecey = currenty

        currentPosition = -4
        blackCurrentPosition = -4 'Sets the current position

        knightMove(piecex, piecey, 1)
    End Sub

    Sub black_rook_move()
        'Use board object tag to pass data between sub and clickhandler
        Dim piecex As Integer
        Dim piecey As Integer

        piecex = currentx 'Placeholder variables are used so that the value of current x and y is not changed
        piecey = currenty

        currentPosition = -5
        blackCurrentPosition = -5 'Sets the current position

        rookMove(piecex, piecey, 1)

    End Sub

    Sub black_pawn_move()  'This subroutine calculates the available movement for all the black pawns
        Dim movetiles As Integer

        'This piece of code determines if the pawn should have one or two tiles of
        'movement
        If pieces(blackCurrentIndex).getTurn = 1 Then
            movetiles = 2
            pieces(blackCurrentIndex).setTurn(2)
        Else
            movetiles = 1
        End If

        'Use board object tag to pass data between sub and clickhandler
        Dim piecex As Integer
        Dim piecey As Integer

        piecex = currentx 'Placeholder variables are used so that the value of current x and y is not changed
        piecey = currenty

        currentPosition = -6
        blackCurrentPosition = -6 'Sets the current position

        'There is no subroutine for both pawns as each move in only one direction

        If piecey > -1 And piecey < 8 Then

            If (piecey - movetiles) > -1 Then
                For counter = 1 To movetiles
                    If boardPosition(piecex, piecey - counter) = 0 Then 'If tile infront has no piece


                        'The following complex if statement determines if the piece can move to a diagonal, even if the space in front is clear

                        If ((piecex + 1) < 8 And (piecey - 1) > -1) Or ((piecex - 1) > -1 And (piecey - 1) > -1) Then

                            If (piecey - counter) > -1 Then 'Forward Movement
                                moveUpdate(piecex, piecey - counter)
                            End If

                            If (piecex + 1) < 8 And (piecey - 1) > -1 Then 'Right diagonal (from piece perspective) movement
                                If boardPosition(piecex + 1, piecey - 1) <> 0 And Math.Sign(boardPosition(piecex + 1, piecey - 1)) = 1 Then
                                    moveUpdate(piecex + 1, piecey - 1)
                                End If
                            End If

                            If (piecex - 1) > -1 And (piecey - 1) > -1 Then 'Left diagonal (from piece perspective) movement 
                                If boardPosition(piecex - 1, piecey - 1) <> 0 And Math.Sign(boardPosition(piecex - 1, piecey - 1)) = 1 Then
                                    moveUpdate(piecex - 1, piecey - 1)
                                End If
                            End If

                        Else

                            If (piecey - counter) > -1 Then 'Forward Movement
                                moveUpdate(piecex, piecey - counter)
                            End If

                        End If

                    ElseIf boardPosition(piecex, piecey - counter) <> 0 Then 'If tile infront has a piece

                        If (piecex + 1) < 8 And (piecey - 1) < 8 Then 'Right diagonal (from piece perspective) movement
                            If boardPosition(piecex + 1, piecey - 1) <> 0 And Math.Sign(boardPosition(piecex + 1, piecey - 1)) = 1 Then
                                moveUpdate(piecex + 1, piecey - 1)
                            End If
                        End If

                        If (piecex - 1) > -1 And (piecey - 1) < 8 Then 'Left diagonal (from piece perspective) movement 
                            If boardPosition(piecex - 1, piecey - 1) <> 0 And Math.Sign(boardPosition(piecex - 1, piecey - 1)) = 1 Then
                                moveUpdate(piecex - 1, piecey - 1)
                            End If
                        End If


                    End If
                Next
            End If
        End If
    End Sub

    Sub kingMove(ByVal piecex, ByVal piecey, ByVal enemyTeam) 'This subroutine calculates available movement for all the king pieces
        If piecey > -1 And piecey < 8 Then

            If ((piecex + 1) < 8 And (piecey + 1) < 8) Or ((piecex - 1) > -1 And (piecey + 1) < 8) Then 'Forward movements for White Team, Backwards movements for Black Team

                If (piecey + 1) < 8 And Math.Sign(boardPosition(piecex, piecey + 1)) <> -enemyTeam Then 'Forward for White Team, Backwards for Black Team
                    moveUpdate(piecex, piecey + 1)
                End If

                If (piecex + 1) < 8 And (piecey + 1) Then 'Right Forward diagonal for White, Right Backwards diagonal for Black 
                    If boardPosition(piecex + 1, piecey + 1) = 0 Or Math.Sign(boardPosition(piecex + 1, piecey + 1)) = enemyTeam Then
                        moveUpdate(piecex + 1, piecey + 1)
                    End If
                End If

                If (piecex - 1) > -1 And (piecey + 1) < 8 Then 'Left Forward diagonal for white, left backwards diagonal for black
                    If boardPosition(piecex - 1, piecey + 1) = 0 Or Math.Sign(boardPosition(piecex - 1, piecey + 1)) = enemyTeam Then
                        moveUpdate(piecex - 1, piecey + 1)
                    End If
                End If

            End If

            If ((piecex + 1) < 8 And (piecey - 1) > -1) Or ((piecex - 1) < 8 And (piecey - 1) > -1) Then 'Backwards Movements for white, forward movements for black

                If (piecey - 1) < 8 And Math.Sign(boardPosition(piecex, piecey - 1)) <> -enemyTeam Then 'Backward for white, forward for black
                    moveUpdate(piecex, piecey - 1)
                End If

                If (piecex + 1) < 8 And (piecey - 1) > -1 Then 'Right Backward diagonal for white, right forward diagonal for black
                    If boardPosition(piecex + 1, piecey - 1) = 0 Or Math.Sign(boardPosition(piecex + 1, piecey - 1)) = enemyTeam Then
                        moveUpdate(piecex + 1, piecey - 1)
                    End If
                End If

                If (piecex - 1) > -1 And (piecey - 1) < 8 Then 'Left Backward diagonal for white, right forward diagonal for black
                    If boardPosition(piecex - 1, piecey - 1) = 0 Or Math.Sign(boardPosition(piecex - 1, piecey - 1)) = enemyTeam Then
                        moveUpdate(piecex - 1, piecey - 1)
                    End If
                End If

            End If

            If (piecex + 1) < 8 Or (piecex - 1) > -1 Then 'Side Movements (from piece Perspective)

                If (piecex + 1) < 8 Then 'Right Movement (From Piece Perspective)
                    If boardPosition(piecex + 1, piecey) = 0 Or Math.Sign(boardPosition(piecex + 1, piecey)) = enemyTeam Then
                        moveUpdate(piecex + 1, piecey)
                    End If
                End If

                If (piecex - 1) > -1 Then  'Left Movement (From Piece Perspective)
                    If boardPosition(piecex - 1, piecey) = 0 Or Math.Sign(boardPosition(piecex - 1, piecey)) = enemyTeam Then
                        moveUpdate(piecex - 1, piecey)
                    End If
                End If


            End If


        End If
    End Sub

    Sub queenMove(ByVal piecex, ByVal piecey, ByVal enemyteam) 'This subroutine calculates the available movement for all the queen pieces
        Dim diagY As Integer

        If piecey > -1 And piecey < 8 Then

            If ((piecex + 1) < 8 And (piecey + 1) < 8) Or ((piecex - 1) > -1 And (piecey + 1) < 8) Then 'Forward Movements for white, backwards movements for black
                If (piecey + 1) < 8 And (Math.Sign(boardPosition(piecex, piecey + 1)) = enemyteam Or boardPosition(piecex, piecey + 1) = 0) Then 'Forward Movement for white, backwards movement for black

                    For counter = piecey + 1 To 7
                        If boardPosition(piecex, counter) = 0 Then
                            moveUpdate(piecex, counter)
                        ElseIf Math.Sign(boardPosition(piecex, counter)) = -enemyteam Then
                            Exit For
                        ElseIf Math.Sign(boardPosition(piecex, counter)) = enemyteam Then
                            moveUpdate(piecex, counter)
                            Exit For
                        End If
                    Next

                End If
            End If

            If ((piecex + 1) < 8 And (piecey - 1) > -1) Or ((piecex - 1) < 8 And (piecey - 1) > -1) Then 'Backwards Movements for white, forwards movements for black
                If (piecey - 1) < 8 And (Math.Sign(boardPosition(piecex, piecey - 1)) = enemyteam Or boardPosition(piecex, piecey - 1) = 0) Then 'Backward Movement for white, backwards movement for black

                    For counter = piecey - 1 To 0 Step -1
                        If boardPosition(piecex, counter) = 0 Then
                            moveUpdate(piecex, counter)
                        ElseIf Math.Sign(boardPosition(piecex, counter)) = -enemyteam Then
                            Exit For
                        ElseIf Math.Sign(boardPosition(piecex, counter)) = enemyteam Then
                            moveUpdate(piecex, counter)
                            Exit For
                        End If
                    Next

                End If
            End If

            If (piecex + 1) < 8 Or (piecex - 1) > -1 Then 'Side Movements (from piece Perspective)

                If (piecex + 1) < 8 Then 'Right Movement (From Piece Perspective)
                    If boardPosition(piecex + 1, piecey) = 0 Or Math.Sign(boardPosition(piecex + 1, piecey)) = enemyteam Then

                        For counter = piecex + 1 To 7
                            If boardPosition(counter, piecey) = 0 Then
                                moveUpdate(counter, piecey)
                            ElseIf Math.Sign(boardPosition(counter, piecey)) = -enemyteam Then
                                Exit For
                            ElseIf Math.Sign(boardPosition(counter, piecey)) = enemyteam Then
                                moveUpdate(counter, piecey)
                                Exit For
                            End If
                        Next

                    End If
                End If

                If (piecex - 1) > -1 Then  'Left Movement (From Piece Perspective)
                    If boardPosition(piecex - 1, piecey) = 0 Or Math.Sign(boardPosition(piecex - 1, piecey)) = enemyteam Then


                        For counter = piecex - 1 To 0 Step -1
                            If boardPosition(counter, piecey) = 0 Then
                                moveUpdate(counter, piecey)
                            ElseIf Math.Sign(boardPosition(counter, piecey)) = -enemyteam Then
                                Exit For
                            ElseIf Math.Sign(boardPosition(counter, piecey)) = enemyteam Then
                                moveUpdate(counter, piecey)
                                Exit For
                            End If
                        Next

                    End If
                End If

            End If

            If ((piecex + 1) < 8 And (piecey + 1) < 8) Or ((piecex - 1) > -1 And (piecey + 1) < 8) Then 'Forward Movements for white , backwards movements for black

                If (piecex + 1) < 8 And (piecey + 1) Then 'Right diagonal (from piece perspective) movement
                    If boardPosition(piecex + 1, piecey + 1) = 0 Or Math.Sign(boardPosition(piecex + 1, piecey + 1)) = enemyteam Then

                        diagY = piecey

                        For counter = piecex + 1 To 7
                            If diagY + 1 < 8 Then
                                If boardPosition(counter, diagY + 1) = 0 Then
                                    moveUpdate(counter, diagY + 1)
                                ElseIf Math.Sign(boardPosition(counter, diagY + 1)) = -enemyteam Then
                                    Exit For
                                ElseIf Math.Sign(boardPosition(counter, diagY + 1)) = enemyteam Then
                                    moveUpdate(counter, diagY + 1)
                                    Exit For
                                End If

                                diagY = diagY + 1
                            End If
                        Next

                    End If
                End If

                If (piecex - 1) > -1 And (piecey + 1) < 8 Then 'Left diagonal (from piece perspective) movement 
                    If boardPosition(piecex - 1, piecey + 1) = 0 Or Math.Sign(boardPosition(piecex - 1, piecey + 1)) = enemyteam Then

                        diagY = piecey

                        For counter = piecex - 1 To 0 Step -1
                            If diagY + 1 < 8 Then
                                If boardPosition(counter, diagY + 1) = 0 Then
                                    moveUpdate(counter, diagY + 1)
                                ElseIf Math.Sign(boardPosition(counter, diagY + 1)) = -enemyteam Then
                                    Exit For
                                ElseIf Math.Sign(boardPosition(counter, diagY + 1)) = enemyteam Then
                                    moveUpdate(counter, diagY + 1)
                                    Exit For
                                End If

                                diagY = diagY + 1
                            End If
                        Next
                    End If
                End If

            End If

            If ((piecex + 1) < 8 And (piecey - 1) > -1) Or ((piecex - 1) < 8 And (piecey - 1) > -1) Then 'Backwards Movements for white, forward movements for black

                If (piecex + 1) < 8 And (piecey - 1) > -1 Then 'Right Backward diagonal for white, right forward diagonal for black 
                    If boardPosition(piecex + 1, piecey - 1) = 0 Or Math.Sign(boardPosition(piecex + 1, piecey - 1)) = enemyteam Then

                        diagY = piecey

                        For counter = piecex + 1 To 7
                            If diagY - 1 > -1 Then
                                If boardPosition(counter, diagY - 1) = 0 Then
                                    moveUpdate(counter, diagY - 1)
                                ElseIf Math.Sign(boardPosition(counter, diagY - 1)) = -enemyteam Then
                                    Exit For
                                ElseIf Math.Sign(boardPosition(counter, diagY - 1)) = enemyteam Then
                                    moveUpdate(counter, diagY - 1)
                                    Exit For
                                End If

                                diagY = diagY - 1
                            End If
                        Next
                    End If
                End If

                If (piecex - 1) > -1 And (piecey - 1) > -1 Then 'Left Backward diagonal for white, left forward diagonal for black 
                    If boardPosition(piecex - 1, piecey - 1) = 0 Or Math.Sign(boardPosition(piecex - 1, piecey - 1)) = enemyteam Then

                        diagY = piecey


                        For counter = piecex - 1 To 0 Step -1
                            If diagY - 1 > -1 Then
                                If boardPosition(counter, diagY - 1) = 0 Then
                                    moveUpdate(counter, diagY - 1)
                                ElseIf Math.Sign(boardPosition(counter, diagY - 1)) = -enemyteam Then
                                    Exit For
                                ElseIf Math.Sign(boardPosition(counter, diagY - 1)) = enemyteam Then
                                    moveUpdate(counter, diagY - 1)
                                    Exit For
                                End If

                                diagY = diagY - 1
                            End If
                        Next
                    End If
                End If

            End If

        End If
    End Sub

    Sub bishopMove(ByVal piecex, ByVal piecey, ByVal enemyteam)  'This subroutine calculates the available movement for all the bishop pieces
        Dim diagY As Integer

        If ((piecex + 1) < 8 And (piecey + 1) < 8) Or ((piecex - 1) > -1 And (piecey + 1) < 8) Then 'Forward Movements for white , backwards movements for black

            If (piecex + 1) < 8 And (piecey + 1) Then 'Right diagonal (from piece perspective) movement
                If boardPosition(piecex + 1, piecey + 1) = 0 Or Math.Sign(boardPosition(piecex + 1, piecey + 1)) = enemyteam Then

                    diagY = piecey

                    For counter = piecex + 1 To 7
                        If diagY + 1 < 8 Then
                            If boardPosition(counter, diagY + 1) = 0 Then
                                moveUpdate(counter, diagY + 1)
                            ElseIf Math.Sign(boardPosition(counter, diagY + 1)) = -enemyteam Then
                                Exit For
                            ElseIf Math.Sign(boardPosition(counter, diagY + 1)) = enemyteam Then
                                moveUpdate(counter, diagY + 1)
                                Exit For
                            End If

                            diagY = diagY + 1
                        End If
                    Next

                End If
            End If

            If (piecex - 1) > -1 And (piecey + 1) < 8 Then 'Left diagonal (from piece perspective) movement 
                If boardPosition(piecex - 1, piecey + 1) = 0 Or Math.Sign(boardPosition(piecex - 1, piecey + 1)) = enemyteam Then

                    diagY = piecey

                    For counter = piecex - 1 To 0 Step -1
                        If diagY + 1 < 8 Then
                            If boardPosition(counter, diagY + 1) = 0 Then
                                moveUpdate(counter, diagY + 1)
                            ElseIf Math.Sign(boardPosition(counter, diagY + 1)) = -enemyteam Then
                                Exit For
                            ElseIf Math.Sign(boardPosition(counter, diagY + 1)) = enemyteam Then
                                moveUpdate(counter, diagY + 1)
                                Exit For
                            End If

                            diagY = diagY + 1
                        End If
                    Next
                End If
            End If

        End If

        If ((piecex + 1) < 8 And (piecey - 1) > -1) Or ((piecex - 1) < 8 And (piecey - 1) > -1) Then 'Backwards Movements for white, forward movements for black

            If (piecex + 1) < 8 And (piecey - 1) > -1 Then 'Right Backward diagonal for white, right forward diagonal for black 
                If boardPosition(piecex + 1, piecey - 1) = 0 Or Math.Sign(boardPosition(piecex + 1, piecey - 1)) = enemyteam Then

                    diagY = piecey

                    For counter = piecex + 1 To 7
                        If diagY - 1 > -1 Then
                            If boardPosition(counter, diagY - 1) = 0 Then
                                moveUpdate(counter, diagY - 1)
                            ElseIf Math.Sign(boardPosition(counter, diagY - 1)) = -enemyteam Then
                                Exit For
                            ElseIf Math.Sign(boardPosition(counter, diagY - 1)) = enemyteam Then
                                moveUpdate(counter, diagY - 1)
                                Exit For
                            End If

                            diagY = diagY - 1
                        End If
                    Next
                End If
            End If

            If (piecex - 1) > -1 And (piecey - 1) > -1 Then 'Left Backward diagonal for white, left forward diagonal for black 
                If boardPosition(piecex - 1, piecey - 1) = 0 Or Math.Sign(boardPosition(piecex - 1, piecey - 1)) = enemyteam Then

                    diagY = piecey


                    For counter = piecex - 1 To 0 Step -1
                        If diagY - 1 > -1 Then
                            If boardPosition(counter, diagY - 1) = 0 Then
                                moveUpdate(counter, diagY - 1)
                            ElseIf Math.Sign(boardPosition(counter, diagY - 1)) = -enemyteam Then
                                Exit For
                            ElseIf Math.Sign(boardPosition(counter, diagY - 1)) = enemyteam Then
                                moveUpdate(counter, diagY - 1)
                                Exit For
                            End If

                            diagY = diagY - 1
                        End If
                    Next
                End If
            End If

        End If
    End Sub

    Sub knightMove(ByVal piecex, ByVal piecey, ByVal enemyteam)  'This subroutine calculates the available movement for all the knight pieces
        If piecey > -1 And piecey < 8 Then

            If (piecey + 2) < 8 And ((piecex + 1) < 8 Or (piecex - 1) < 8) Then 'Forward vertical + 2,horizontal + 1 moves for white, Backwards vertical + 2, horizontal + 1 for black

                If (piecex + 1) < 8 Then 'Left (from piece perspective) move
                    If boardPosition(piecex + 1, piecey + 2) = 0 Or Math.Sign(boardPosition(piecex + 1, piecey + 2)) = enemyteam Then
                        moveUpdate(piecex + 1, piecey + 2)
                    End If
                End If

                If (piecex - 1) > -1 Then 'Right (from piece perspective) move
                    If boardPosition(piecex - 1, piecey + 2) = 0 Or Math.Sign(boardPosition(piecex - 1, piecey + 2)) = enemyteam Then
                        moveUpdate(piecex - 1, piecey + 2)
                    End If
                End If


            End If

            If (piecey + 1) < 8 And ((piecex + 2) < 8 Or (piecex - 2) < 8) Then 'Forward vertical + 1,horizontal + 2 moves for white, backwards vertical + 1,horizontal + 2 for black

                If (piecex + 2) < 8 Then 'Left (from piece perspective) move
                    If boardPosition(piecex + 2, piecey + 1) = 0 Or Math.Sign(boardPosition(piecex + 2, piecey + 1)) = enemyteam Then
                        moveUpdate(piecex + 2, piecey + 1)
                    End If
                End If

                If (piecex - 2) > -1 Then 'Right (from piece perspective) move
                    If boardPosition(piecex - 2, piecey + 1) = 0 Or Math.Sign(boardPosition(piecex - 2, piecey + 1)) = enemyteam Then
                        moveUpdate(piecex - 2, piecey + 1)
                    End If
                End If

            End If

            If (piecey - 2) > -1 And ((piecex + 1) < 8 Or (piecex - 1) < 8) Then 'Backwards vertical + 2,horizontal + 1 moves for white, forwards vertical + 2,horizontal + 1 moves 

                If (piecex + 1) < 8 Then 'Left (from piece perspective) move
                    If boardPosition(piecex + 1, piecey - 2) = 0 Or Math.Sign(boardPosition(piecex + 1, piecey - 2)) = enemyteam Then
                        moveUpdate(piecex + 1, piecey - 2)
                    End If
                End If

                If (piecex - 1) > -1 Then 'Right (from piece perspective) move
                    If boardPosition(piecex - 1, piecey - 2) = 0 Or Math.Sign(boardPosition(piecex - 1, piecey - 2)) = enemyteam Then
                        moveUpdate(piecex - 1, piecey - 2)
                    End If
                End If


            End If

            If (piecey - 1) > -1 And ((piecex + 2) < 8 Or (piecex - 2) < 8) Then 'Backwards vertical + 1,horizontal + 2 moves for white, forwards vertical + 1,horizontal + 2 moves for black

                If (piecex + 2) < 8 Then 'Left (from piece perspective) move
                    If boardPosition(piecex + 2, piecey - 1) = 0 Or Math.Sign(boardPosition(piecex + 2, piecey - 1)) = enemyteam Then
                        moveUpdate(piecex + 2, piecey - 1)
                    End If
                End If

                If (piecex - 2) > -1 Then 'Right (from piece perspective) move
                    If boardPosition(piecex - 2, piecey - 1) = 0 Or Math.Sign(boardPosition(piecex - 2, piecey - 1)) = enemyteam Then
                        moveUpdate(piecex - 2, piecey - 1)
                    End If
                End If

            End If

        End If
    End Sub

    Sub rookMove(ByVal piecex, ByVal piecey, ByVal enemyteam)  'This subroutine calculates the available movement for all the rook pieces

        If piecey > -1 And piecey < 8 Then

            If ((piecex + 1) < 8 And (piecey + 1) < 8) Or ((piecex - 1) > -1 And (piecey + 1) < 8) Then 'Forward Movements for white, backwards movements for black
                If (piecey + 1) < 8 And (Math.Sign(boardPosition(piecex, piecey + 1)) = enemyteam Or boardPosition(piecex, piecey + 1) = 0) Then 'Forward Movement for white, backwards movement for black

                    For counter = piecey + 1 To 7
                        If boardPosition(piecex, counter) = 0 Then
                            moveUpdate(piecex, counter)
                        ElseIf Math.Sign(boardPosition(piecex, counter)) = -enemyteam Then
                            Exit For
                        ElseIf Math.Sign(boardPosition(piecex, counter)) = enemyteam Then
                            moveUpdate(piecex, counter)
                            Exit For
                        End If
                    Next

                End If
            End If

            If ((piecex + 1) < 8 And (piecey - 1) > -1) Or ((piecex - 1) < 8 And (piecey - 1) > -1) Then 'Backwards Movements for white, forwards movements for black
                If (piecey - 1) < 8 And (Math.Sign(boardPosition(piecex, piecey - 1)) = enemyteam Or boardPosition(piecex, piecey - 1) = 0) Then 'Backward Movement for white, backwards movement for black

                    For counter = piecey - 1 To 0 Step -1
                        If boardPosition(piecex, counter) = 0 Then
                            moveUpdate(piecex, counter)
                        ElseIf Math.Sign(boardPosition(piecex, counter)) = -enemyteam Then
                            Exit For
                        ElseIf Math.Sign(boardPosition(piecex, counter)) = enemyteam Then
                            moveUpdate(piecex, counter)
                            Exit For
                        End If
                    Next

                End If
            End If

            If (piecex + 1) < 8 Or (piecex - 1) > -1 Then 'Side Movements (from piece Perspective)

                If (piecex + 1) < 8 Then 'Right Movement (From Piece Perspective)
                    If boardPosition(piecex + 1, piecey) = 0 Or Math.Sign(boardPosition(piecex + 1, piecey)) = enemyteam Then

                        For counter = piecex + 1 To 7
                            If boardPosition(counter, piecey) = 0 Then
                                moveUpdate(counter, piecey)
                            ElseIf Math.Sign(boardPosition(counter, piecey)) = -enemyteam Then
                                Exit For
                            ElseIf Math.Sign(boardPosition(counter, piecey)) = enemyteam Then
                                moveUpdate(counter, piecey)
                                Exit For
                            End If
                        Next

                    End If
                End If

                If (piecex - 1) > -1 Then  'Left Movement (From Piece Perspective)
                    If boardPosition(piecex - 1, piecey) = 0 Or Math.Sign(boardPosition(piecex - 1, piecey)) = enemyteam Then


                        For counter = piecex - 1 To 0 Step -1
                            If boardPosition(counter, piecey) = 0 Then
                                moveUpdate(counter, piecey)
                            ElseIf Math.Sign(boardPosition(counter, piecey)) = -enemyteam Then
                                Exit For
                            ElseIf Math.Sign(boardPosition(counter, piecey)) = enemyteam Then
                                moveUpdate(counter, piecey)
                                Exit For
                            End If
                        Next

                    End If
                End If
            End If

        End If
    End Sub

    Sub moveUpdate(ByVal piecex, ByVal piecey)

        board(piecex, piecey).BackColor = Color.LightBlue 'Highlights the potential move

        'Updates the tag of the board that is potentially being moved to
        board(piecex, piecey).Tag = piecex & "," & piecey & "," & currentx & "," & currenty

        'The following code decides what clickhandler should be created
        'based on what turn it is
        If Math.Sign(currentPosition) = 1 And turn = 0 Then
            AddHandler board(piecex, piecey).Click, AddressOf whitepieceMove
        ElseIf Math.Sign(currentPosition) = -1 And turn = 1 Then
            AddHandler board(piecex, piecey).Click, AddressOf blackpieceMove
        End If




    End Sub

    Sub whitepieceMove(ByVal sender As Object, ByVal e As EventArgs)

        Dim pieceX As Integer
        Dim pieceY As Integer
        Dim origX As Integer
        Dim origY As Integer
        Dim tempArray(3) As String
        Dim index As Integer

        'This code gets the current and previous sets of x and ys of the piece
        'that was just clicked
        tempArray = Split(sender.tag, ",")
        pieceX = tempArray(0)
        pieceY = tempArray(1)
        origX = tempArray(2)
        origY = tempArray(3)

        'Sets the previous position's value as 0 and removes its image
        boardPosition(origX, origY) = 0
        board(origX, origY).Image = Nothing

        index = whiteCurrentIndex

        RichTextBox3.Text = "black" 'Displays the next turn

        'The following code determines if a promotion can occur and if it can,
        'what piece the player wishes to promote the pawn to
        Dim promotion As String

        promotion = "no"

        If pieceY = 7 And whiteCurrentPosition = 6 Then
            promotion = InputBox("Do you wish to promote this piece, enter 'yes' or 'no' ")
        End If

        If promotion = "yes" Then
            whiteCurrentPosition = InputBox("Please enter which piece you wish to promote to (queen = 2, bishop = 3, knight = 4, rook = 5")
        End If

        'Calls the whiteupdateboard() subroutine
        whiteupdateBoard(pieceX, pieceY, index)

        'Calls the black_move() subroutine, starting the next turn
        black_move()
    End Sub

    Sub blackpieceMove(ByVal sender As Object, ByVal e As EventArgs)

        Dim pieceX As Integer
        Dim pieceY As Integer
        Dim origX As Integer
        Dim origY As Integer
        Dim tempArray(3) As String
        Dim index As Integer

        'This code gets the current and previous sets of x and ys of the piece
        'that was just clicked
        tempArray = Split(sender.tag, ",")
        pieceX = tempArray(0)
        pieceY = tempArray(1)
        origX = tempArray(2)
        origY = tempArray(3)

        'Sets the previous position's value as 0 and removes its image
        boardPosition(origX, origY) = 0
        board(origX, origY).Image = Nothing

        index = blackCurrentIndex

        RichTextBox3.Text = "white" 'Displays the next turn

        'The following code determines if a promotion can occur and if it can,
        'what piece the player wishes to promote the pawn to
        Dim promotion As String

        promotion = "no"

        If pieceY = 0 And blackCurrentPosition = -6 Then
            promotion = InputBox("Do you wish to promote this piece, enter 'yes' or 'no' ")
        End If

        If promotion = "yes" Then
            blackCurrentPosition = InputBox("Please enter which piece you wish to promote to (queen = -2, bishop = -3, knight = -4, rook = -5")
        End If

        'Calls the blackupdateboard() subroutine
        blackupdateboard(pieceX, pieceY, index)

        'Calls the white_move() subroutine, starting the next turn
        white_move()

    End Sub

    Sub whiteupdateBoard(ByVal x, ByVal y, ByVal index)

        'If a piece is about to be taken, then this code displays that piece
        If Math.Sign(boardPosition(x, y)) = -1 Then
            If boardPosition(x, y) = -1 Then
                RichTextBox1.AppendText("♚")
            ElseIf boardPosition(x, y) = -2 Then
                RichTextBox1.AppendText("♛")
            ElseIf boardPosition(x, y) = -3 Then
                RichTextBox1.AppendText("♝")
            ElseIf boardPosition(x, y) = -4 Then
                RichTextBox1.AppendText("♞")
            ElseIf boardPosition(x, y) = -5 Then
                RichTextBox1.AppendText("♜")
            ElseIf boardPosition(x, y) = -6 Then
                RichTextBox1.AppendText("♟︎")
            End If
        End If

        boardPosition(x, y) = whiteCurrentPosition 'Sets the new boardposition
        pieces(index).setX(x) 'Updates the values of various properties for the piece
        pieces(index).setY(y)
        pieces(index).setPieceValue(whiteCurrentPosition)
        board(x, y).Tag = x & "," & y & "," & originalX & "," & originalY
        redrawBoard(x, y) 'Calls the redrawBoard subroutine and pases parameters x and y

    End Sub

    Sub blackupdateboard(ByVal x, ByVal y, ByVal index)

        'If a piece is about to be taken, then this code displays that piece
        If Math.Sign(boardPosition(x, y)) = 1 Then
            If boardPosition(x, y) = 1 Then
                RichTextBox2.AppendText("♚")
            ElseIf boardPosition(x, y) = 2 Then
                RichTextBox2.AppendText("♛")
            ElseIf boardPosition(x, y) = 3 Then
                RichTextBox2.AppendText("♝")
            ElseIf boardPosition(x, y) = 4 Then
                RichTextBox2.AppendText("♞")
            ElseIf boardPosition(x, y) = 5 Then
                RichTextBox2.AppendText("♜")
            ElseIf boardPosition(x, y) = 6 Then
                RichTextBox2.AppendText("♟︎")
            End If
        End If

        boardPosition(x, y) = blackCurrentPosition 'Sets the new boardposition
        pieces(index).setX(x)  'Updates the values of various properties for the piece
        pieces(index).setY(y)
        pieces(index).setPieceValue(blackCurrentPosition)
        board(x, y).Tag = x & "," & y & "," & originalX & "," & originalY
        redrawBoard(x, y) 'Calls the redrawBoard subroutine and passes parameters x and y
    End Sub

    Sub redrawBoard(ByVal x, ByVal y)

        'Determines what image the target picturebox should display
        If boardPosition(x, y) <> 0 Then
            If boardPosition(x, y) = -1 Then
                board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\black_king.png")
            ElseIf boardPosition(x, y) = 1 Then
                board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\white_king.png")
            ElseIf boardPosition(x, y) = -2 Then
                board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\black_queen.png")
            ElseIf boardPosition(x, y) = 2 Then
                board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\white_queen.png")
            ElseIf boardPosition(x, y) = -3 Then
                board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\black_bishop.png")
            ElseIf boardPosition(x, y) = 3 Then
                board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\white_bishop.png")
            ElseIf boardPosition(x, y) = -4 Then
                board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\black_knight.png")
            ElseIf boardPosition(x, y) = 4 Then
                board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\white_knight.png")
            ElseIf boardPosition(x, y) = -5 Then
                board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\black_rook.png")
            ElseIf boardPosition(x, y) = 5 Then
                board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\white_rook.png")
            ElseIf boardPosition(x, y) = -6 Then
                board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\black_pawn.png")
            ElseIf boardPosition(x, y) = 6 Then
                board(x, y).Image = Image.FromFile("H:\S6 Advanced Higher\Computing\Project\Chess Pieces\white_pawn.png")
            End If
        ElseIf boardPosition(x, y) = 0 Then
            board(x, y).Image = Nothing
        End If


        For counterx = 0 To 7
            For countery = 0 To 7
                'Removes any excess click handlers to stop bugs
                RemoveHandler board(counterx, countery).Click, AddressOf blackpieceMove
                RemoveHandler board(counterx, countery).Click, AddressOf whitepieceMove

                'Removes highlights from board and resets board colours back to 
                'default
                If (counterx Mod 2) = 0 Then
                    board(counterx, countery).BackColor = Color.DarkGray
                Else
                    board(counterx, countery).BackColor = Color.White
                End If
                If countery > 0 Then
                    If board(counterx, countery - 1).BackColor = Color.DarkGray Then
                        board(counterx, countery).BackColor = Color.White
                    ElseIf board(counterx, countery - 1).BackColor = Color.White Then
                        board(counterx, countery).BackColor = Color.DarkGray
                    End If
                End If
            Next
        Next

    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click

        'Sets up variables that are going to be used
        Dim connStr As String = "server=localhost;user=root;password=;database=chessdata"
        Dim conn As New MySqlConnection(connStr)
        Dim cmd As MySqlCommand
        Dim reader As MySqlDataReader

        'Checks to see if the connection is open
        Try
            Console.WriteLine("Connecting to MySQL...")
            conn.Open()
        Catch ex As Exception
            Console.WriteLine(ex.ToString())
            MsgBox("Failed")
        End Try

        Dim winningUsername As String

        'Determines the winning username and displays the winning player's name
        If turn = 0 Then
            MsgBox(player(1) & " has won the Game!")
            winningUsername = player(1)
        ElseIf turn = 1 Then
            MsgBox(player(0) & " has won the Game!")
            winningUsername = player(0)
        End If

        Dim exists As Boolean = False
        Dim numberOfWins As Integer = 0

        'Sets up the sql command and assigns the result(s) to reader
        cmd = New MySqlCommand("SELECT * FROM players")
        cmd.Connection = conn
        reader = cmd.ExecuteReader()

        'Determines if the winnning Username already exists in the database
        While reader.Read()
            If reader.GetString("username") = winningUsername Then
                exists = True
                numberOfWins = reader.GetString("matchesWon")
            End If
        End While

        conn.Close() 'Close connection

        'If the winning username already exists, an update statement is used to add 
        'one to the current number of matches won
        If exists = True Then
            conn.Open()
            cmd = New MySqlCommand("UPDATE players SET matchesWon = '" & numberOfWins + 1 & "' WHERE username = '" & winningUsername & "' ; ")
            cmd.Connection = conn
            cmd.ExecuteNonQuery()
            conn.Close()
        Else
            'If the winning username does not exists, a new record is inserted into
            'the database with number of matches won as 1
            conn.Open()
            cmd = New MySqlCommand("INSERT INTO players(username,matchesWon) VALUES( '" & winningUsername & "' , 1);")
            cmd.Connection = conn
            cmd.ExecuteNonQuery()
            conn.Close()
        End If

        MainMenu.Show() 'Shows the main menu
        Me.Hide() 'Hides this form
    End Sub


End Class
