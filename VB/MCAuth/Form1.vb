Imports System.Text
Imports System.Net
Imports System.IO
Imports MCAuth.json
Imports System.Runtime.Serialization.Json

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim JsonData = Auth(TextBox1.Text, TextBox2.Text)
        If JsonData <> "" Then
            '判断返回数据是否有效，有效则进行反序列化
            Dim AuthData As auth
            Dim jsonText = New MemoryStream(Encoding.UTF8.GetBytes(JsonData))
            Dim jsonRead = New DataContractJsonSerializer(GetType(auth))
            AuthData = TryCast(jsonRead.ReadObject(jsonText), auth)
            jsonText.Close()
            Dim Mes = New StringBuilder()
            Mes.Append("name:").Append(AuthData.selectedProfile.name).Append(vbLf)
            Mes.Append("uuid:").Append(AuthData.selectedProfile.id).Append(vbLf)
            Mes.Append("token:").Append(AuthData.clientToken)
            If AuthData.twitch(AuthData.user) <> "" Then
                Mes.Append(vbLf).Append("twitch:").Append(AuthData.twitch(AuthData.user))
            End If
            MessageBox.Show(Mes.ToString())
        End If
    End Sub

    ''' <summary>
    ''' 获取登录信息
    ''' </summary>
    ''' <param name="user">用户名</param>
    ''' <param name="password">密码</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Auth(user As String, password As String) As String
        Dim ret = String.Empty
        Try
            Dim data = "{""agent"":{""name"":""Minecraft"",""version"":""1""},""username"":""" & user & """,""password"":""" & password & """,""requestUser"":""true""}"
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(data)
            '转化
            Dim webReq = DirectCast(WebRequest.Create(New Uri("https://authserver.mojang.com/authenticate")), HttpWebRequest)
            webReq.Method = "POST"
            webReq.ContentType = "application/json"
            webReq.ContentLength = byteArray.Length
            Dim newStream As Stream = webReq.GetRequestStream()
            newStream.Write(byteArray, 0, byteArray.Length)
            '写入参数
            newStream.Close()
            Dim response = DirectCast(webReq.GetResponse(), HttpWebResponse)
            Dim sr = New StreamReader(response.GetResponseStream(), Encoding.[Default])
            ret = sr.ReadToEnd()
            sr.Close()
            response.Close()
            newStream.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return ret
    End Function
End Class
