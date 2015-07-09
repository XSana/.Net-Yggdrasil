Imports System.Runtime.Serialization

Namespace json
    <DataContract> _
    Class user
        <DataMember(Order:=0, IsRequired:=False)> _
        Public id As String
        <DataMember(Order:=1, IsRequired:=False)> _
        Public properties As properties()
    End Class

    <DataContract> _
    Class properties
        <DataMember(Order:=0, IsRequired:=False)> _
        Public name As String
        <DataMember(Order:=1, IsRequired:=False)> _
        Public value As String
    End Class
End Namespace