Namespace SIS.ENTIDAD
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Bitacora
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private idEventoField As Integer
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property idEvento() As Integer
            Get
                Return idEventoField
            End Get
            Set(ByVal value As Integer)
                idEventoField = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private idUsuarioField As String
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
        Private fechaField As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property fecha() As String
            Get
                Return fechaField
            End Get
            Set(ByVal value As String)
                fechaField = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private descripcionField As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property descripcion() As String
            Get
                Return descripcionField
            End Get
            Set(ByVal value As String)
                descripcionField = value
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
    End Class
End Namespace
