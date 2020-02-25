Public Class Form1
    Dim ship As New PictureBox
    Dim moveRight As Boolean = False
    Dim moveTop As Boolean = False
    Dim moveLeft As Boolean = False
    Dim moveDown As Boolean = False
    Dim maxMissileNumber As Integer = 5
    Dim missileArray(maxMissileNumber) As PictureBox
    Dim missileNumber As Integer = 0
    Dim missileOnScreen(maxMissileNumber) As Boolean
    Dim maxEnemyNumber As Integer = 20
    Dim enemyArray(maxEnemyNumber) As PictureBox
    Dim enemyOnScreen(maxEnemyNumber) As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Controls.Add(ship)
        ship.Width = 100
        ship.Height = 100
        ship.BackColor = Color.Transparent
        ship.BorderStyle = BorderStyle.None
        ship.Image = BackgroundImage.FromFile("C:\Users\claud\source\repos\VB.Jet Fighter\VB.Jet Fighter\Resources\jet.png")
        ship.Top = Me.Height - 1.4 * ship.Height
        ship.Left = Me.Width / 1.8 - ship.Width
        CreateMissiles(maxMissileNumber)
        CreateEnemies(maxEnemyNumber)
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim i As Integer
        Dim j As Integer

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

        For i = 0 To maxMissileNumber
            If missileOnScreen(i) = True Then
                missileArray(i).Top -= 4
            End If

            If missileArray(i).Top <= -10 Then
                missileOnScreen(i) = False
            End If

            For j = 0 To maxEnemyNumber
                If Collision(missileArray(i), enemyArray(j)) Then
                    missileArray(i).Visible = False
                    enemyArray(j).Visible = False
                End If
            Next
        Next
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim i As Integer = 0
        Dim count As Integer = 1

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
                For i = 0 To maxMissileNumber
                    If missileOnScreen(i) = True Then
                        count = count + 1
                    End If
                Next


                If count <= maxMissileNumber Then
                    missileOnScreen(missileNumber) = True
                    missileArray(missileNumber).Visible = True
                    missileArray(missileNumber).Top = ship.Top + ship.Height / 2 - missileArray(missileNumber).Height / 2
                    missileArray(missileNumber).Left = ship.Left + ship.Width / 2 - missileArray(missileNumber).Width / 2
                    missileNumber += 1
                    If missileNumber = maxMissileNumber Then missileNumber = 0
                End If
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

    Private Sub CreateMissiles(ByVal Number As Integer)
        Dim i As Integer = 0
        For i = 0 To Number
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
            missileArray(i) = missile
            missileArray(i).Visible = False
            missileOnScreen(i) = False
        Next
    End Sub

    Private Sub CreateEnemies(ByVal Number As Integer)
        Dim i As Integer = 0
        For i = 0 To Number
            Dim enemy As New PictureBox
            Me.Controls.Add(enemy)
            enemy.Width = 20
            enemy.Height = 20
            enemy.BackColor = Color.Red
            enemy.BorderStyle = BorderStyle.FixedSingle
            enemy.Top = 50
            enemy.Left = i * 50
            enemy.SendToBack()
            enemyArray(i) = enemy
            enemyArray(i).Visible = True
            enemyOnScreen(i) = True
        Next
    End Sub

    Private Function Collision(ByVal Object1 As Object, ByVal Object2 As Object) As Boolean
        Dim Collided As Boolean
        If Object1.Top + Object1.Height >= Object2.Top And
            Object2.Top + Object2.Height >= Object1.Top And
            Object1.Left + Object1.Width >= Object2.Left And
            Object2.Left + Object2.Width >= Object1.Left And Object1.visible = True And Object2.visible = True Then
            Collided = True
        End If
        Return Collided
    End Function

End Class
