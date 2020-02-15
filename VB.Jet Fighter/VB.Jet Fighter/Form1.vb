Public Class Form1
    Dim ship As New PictureBox
    Dim moveRight As Boolean = False
    Dim moveTop As Boolean = False
    Dim moveLeft As Boolean = False
    Dim moveDown As Boolean = False
    Dim missileArray() As PictureBox
    Dim missileNumber As Integer = -1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Controls.Add(ship)
        ship.Width = 100
        ship.Height = 100
        ship.BackColor = Color.Transparent
        ship.BorderStyle = BorderStyle.None
        ship.Image = BackgroundImage.FromFile("C:\Users\claud\source\repos\VB.Jet Fighter\VB.Jet Fighter\Resources\jet.png")
        ship.Top = Me.Height - 1.4 * ship.Height
        ship.Left = Me.Width / 1.8 - ship.Width
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim i As Integer

        If moveRight = True Then
            ship.Left += 5
        End If
        If moveLeft = True Then
            ship.Left -= 5
        End If
        If moveDown = True Then
            ship.Top += 5
        End If
        If moveTop = True Then
            ship.Top -= 5
        End If

        For i = 0 To missileNumber
            missileArray(i).Top -= 10
        Next
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyValue
            Case Keys.D
                moveRight = True
            Case Keys.W
                moveTop = True
            Case Keys.S
                moveDown = True
            Case Keys.A
                moveLeft = True
            Case Keys.Space
                Shoot()
        End Select
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyValue
            Case Keys.D
                moveRight = False
            Case Keys.W
                moveTop = False
            Case Keys.S
                moveDown = False
            Case Keys.A
                moveLeft = False
        End Select
    End Sub

    Private Sub Shoot()
        Dim missile As New PictureBox
        Me.Controls.Add(missile)
        missile.Width = 15
        missile.Height = 45
        missile.BackColor = Color.Transparent
        missile.BorderStyle = BorderStyle.None
        missile.Image = BackgroundImage.FromFile("C:\Users\claud\source\repos\VB.Jet Fighter\VB.Jet Fighter\Resources\missile2.png")
        missile.Top = ship.Top + ship.Height / 2 - missile.Height / 2
        missile.Left = ship.Left + ship.Width / 2 - missile.Width / 2
        missile.SendToBack()
        missileNumber += 1
        ReDim Preserve missileArray(missileNumber)
        missileArray(missileNumber) = missile

    End Sub

End Class
