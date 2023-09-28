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
        btnSaludar = New Button()
        txtNombre = New TextBox()
        LabelNombre = New Label()
        SuspendLayout()
        ' 
        ' btnSaludar
        ' 
        btnSaludar.Location = New Point(631, 157)
        btnSaludar.Name = "btnSaludar"
        btnSaludar.Size = New Size(121, 61)
        btnSaludar.TabIndex = 0
        btnSaludar.Text = "Saludo"
        btnSaludar.UseVisualStyleBackColor = True
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(127, 177)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(477, 23)
        txtNombre.TabIndex = 1
        ' 
        ' LabelNombre
        ' 
        LabelNombre.AutoSize = True
        LabelNombre.Location = New Point(46, 180)
        LabelNombre.Name = "LabelNombre"
        LabelNombre.Size = New Size(54, 15)
        LabelNombre.TabIndex = 2
        LabelNombre.Text = "Nombre:"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(LabelNombre)
        Controls.Add(txtNombre)
        Controls.Add(btnSaludar)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnSaludar As Button
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents LabelNombre As Label
End Class
