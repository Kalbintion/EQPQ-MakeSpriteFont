Imports System.Text.RegularExpressions

Module Selector
    Public Sub All(ByRef tree As TreeView)
        For Each node As TreeNode In tree.Nodes
            node.Checked = True
        Next
    End Sub

    Public Sub None(ByRef tree As TreeView)
        For Each node As TreeNode In tree.Nodes
            node.Checked = False
        Next
    End Sub

    Public Sub Some(ByRef tree As TreeView, Optional ByVal searchOn As String = "")
        If searchOn.Length = 0 Then
            searchOn = InputBox("Select items based on entered text. Use wildcard (*) to select multiple. Search pattern accepts Regular Expression." & Environment.NewLine & Environment.NewLine &
                                "To cancel, Leave blank Or use the cancel button.", "Select Some", "")
        End If

        If searchOn.Length = 0 Then
            Return
        End If

        ' Determine search type
        Dim reBasicString As New Regex("^[a-zA-Z0-9 ]{1,}$")
        Dim reWildcardString As New Regex("^[a-z-A-Z0-9 *]{1,}$")
        Dim reRegexString As New Regex(searchOn, RegexOptions.IgnoreCase)

        ' Determine search method to use based on settings
        Dim reSearchOn As Regex
        If My.Settings.AlwaysUseRegex Then
            If reBasicString.IsMatch(searchOn) Then
                Debug.Print("Basic Search")
                reSearchOn = New Regex(searchOn, RegexOptions.IgnoreCase)
            ElseIf reWildcardString.IsMatch(searchOn) Then
                Debug.Print("Wildcard Search")
                reSearchOn = New Regex(searchOn.Replace("*", ".*"), RegexOptions.IgnoreCase)
            Else
                Debug.Print("RegEx Search")
                reSearchOn = reRegexString
            End If

            Debug.Print(searchOn & Environment.NewLine & reSearchOn.ToString)

            For Each node As TreeNode In tree.Nodes
                node.Checked = reSearchOn.IsMatch(node.Text)
            Next
        Else
            If reBasicString.IsMatch(searchOn) Then
                For Each node As TreeNode In tree.Nodes
                    node.Checked = node.Text.Contains(searchOn)
                Next

                Return
            ElseIf reWildcardString.IsMatch(searchOn) Then
                Dim wildcardParts As String() = searchOn.Split("*")
                Dim lastPartIdx As Integer = 0
                Dim found As Boolean = True
                For Each node As TreeNode In tree.Nodes
                    For Each wildcardPart As String In wildcardParts
                        Dim tempIdx As Integer = node.Text.IndexOf(wildcardPart, lastPartIdx)
                        If tempIdx = -1 Then
                            found = False
                            Exit For
                        Else
                            lastPartIdx = tempIdx
                        End If
                    Next
                    If found Then
                        node.Checked = True
                    End If
                    found = True
                    lastPartIdx = 0
                Next
            Else
                reSearchOn = reRegexString
                Debug.Print(searchOn & Environment.NewLine & reSearchOn.ToString)

                For Each node As TreeNode In tree.Nodes
                    node.Checked = reSearchOn.IsMatch(node.Text)
                Next
            End If

        End If
    End Sub

    Public Function GetChecked(ByRef tree As TreeView) As List(Of TreeNode)
        Dim results As New List(Of TreeNode)

        For Each node As TreeNode In tree.Nodes
            If node.Checked Then
                results.Add(node)
            End If
        Next

        Return results
    End Function

    Public Function GetCheckedValues(ByRef tree As TreeView) As List(Of String)
        Dim results As New List(Of String)

        For Each node As TreeNode In tree.Nodes
            If node.Checked Then
                results.Add(node.Text)
            End If
        Next

        Return results
    End Function
End Module
