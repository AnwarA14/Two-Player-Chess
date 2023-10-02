Imports MySql.Data.MySqlClient

Public Class Leaderboard

    Structure queryData
        Dim username As String
        Dim matchesWon As Integer
    End Structure

    Private Sub Leaderboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim connStr As String = "server=localhost;user=root;password=;database=chessdata"
        Dim conn As New MySqlConnection(connStr)
        Dim cmd As MySqlCommand
        Dim reader As MySqlDataReader

        Try 'Checks to see if the connection is open
            Console.WriteLine("Connecting to MySQL...")
            conn.Open()
        Catch ex As Exception
            Console.WriteLine(ex.ToString())
            MsgBox("Failed")
        End Try

        'Queries the database for all records and assigns the value to reader
        cmd = New MySqlCommand("SELECT * FROM players;")
        cmd.Connection = conn
        reader = cmd.ExecuteReader

        Dim numberOfRows As Integer = -1

        'Counts the number of rows
        While reader.Read()
            numberOfRows = numberOfRows + 1
        End While

        conn.Close()

        'Creates an array ,with index of number of rows, of query data
        Dim resultData(numberOfRows) As queryData

        conn.Open()

        'Queries the database for all records and assigns the value to reader
        cmd = New MySqlCommand("SELECT * FROM players;")
        cmd.Connection = conn
        reader = cmd.ExecuteReader

        numberOfRows = -1

        'Assigns the relevant data from the database to the resultData array
        While reader.Read()
            numberOfRows = numberOfRows + 1
            resultData(numberOfRows).username = reader.GetString("username")
            resultData(numberOfRows).matchesWon = reader.GetString("matchesWon")
        End While

        Dim currentMatches As Integer
        Dim currentName As String
        Dim position As Integer

        'This insertion sort sorts the array in order of number of wins descending
        For i = 1 To resultData.Length - 1
            currentMatches = resultData(i).matchesWon
            currentName = resultData(i).username
            position = i
            While position > 0 AndAlso resultData(position - 1).matchesWon < currentMatches
                resultData(position).matchesWon = resultData(position - 1).matchesWon
                resultData(position).username = resultData(position - 1).username
                position = position - 1
            End While
            resultData(position).matchesWon = currentMatches
            resultData(position).username = currentName
        Next

        conn.Close()

        'Displays the usernames and matches won on the leaderboard
        For counter = 0 To numberOfRows
            RichTextBox1.AppendText(resultData(counter).username & vbNewLine)
            RichTextBox2.AppendText(resultData(counter).matchesWon & vbNewLine)
        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainMenu.Show() 'Shows main menu
        Me.Hide() 'Hides this form
    End Sub
End Class