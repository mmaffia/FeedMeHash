Imports Microsoft.VisualBasic

'Tweet elements
'by Maggy Maffia, 08-09/2013

#Region "Tweet Object"
Public Class Tweet

    Private _text As String
    Private _created_at As String
    Private _id_str As String
    Private _user As User
    Private _entities As Entities

    Public Property text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    Public Property created_at() As String
        Get
            Return _created_at
        End Get
        Set(ByVal value As String)
            _created_at = value
        End Set
    End Property

    Public Property id_str() As String
        Get
            Return _id_str
        End Get
        Set(ByVal value As String)
            _id_str = value
        End Set
    End Property

    Public Property user() As User
        Get
            Return _user
        End Get
        Set(ByVal value As User)
            _user = value
        End Set
    End Property

    Public Property entities() As Entities
        Get
            Return _entities
        End Get
        Set(ByVal value As Entities)
            _entities = value
        End Set
    End Property


End Class

#End Region


#Region "User Object"
Public Class User

    Private _id_str As String
    Private _name As String
    Private _screen_name As String
    Private _location As String


    Public Property id_str() As String
        Get
            Return _id_str
        End Get
        Set(ByVal value As String)
            _id_str = value
        End Set
    End Property

    Public Property name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Public Property screen_name() As String
        Get
            Return name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Public Property location() As String
        Get
            Return _location
        End Get
        Set(ByVal value As String)
            _location = value
        End Set
    End Property

End Class
#End Region

#Region "Entities Object"
Public Class Entities
    Private _hashtags As List(Of Hashtag)

    Public Property hashtags() As List(Of Hashtag)
        Get
            Return _hashtags
        End Get
        Set(ByVal value As List(Of Hashtag))
            _hashtags = value
        End Set
    End Property

    'Add more later

End Class
#End Region


#Region "Hashtag object"
Public Class Hashtag
    Private _text As String
    Private _indices As List(Of Integer)

    Public Property text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    Public Property indices() As List(Of Integer)
        Get
            Return _indices
        End Get
        Set(ByVal value As List(Of Integer))
            _indices = value
        End Set
    End Property
End Class
#End Region
