Imports Microsoft.Win32
Imports System.IO

Module EQPaths
    Public Const UI_ZEAL_FONTS = "uifiles\zeal\fonts\"
    Public Const UI_ZEAL_FONTS_EXTRA = UI_ZEAL_FONTS & "extra\"

    Private foundCache As List(Of String) = Nothing
    Private fontCache As List(Of String) = Nothing
    Private fontExtraCache As List(Of String) = Nothing

    Public registryLocations As String() = {
            "HKCU\Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store",
            "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers"
        }

    Public directoryLocations As String() = {
            "Sony\EverQuest\",
            "EverQuest\",
            "EQ\",
            "Program Files\Sony\EverQuest\",
            "Program Files\EverQuest\",
            "Program Files\EQ\",
            "Program Files (x86)\Sony\EverQuest\",
            "Program Files (x86)\EverQuest\",
            "Program Files (x86)\EQ"
        }

    Public Function GetPaths(Optional refreshCache As Boolean = False) As List(Of String)
        If Not IsNothing(EQPaths.foundCache) And Not refreshCache Then
            Return EQPaths.foundCache
        End If

        Dim foundLocations As New List(Of String)
        Dim compatPrimary As RegistryKey
        Dim compatStore As RegistryKey
        Dim compatStoreVals As String()

        For Each registryLocation As String In EQPaths.registryLocations
            Dim keyFragments As String() = registryLocation.Split("\", 2)
            If keyFragments.Length <> 2 Then
                Continue For
            End If

            Select Case keyFragments(0).ToUpper()
                Case "HKCU", "HKEY_CURRENT_USER"
                    compatPrimary = Registry.CurrentUser
                Case "HKLM", "HKEY_LOCAL_MACHINE"
                    compatPrimary = Registry.LocalMachine
                Case "HKCR", "HKEY_CLASSES_ROOT"
                    compatPrimary = Registry.ClassesRoot
                Case "HKCC", "HKEY_CURRENT_CONFIG"
                    compatPrimary = Registry.CurrentConfig
                Case "HKU", "HKEY_USERS"
                    compatPrimary = Registry.Users
                Case Else
                    Continue For
            End Select
            Try
                compatStore = compatPrimary.OpenSubKey(keyFragments(1))
                compatStoreVals = compatStore.GetValueNames()

                For Each subKey As String In compatStoreVals
                    Debug.WriteLine("Checking: " & subKey)
                    If subKey.Contains("eqgame.exe") Then
                        subKey = subKey.Replace("eqgame.exe", "")
                        foundLocations.Add(subKey)
                    End If
                Next

                compatStore.Close()
                compatPrimary = Nothing
            Catch ex As Exception
                Debug.Print("Could not access registry location for checking eqgame path. Permission denied." & Environment.NewLine & ex.Message)
            End Try
        Next

        Try
            For Each drive As DriveInfo In DriveInfo.GetDrives()
                If drive.DriveType <> DriveType.CDRom Then ' Cannot write to cd roms (normally) so ignore these drives
                    For Each pathSegment As String In EQPaths.directoryLocations
                        Dim cPath As String = drive.Name & pathSegment
                        If Path.Exists(cPath) Then
                            foundLocations.Add(cPath)
                        End If
                    Next
                End If
            Next
        Catch ex As IOException
            Debug.Print("Could Not access drive information! " & Environment.NewLine & ex.Message)
        Catch ex As UnauthorizedAccessException
            Debug.Print("Could Not access drive information! " & Environment.NewLine & ex.Message)
        End Try

        ' Add paths from Settings
        foundLocations.AddRange(My.Settings.PreviousEQPaths.Split(";"))

        ' Remove duplicates
        foundLocations = foundLocations.Distinct().ToList()

        EQPaths.foundCache = foundLocations

        Return foundLocations
    End Function

    Public Function IsZealHere(ByVal checkPath As String, Optional silent As Boolean = False) As Boolean
        If Not Path.Exists(checkPath) Then
            If Not silent Then ShowError("ERROR 0xF1 - Path Not Valid: The provided path is invalid! Please make sure the path supplied is to the Quarm directory where Zeal is installed.")
            Return False
        End If

        ' Zeal
        checkPath &= "\uifiles\zeal"
        If Not Path.Exists(checkPath) Then
            If Not silent Then ShowError("ERROR 0xF2 - Path Not Valid: The provided path does not seem to have zeal installed! Please make sure the path supplied is to the Quarm directory where Zeal is installed.")
            Return False
        End If

        ' Zeal Fonts
        checkPath &= "\fonts\"
        If Not Path.Exists(checkPath) Then
            If Not silent Then ShowError("ERROR 0xF3 - Path Not Valid: The provided path does not seem to have a zeal fonts folder! Please make sure the path supplied is to the Quarm directory where Zeal is installed.")
            Return False
        End If

        Return True
    End Function

    Public Function IsZealExtraHere(ByVal checkPath As String, Optional silent As Boolean = False) As Boolean
        If Not Path.Exists(checkPath) Then
            If Not silent Then ShowError("ERROR 0xF4 - Extra Fonts Not Found: The provided path does not seem to include the extras folder where zeal stored extra fonts for use.")
            Return False
        End If

        Return True
    End Function

    Public Function GetZealFonts(ByVal path As String, Optional refreshCache As Boolean = False) As List(Of String)
        If Not IsNothing(EQPaths.fontCache) And Not refreshCache Then
            Return EQPaths.fontCache
        End If

        Dim foundFiles As New List(Of String)
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchTopLevelOnly)
            foundFiles.Add(foundFile)
        Next

        EQPaths.fontCache = foundFiles

        Return foundFiles
    End Function

    Public Function GetZealExtraFonts(ByVal path As String, Optional refreshCache As Boolean = False) As List(Of String)
        If Not IsNothing(EQPaths.fontExtraCache) And Not refreshCache Then
            Return EQPaths.fontExtraCache
        End If

        Dim foundFiles As New List(Of String)

        If EQPaths.IsZealExtraHere(path) Then
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchTopLevelOnly)
                foundFiles.Add(foundFile)
            Next
        End If

        EQPaths.fontExtraCache = foundFiles

        Return foundFiles
    End Function

End Module
