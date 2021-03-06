﻿Imports System.Runtime.Serialization
Imports System.Text

Namespace json
    <DataContract> _
    Class auth
        <DataMember(Order:=0, IsRequired:=True)> _
        Public accessToken As String
        <DataMember(Order:=1, IsRequired:=True)> _
        Public clientToken As String
        <DataMember(Order:=2, IsRequired:=False)> _
        Public selectedProfile As selectedProfile
        <DataMember(Order:=3, IsRequired:=False)> _
        Public user As user

        ''' <summary>
        ''' 取twitch传递参数
        ''' </summary>
        ''' <param name="user">auth.user</param>
        ''' <returns>成功返回传递参数，失败返回null</returns>
        ''' <remarks></remarks>
        Public Function twitch(user As user) As [String]
            If user.properties IsNot Nothing Then
                Dim twitchData As New StringBuilder()
                twitchData.Append("{""").Append(user.properties(0).name).Append(""":[""").Append(user.properties(0).value).Append("""]}")
                Return twitchData.ToString()
            Else
                Return Nothing
            End If
        End Function
    End Class
End Namespace