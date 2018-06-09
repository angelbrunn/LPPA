Namespace SIS.ENTIDAD
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Usuario
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private idUsuarioField As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property idUsuario() As String
            Get
                Return idUsuarioField
            End Get
            Set(ByVal value As String)
                idUsuarioField = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private usuarioField As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property usuario() As String
            Get
                Return usuarioField
            End Get
            Set(ByVal value As String)
                usuarioField = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private passwordField As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property password() As String
            Get
                Return passwordField
            End Get
            Set(ByVal value As String)
                passwordField = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private legajoField As String
        Public Property legajo() As String
            Get
                Return legajoField
            End Get
            Set(ByVal value As String)
                legajoField = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private idiomaField As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property idioma() As String
            Get
                Return idiomaField
            End Get
            Set(ByVal value As String)
                idiomaField = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private digitoVerificadorField As String
        Public Property digitoVerificador() As String
            Get
                Return digitoVerificadorField
            End Get
            Set(ByVal value As String)
                digitoVerificadorField = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private listadoGruposField As List(Of Grupo)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property listadoGrupos() As List(Of Grupo)
            Get
                Return listadoGruposField
            End Get
            Set(ByVal value As List(Of Grupo))
                listadoGruposField = value
            End Set
        End Property
    End Class
End Namespace
