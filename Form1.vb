Imports System.IO
Public Class Form1
    Dim newBitmap As Bitmap = New Bitmap(400, 400)      ' un Bitmap
    Dim g As Graphics = Graphics.FromImage(newBitmap)   ' graphique avec le quel on va pouvoir faire des annotations sur l'image
    Dim Dic As New Dictionary(Of String, Integer())     ' Dictionnaire pour connaître les coordonnées d'une annotation pour une partie du visage
    Dim imgPath As String                               ' le chemin de l'image
    Dim bdPath As String                                ' le chemin de la base donnée
    Dim nomImg As String                                ' le nom de l'image
    Dim SW As StreamWriter                              ' Flux pour ecrire dans un fichier
    Dim enteteBD As String = "imageFile" & Chr(9) & ' première ligne d'une base de donnée
                    "YG.x" & Chr(9) &
                    "YG.y" & Chr(9) &
                    "YD.x" & Chr(9) &
                    "YD.y" & Chr(9) &
                    "BVG.x" & Chr(9) &
                    "BVG.y" & Chr(9) &
                    "BVD.x" & Chr(9) &
                    "BVD.y" & Chr(9) &
                    "BDN.x" & Chr(9) &
                    "BDN.y" & Chr(9) &
                    "BNG.x" & Chr(9) &
                    "BNG.y" & Chr(9) &
                    "BND.x" & Chr(9) &
                    "BND.y" & Chr(9) &
                    "BM.x" & Chr(9) &
                    "BM.y" & Chr(9) &
                    "LH.x" & Chr(9) &
                    "LH.y" & Chr(9) &
                    "BL.x" & Chr(9) &
                    "BL.y" & Chr(9) &
                    "LG.x" & Chr(9) &
                    "LG.y" & Chr(9) &
                    "LD.x" & Chr(9) &
                    "LD.y"
    Dim imgInBD() As String                                 ' Tableau dans lequel se trouve les images qu'il y'a dans la base de donnée
    Dim emplacementImage As String                          'Dossier dans lequel se trouve l'image
    ' Procédure evenementielle pour créer une nouvelle image annotée
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ' Creeation d'une OpenFileDialogue 
        Dim dialog As OpenFileDialog = New OpenFileDialog()
        dialog.Filter = "Fichiers image(*.png)(*.bmp)(*.jpg)|*.png;*.bmp;*.jpg"
        If dialog.ShowDialog() = DialogResult.OK Then
            imgPath = dialog.FileName
            Dim Fi As FileInfo = New FileInfo(imgPath)
            nomImg = Fi.Name
            Dic.Clear()
            imgLoaded.Image = Image.FromFile(imgPath)
        End If
    End Sub
    'Procédure évenentielle pour annoter une partie du visage
    Private Sub annoter(sender As Object, e As MouseEventArgs) Handles imgLoaded.MouseClick
        If imgLoaded.Image Is Nothing Then Exit Sub
        If lstPartie.SelectedItem Is Nothing Then
            MsgBox("Veuillez choisir une partie du visage")
            Exit Sub
        ElseIf lstPartie.SelectedItem IsNot lstPartie.Items(0) Then
            imgLoaded.Image = Image.FromFile(imgPath)
            g = imgLoaded.CreateGraphics
            imgLoaded.Refresh()
            g.FillEllipse(New SolidBrush(Color.Red), e.X - 14, e.Y - 14, 25, 25)

            If Not Dic.ContainsKey(lstPartie.SelectedItem) Then
                Dic.Add(lstPartie.SelectedItem, New Integer() {e.X - 14, e.Y - 14})
            Else
                Dic(lstPartie.SelectedItem) = New Integer() {e.X - 14, e.Y - 14}
            End If
        End If

    End Sub

    'Procédure évenementielle pour sauvegarder une image annotée
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If imgLoaded.Image Is Nothing Then
            MsgBox("Veuillez Créer ou load une image")
            Exit Sub
        ElseIf bdPath Is Nothing Then
            Dim result = MsgBox("Veuillez choisir une base de donnée dans laquelle enregistrer cette image annotée")
            Dim color = btnPathBd.BackColor
            btnPathBd.BackColor = color.Red
            If result.Ok Then
                btnPathBd.BackColor = color
            End If
            Exit Sub
        ElseIf Not (lstPartie.Items.Count - 1 = Dic.Count) Then
            MsgBox("Avant de pouvoir sauvegarder une immage annotée, il faut annoter toutes les parties du visage" & Chr(13) + Chr(10),
                   MsgBoxStyle.OkOnly,
                   "Attention")
            Exit Sub
        End If
        Dim myLines() As String = File.ReadAllLines(bdPath)
        If myLines.Length >= 2 Then
            For n = 1 To myLines.Length - 1
                Dim nomLigne = ""
                Dim i As Integer = 0
                While Not (myLines(n)(i) Like Chr(9))
                    nomLigne += myLines(n)(i)
                    i += 1
                End While
                'Si une sauvegarde de l'image existe déjà dans la base de donnée
                If nomLigne Like nomImg Then
                    Dim msg = MsgBox("Sauvegarde déjà existante dans cette base de donnée." & Chr(13) & Chr(10) &
                       "Voulez vous remplacer la sauvegarde existante par celle courante?)",
                       MsgBoxStyle.YesNo,
                       "Attention!")
                    If msg = MsgBoxResult.Yes Then
                        Dim uneLigne As String = ""
                        uneLigne += nomImg
                        For z = 1 To lstPartie.Items.Count - 1
                            If Dic.ContainsKey(lstPartie.Items(z)) Then
                                uneLigne += Chr(9) + CStr(Dic(lstPartie.Items(z))(0)) + Chr(9) + CStr(Dic(lstPartie.Items(z))(1))
                            ElseIf Not (z = lstPartie.Items.Count - 1) Then
                                uneLigne += Chr(9)
                            End If
                        Next
                        myLines(n) = uneLigne
                        File.WriteAllLines(bdPath, myLines)
                        MsgBox("Sauvegarde effectuée avec succès")
                        Exit Sub
                    ElseIf msg = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            Next
        End If
        ' Sauvegarde normal : quand il n'existe pas d'image annotée dans la base de donnée du même nom que la courante
        Dim laLigne As String = ""
        laLigne += nomImg
        For n = 1 To lstPartie.Items.Count - 1
            If Dic.ContainsKey(lstPartie.Items(n)) Then
                laLigne += Chr(9) + CStr(Dic(lstPartie.Items(n))(0)) + Chr(9) + CStr(Dic(lstPartie.Items(n))(1))
            ElseIf Not (n = lstPartie.Items.Count - 1) Then
                laLigne += Chr(9)
            End If
        Next
        SW = File.AppendText(bdPath)
        SW.WriteLine(laLigne)
        SW.Close()
        MsgBox("Sauvegarde effectuée avec succès")

    End Sub

    ' Procédure evenementielle pour choisir la base de donnée
    Private Sub choisirBaseDeDonne(sender As Object, e As EventArgs) Handles btnPathBd.Click
        Dim dialog As SaveFileDialog = New SaveFileDialog()
        dialog.Title = "Choix de la base de donnee"    ' changement du titre de la dialogue boxe
        dialog.Filter = ("Fichiers csv (*.csv)|*.csv") 'Filtrer pour ne voir que les fichers CSV
        If dialog.ShowDialog() = DialogResult.OK Then
            If File.Exists(dialog.FileName) Then
                Dim l1BD As String = File.ReadAllLines(dialog.FileName)(0)
                ' Si le fichier vsc ne corresponds pas à une base donnée : c'est à dire que sa première ligne est différente de enteteBD
                If Not (l1BD Like enteteBD) Then

                    Dim msg = MsgBox("Ce fichier ne correspond pas à une base de donnée." & Chr(13) + Chr(10) &
                                     "Voulez vous effacer tout sous contenu pour en faire une base de donnée?",
                                     MsgBoxStyle.YesNo,
                                     "Attention")

                    If msg = MsgBoxResult.Yes Then
                        bdPath = dialog.FileName
                        SW = New StreamWriter(bdPath)
                        SW.WriteLine(enteteBD)
                        MsgBox("Creation de la nouvelle base de donne effectué avec succée")
                        SW.Close()
                        lesImages.Items.Clear()
                    End If
                Else
                    bdPath = dialog.FileName
                    SW = File.AppendText(bdPath)
                    lesImages.Items.Clear()
                    MsgBox("Base de donnée enregistrer avec succée")
                    SW.Close()
                    initialiseImgInBD()

                End If
            Else
                bdPath = dialog.FileName
                SW = New StreamWriter(bdPath)
                SW.WriteLine(enteteBD)
                SW.Close()
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub lstPartie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPartie.SelectedIndexChanged
        If imgPath IsNot Nothing Then
            imgLoaded.Image = Image.FromFile(imgPath)
            g = imgLoaded.CreateGraphics
            Me.imgLoaded.Refresh()
            If lstPartie.SelectedItem IsNot Nothing Then
                If Dic.ContainsKey(lstPartie.SelectedItem) And lstPartie.SelectedItem IsNot lstPartie.Items(0) Then
                    g.FillEllipse(New SolidBrush(Color.Green), Dic(lstPartie.SelectedItem)(0), Dic(lstPartie.SelectedItem)(1), 25, 25)
                ElseIf lstPartie.SelectedItem Is lstPartie.Items(0) Then
                    For Each kvp As KeyValuePair(Of String, Integer()) In Dic
                        g.FillEllipse(New SolidBrush(Color.Green), kvp.Value(0), kvp.Value(1), 25, 25)
                    Next

                End If
            End If
        End If

    End Sub
    ' Procédure pour afficher toutes les parties du visages annotées
    Private Sub afficherTouts()
        imgLoaded.Image = Image.FromFile(imgPath)
        g = imgLoaded.CreateGraphics
        Me.imgLoaded.Refresh()
        For Each kvp As KeyValuePair(Of String, Integer()) In Dic
            g.FillEllipse(New SolidBrush(Color.Green), kvp.Value(0), kvp.Value(1), 25, 25)
        Next
    End Sub
    ' Procdédure evenementiel pour supprimer une annotation
    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If lstPartie.SelectedItem Is Nothing Then
            MsgBox("Veuillez selectionner une partie du visage")
            Exit Sub
        ElseIf Not Dic.ContainsKey(lstPartie.SelectedItem) Then
            MsgBox("Impossible de supprimer cette Annotation: elle n'existe pas!")
            Exit Sub
        Else
            imgLoaded.Image = Image.FromFile(imgPath)
            Dic.Remove(lstPartie.SelectedItem)

        End If
    End Sub



    'Procédure evenementiel pour choisir l'emplacement des images
    Private Sub choisirEmplacementImage(sender As Object, e As EventArgs) Handles btnPathImg.Click
        Dim fB As New FolderBrowserDialog
        fB.RootFolder = Environment.SpecialFolder.Desktop
        fB.Description = "Sélectionnez un répertoire"
        fB.ShowDialog()
        If fB.SelectedPath = String.Empty Then
            MsgBox("Pas de sélection")
        Else
            MsgBox(fB.SelectedPath)
            emplacementImage = fB.SelectedPath
        End If
        fB.Dispose()
        initialiseImgInBD()

    End Sub

    Private Sub initialiseImgInBD()
        ' Pour cette fonction nous avons que bdPath et emplacementImage ne soit pas Nothing
        ' Donc si l'un des 2 est nothing on quitte la procédure
        If bdPath Is Nothing Or emplacementImage Is Nothing Then
            Exit Sub
        End If
        lesImages.Items.Clear()
        Dim myLines() As String = File.ReadAllLines(bdPath)
        imgInBD = Array.Empty(Of String)
        If myLines.Length >= 2 Then
            For n = 1 To myLines.Length - 1
                Dim nomLigne = ""
                Dim i As Integer = 0
                While Not (myLines(n)(i) Like Chr(9))
                    nomLigne += myLines(n)(i)
                    i += 1
                End While
                imgInBD.Append(nomLigne)
                If File.Exists(emplacementImage + "\" + nomLigne) Then
                    lesImages.Items.Add(nomLigne)
                End If

            Next
        End If
        lstPartie.ClearSelected()
        lstPartie.SelectedItem = lstPartie.Items(0)
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        If emplacementImage Is Nothing Then
            Dim result = MsgBox("Veuillez choisir l'emplacement des images")
            Dim color = btnPathBd.BackColor
            btnPathBd.Refresh()
            btnPathBd.BackColor = Color.Red
            If result.Ok Then

                btnPathBd.BackColor = color

            End If
            Exit Sub
        ElseIf bdPath Is Nothing Then
            Dim result = MsgBox("Veuillez choisir une base de donnée dans laquelle enregistrer cette image annotée")
            Dim color = btnPathBd.BackColor
            btnPathBd.BackColor = Color.Red
            btnPathBd.Refresh()

            If result.Ok Then
                btnPathBd.BackColor = color
            End If
            Exit Sub
        End If
        If lesImages.SelectedItem Is Nothing Then
            MsgBox("Veuillez selectionner une image ci dessus")
            Exit Sub
        End If

        Dim myLines() As String = File.ReadAllLines(bdPath)
        Dim laLigne = File.ReadAllLines(bdPath)(lesImages.SelectedIndex + 1)
        Dim lesInfos = laLigne.Split(Chr(9))
        Dim z = 1
        imgLoaded.Image = Image.FromFile(emplacementImage + "\" + lesInfos(0))
        Console.WriteLine("Taille de les INFOS" & CStr(lesInfos.Length))
        Dic.Clear()

        For n = 1 To lstPartie.Items.Count - 1
            Console.WriteLine("z= " & z & "n= " & n)
            Dim X = CInt(lesInfos(2 * n - 1))
            Dim Y = CInt(lesInfos(2 * n))
            Dic.Add(lstPartie.Items(n), {X, Y})
            z += 1
        Next
        imgPath = emplacementImage + "\" + lesInfos(0)
        imgLoaded.Image = Image.FromFile(imgPath)
        nomImg = lesImages.SelectedItem
        Me.afficherTouts()
        MsgBox("Image Chargée avec succée")
    End Sub


    Private Sub lesImages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lesImages.SelectedIndexChanged

    End Sub

    ' Procédure évenementielle pour supprimer toutes les annotations
    Private Sub btnDelAll_Click(sender As Object, e As EventArgs) Handles btnDelAll.Click
        Dim msg = MsgBox("Voulez vous vraiment supprimer toutes les annotations?",
                   MsgBoxStyle.YesNo,
                   "Attention")
        If msg = MsgBoxResult.Yes Then
            imgLoaded.Image = Image.FromFile(imgPath)
            Dic.Clear()
            imgLoaded.Refresh()
            MsgBox("Toutes les annotations on bien étaient supprimés.")
        End If
    End Sub
End Class