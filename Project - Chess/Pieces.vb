Public Class Pieces
    Private initialx As Integer
    Private initialy As Integer
    Private pieceValue As Integer
    Private team As Integer '+ve for white, -ve for black
    Private index As Integer 'position in pieces array
    Private x As Integer
    Private y As Integer
    Private moves As Integer
    Private tag As String 'Corresponds to tag of board piece
    Private boardPositionValue As Integer 'Corresponds to the 2D array boardPositionValue
    Private turn As Integer = 1

    'The following functions act as setters for the various properties of the class

    Sub setPieceValue(ByVal boardPositionValue)
        Me.pieceValue = Math.Abs(boardPositionValue)
        Me.team = Math.Sign(boardPositionValue)
        Me.boardPositionValue = Me.pieceValue * Me.team
    End Sub

    Sub setTag(ByVal Tag)
        Me.tag = Tag
    End Sub
    Sub setInitialPosition(ByVal x, ByVal y)
        Me.initialx = x
        Me.initialy = y
        Me.x = x
        Me.y = y
    End Sub

    Sub setMoves(ByVal moves)
        Me.moves = moves
    End Sub

    Sub setX(ByVal x)
        Me.x = x
    End Sub

    Sub setY(ByVal y)
        Me.y = y
    End Sub
    Sub setIndex(ByVal index)
        Me.index = index
    End Sub

    Sub setTeam(ByVal team)
        Me.team = team
    End Sub

    Sub setTurn(ByVal Turn)
        Me.turn = Turn
    End Sub

    'The following functions act as getters for the various properties of the class

    Function getboardPositionValue()
        Return Me.boardPositionValue
    End Function
    Function getInitialX()
        Return Me.initialx
    End Function

    Function getInitialY()
        Return Me.initialy
    End Function
    Function getTag()
        Return Me.tag
    End Function
    Function GetX()
        Return Me.x
    End Function

    Function GetY()
        Return Me.y
    End Function

    Function getMove()
        Return Me.moves
    End Function

    Function getPieceValue()
        Return Me.pieceValue
    End Function

    Function getIndex()
        Return Me.index
    End Function

    Function getTeam()
        Return Me.team
    End Function

    Function getTurn()
        Return Me.turn
    End Function
End Class
