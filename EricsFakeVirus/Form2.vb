Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Check if the user entered the correct password.
        If TextBox1.Text = "trollface" Then
            'Password accepted. Preparing to shutdown....

            'Re-enables the task manager
            Shell("REG add HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System /v DisableTaskMgr /t REG_DWORD /d 0 /f", AppWinStyle.Hide)

            'Opens explorer.exe back up again
            Shell("explorer.exe")

            'Changes the value on form1 to 1 to tell the program its ok to close
            Label2.Text = "1"

            'Lag the program for half a second (500 milliseconds) to make sure the value changed before the app sends the close request
            Threading.Thread.Sleep(500)

            'Send the close message
            Application.Exit()
        Else
            'Password declined.

            'Display an error showing that the password was wrong. (and ofc troll the user abit!)
            MessageBox.Show("Password Is Wrong. U mad bro?", "((:D)", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Clears the password textbox!
            TextBox1.Clear()

            'Focuses input on the textbox again
            TextBox1.Focus()
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class