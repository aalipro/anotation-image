<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.lstPartie = New System.Windows.Forms.ListBox()
        Me.lesImages = New System.Windows.Forms.ListBox()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.imgLoaded = New System.Windows.Forms.PictureBox()
        Me.btnPathBd = New System.Windows.Forms.Button()
        Me.btnPathImg = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnResearch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDelAll = New System.Windows.Forms.Button()
        CType(Me.imgLoaded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Location = New System.Drawing.Point(186, 59)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(159, 55)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Sauvegarder"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.Location = New System.Drawing.Point(12, 59)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(168, 55)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "Nouvelle Image Annoter"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'btnLoad
        '
        Me.btnLoad.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoad.Location = New System.Drawing.Point(12, 522)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(333, 27)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Text = "Charger"
        Me.btnLoad.UseVisualStyleBackColor = False
        '
        'lstPartie
        '
        Me.lstPartie.BackColor = System.Drawing.SystemColors.Info
        Me.lstPartie.FormattingEnabled = True
        Me.lstPartie.ItemHeight = 20
        Me.lstPartie.Items.AddRange(New Object() {"Touts", "OeilGauche", "Oeil Droit", "Bordure du Visage Gauche", "Bordure du Visage Droit", "Bas Du nez", "Bord du Nez Gauche", "Bord du Nez Droit", "Bas du Menton", "Haut des lèvres", "Bas des Lèvres", "Gauche de la lèvre", "Droite de la lèvre"})
        Me.lstPartie.Location = New System.Drawing.Point(864, 235)
        Me.lstPartie.Name = "lstPartie"
        Me.lstPartie.Size = New System.Drawing.Size(195, 264)
        Me.lstPartie.TabIndex = 3
        '
        'lesImages
        '
        Me.lesImages.BackColor = System.Drawing.SystemColors.Info
        Me.lesImages.FormattingEnabled = True
        Me.lesImages.ItemHeight = 20
        Me.lesImages.Location = New System.Drawing.Point(12, 192)
        Me.lesImages.Name = "lesImages"
        Me.lesImages.Size = New System.Drawing.Size(333, 324)
        Me.lesImages.TabIndex = 4
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDel.Location = New System.Drawing.Point(863, 505)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(195, 33)
        Me.btnDel.TabIndex = 5
        Me.btnDel.Text = "Supprimer annotation"
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'imgLoaded
        '
        Me.imgLoaded.BackColor = System.Drawing.Color.Silver
        Me.imgLoaded.Cursor = System.Windows.Forms.Cursors.Cross
        Me.imgLoaded.Location = New System.Drawing.Point(351, 160)
        Me.imgLoaded.Name = "imgLoaded"
        Me.imgLoaded.Size = New System.Drawing.Size(507, 509)
        Me.imgLoaded.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLoaded.TabIndex = 6
        Me.imgLoaded.TabStop = False
        '
        'btnPathBd
        '
        Me.btnPathBd.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnPathBd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPathBd.Location = New System.Drawing.Point(12, 120)
        Me.btnPathBd.Name = "btnPathBd"
        Me.btnPathBd.Size = New System.Drawing.Size(333, 34)
        Me.btnPathBd.TabIndex = 11
        Me.btnPathBd.Text = "Base de donnée"
        Me.btnPathBd.UseVisualStyleBackColor = False
        '
        'btnPathImg
        '
        Me.btnPathImg.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnPathImg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPathImg.Location = New System.Drawing.Point(12, 160)
        Me.btnPathImg.Name = "btnPathImg"
        Me.btnPathImg.Size = New System.Drawing.Size(333, 35)
        Me.btnPathImg.TabIndex = 12
        Me.btnPathImg.Text = "Emplacement des images"
        Me.btnPathImg.UseVisualStyleBackColor = False
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHelp.Location = New System.Drawing.Point(865, 46)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(194, 55)
        Me.btnHelp.TabIndex = 13
        Me.btnHelp.Text = "Aide"
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'btnResearch
        '
        Me.btnResearch.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnResearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResearch.Location = New System.Drawing.Point(865, 110)
        Me.btnResearch.Name = "btnResearch"
        Me.btnResearch.Size = New System.Drawing.Size(195, 55)
        Me.btnResearch.TabIndex = 14
        Me.btnResearch.Text = "Rechercher"
        Me.btnResearch.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Info
        Me.Label1.Font = New System.Drawing.Font("Showcard Gothic", 36.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(351, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(499, 74)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Annoter Image"
        '
        'btnDelAll
        '
        Me.btnDelAll.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnDelAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelAll.Location = New System.Drawing.Point(865, 171)
        Me.btnDelAll.Name = "btnDelAll"
        Me.btnDelAll.Size = New System.Drawing.Size(195, 50)
        Me.btnDelAll.TabIndex = 16
        Me.btnDelAll.Text = "Tout supprimer"
        Me.btnDelAll.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1070, 672)
        Me.Controls.Add(Me.btnDelAll)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnResearch)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnPathImg)
        Me.Controls.Add(Me.btnPathBd)
        Me.Controls.Add(Me.imgLoaded)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.lesImages)
        Me.Controls.Add(Me.lstPartie)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "Form1"
        Me.Text = "Annoter Image"
        CType(Me.imgLoaded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSave As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents btnLoad As Button
    Friend WithEvents lstPartie As ListBox
    Friend WithEvents lesImages As ListBox
    Friend WithEvents btnDel As Button
    Friend WithEvents imgLoaded As PictureBox
    Friend WithEvents btnPathBd As Button
    Friend WithEvents btnPathImg As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnResearch As Button
    Friend WithEvents sar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDelAll As Button
End Class
