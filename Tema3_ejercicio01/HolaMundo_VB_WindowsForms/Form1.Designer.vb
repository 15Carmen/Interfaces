<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        BotonSaludo = New Button()
        TextBox1 = New TextBox()
        SuspendLayout()
        ' 
        ' BotonSaludo
        ' 
        BotonSaludo.Location = New Point(631, 157)
        BotonSaludo.Name = "BotonSaludo"
        BotonSaludo.Size = New Size(121, 61)
        BotonSaludo.TabIndex = 0
        BotonSaludo.Text = "Salu2"
        BotonSaludo.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(51, 177)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(553, 23)
        TextBox1.TabIndex = 1
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(TextBox1)
        Controls.Add(BotonSaludo)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BotonSaludo As Button
    Friend WithEvents TextBox1 As TextBox
End Class
