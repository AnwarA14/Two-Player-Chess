Public Class MainMenu

    Public username1 As String
    Public username2 As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'This code ensures that two usernames have been entered
        If username1 <> "" And username2 <> "" Then
            Game.Show() 'Starts the game
            Me.Hide()
        Else
            MsgBox("You have not entered one or more usernames, re-enter to proceed")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Gets username input and displays the usernames
        username1 = InputBox("Please enter the username of player 1")
        username2 = InputBox("Please enter the username of player 2")

        RichTextBox1.Text = "Player 1 is " & username1 & vbNewLine & "Player 2 is " & username2
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Leaderboard.Show() 'Shows the leaderboard
        Me.Hide() 'Hides this form
    End Sub

End Class