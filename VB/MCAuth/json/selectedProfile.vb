Imports System.Runtime.Serialization

Namespace json
    <DataContract> _
    Class selectedProfile
        <DataMember(Order:=0, IsRequired:=False)> _
        Public name As String = ""
        <DataMember(Order:=1, IsRequired:=False)> _
        Public id As String = ""
    End Class
End Namespace